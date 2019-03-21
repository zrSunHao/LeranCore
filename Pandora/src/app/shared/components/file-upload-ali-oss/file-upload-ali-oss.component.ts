import { Observable } from 'rxjs';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { UUID } from 'angular2-uuid';
import * as OSS from 'ali-oss';

@Component({
  selector: 'app-file-upload-ali-oss',
  templateUrl: './file-upload-ali-oss.component.html',
  styles: [],
})
export class FileUploadAliOssComponent implements OnInit {
  client = new OSS({
    accessKeyId: 'LTAIMNBcPWNlAsER',
    accessKeySecret: 'iWeW3vbfvZSNsCD2u914Uw1yzazW34',
    bucket: 'zeus-dev',
    region: 'oss-cn-qingdao',
  });

  // tslint:disable-next-line:no-inferrable-types
  @Input() accept?: string = '*';
  // tslint:disable-next-line:ban-types
  @Input() fileSize?: Number;
  // tslint:disable-next-line:ban-types
  @Input() fileNumber?: Number = 10;
  // tslint:disable-next-line:ban-types
  @Input() uploadButtonBg?: String = 'btn-success';

  @Output() uploadStatus = new EventEmitter();

  filesList: any[] = [];
  // tslint:disable-next-line:ban-types
  isDisabledUploadButton: Boolean = true;

  constructor() {}

  ngOnInit() {}

  // click select files
  clickSelectFiles($event: any) {
    console.log($event.target.files[0]);
    this.handleFiles($event.target.files)
      .then((file: any[]) => {
        console.log($event.target.files);
        this.filesList.push(...file);
      })
      .then(() => {
        this.isDisabled();
      })
      .then(() => {
        this.uploadFile();
      });
  }

  // Handle files
  handleFiles(files: any[]) {
    return new Promise(resolve => {
      this.filterFileType(files).then((file: any[]) => {
        this.filterFileNumber(file).then((fil: any[]) => {
          this.filterFileSize(fil).then((filesArr: any[]) => {
            for (const filesA of filesArr) {
              // tslint:disable-next-line:no-string-literal
              filesA['loading'] = false;
              // tslint:disable-next-line:no-string-literal
              filesA['remove'] = false;
              // tslint:disable-next-line:no-string-literal
              filesA['percent'] = 0;
              // tslint:disable-next-line:no-string-literal
              filesA['isLoad'] = false;
            }
            resolve(filesArr);
          });
        });
      });
    });
  }

  // upload files
  uploadFile() {
    for (const file of this.filesList) {
      if (file.isLoad) {
        continue;
      }
      console.log(file);
      const key = UUID.UUID();
      const fileName = file.name;
      const index = fileName.lastIndexOf('.');
      const uploadFileName = key + fileName.substring(index);
      console.log(uploadFileName);

      file.isLoad = true;
      this.isDisabled();
      this.client
        .put(uploadFileName, file)
        .then((res: any) => {
          console.log(res);
          console.log(file);
          const href = res.res.requestUrls[0];

          file.status = 'success';
          file.displaySize = file.size;
          const event = {
            success: true,
            res,
          };
          this.uploadStatus.emit(event);
        })
        .catch((reason: any) => {
          file.status = 'error';
          const event = {
            success: true,
            reason,
          };
          this.uploadStatus.emit(event);
        });
    }
  }

  // isDisabledUploadButton
  isDisabled() {
    if (this.filesList.length === 0) {
      this.isDisabledUploadButton = true;
    } else {
      for (const file of this.filesList) {
        if (!file.isLoad) {
          this.isDisabledUploadButton = false;
          return;
        }
      }
      this.isDisabledUploadButton = true;
    }
  }

  // filter file type
  filterFileType(files: any[]) {
    return new Promise(resolve => {
      const filesFilter: any[] = [];
      if (this.accept === '*') {
        resolve(files);
      } else {
        for (const file of files) {
          const fileName = file.name;
          const pattern = new RegExp(`${this.accept}`);
          if (pattern.test(fileName)) {
            filesFilter.push(file);
          }
        }
        resolve(filesFilter);
      }
    });
  }

  // filter file size
  filterFileSize(files: any[]) {
    const filesFilter: any[] = [];
    return new Promise(resolve => {
      if (!this.fileSize) {
        resolve(files);
      } else {
        for (const file of files) {
          const fileSize = file.size / 1024;
          if (fileSize <= this.fileSize) {
            filesFilter.push(file);
          }
        }
        resolve(filesFilter);
      }
    });
  }

  // filter file number
  filterFileNumber(files: any[]) {
    return new Promise(resolve => {
      if (files.length > this.fileNumber) {
        return;
      } else {
        resolve(files);
      }
    });
  }

  // remove files
  removeFile(index: number) {
    this.filesList[index].removeAnimation = 'fadeOutRight';
    setTimeout(() => {
      this.filesList.splice(index, 1);
      this.isDisabled();
    }, 300);
  }
}
