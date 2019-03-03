export class PermissionTreeModel {
  key: string;

  title: string;

  isLeaf: boolean;

  isExpanded: boolean;

  icon: string;

  code: string;

  intro: string;

  parentKey: string;

  children: PermissionTreeModel[];
}
