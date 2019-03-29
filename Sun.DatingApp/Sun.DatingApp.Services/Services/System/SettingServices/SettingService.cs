using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Data.View.System;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.System.Setting.Dto;
using Sun.DatingApp.Model.System.Setting.Model;
using Sun.DatingApp.Services.Services.Common.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;
using Sun.DatingApp.Utility.SqlUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sun.DatingApp.Services.Services.System.SettingServices
{
    public class SettingService : BaseService, ISettingService
    {
        public SettingService(DataContext dataContext, IMapper mapper, ICacheHandler catchService) : base(dataContext, mapper, catchService)
        {
        }


        public WebApiPagingResult<List<SettingListModel>> GetSettings(PagingOptions<SettingSearchDto> paging)
        {
            var result = new WebApiPagingResult<List<SettingListModel>>();
            try
            {
                var query = "";
                if (paging.Filter != null)
                {
                    query = query + this.GetSettingQuery(paging.Filter);
                }

                var sql = ListSqlUtility.GetListSql("ViewSettingList", query, paging, "CreatedAt");
                var countSql = ListSqlUtility.GetListCountSql("ViewSettingList", query);

                var views = _dapperContext.Conn.Query<ViewSettingList>(sql).ToList();
                if (!views.Any())
                {
                    return result;
                }
                result.RowsCount = _dapperContext.Conn.QueryFirstOrDefault<int>(countSql);

                views = views.OrderBy(x => x.UpdatedAt).ToList();
                var data = _mapper.Map<List<ViewSettingList>, List<SettingListModel>>(views);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult> CreateSetting(EditSettingDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = _mapper.Map<EditSettingDto, SystemSetting>(dto);
                entity.CreatedById = accountId;

                _dataContext.SystemSettings.Add(entity);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }

        public async Task<WebApiResult> EditSetting(EditSettingDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                if (!dto.Id.HasValue)
                {
                    result.AddError("数据不完整");
                    return result;
                }

                var entity = await _dataContext.SystemSettings.FirstOrDefaultAsync(x => x.Id == dto.Id.Value);
                if (entity == null)
                {
                    result.AddError("未获取到Setting");
                    return result;
                }

                entity.Value = dto.Value;
                entity.UpdatedAt = DateTime.Now;
                entity.UpdatedById = accountId;

                await _dataContext.SaveChangesAsync();

                var value = dto.Value;
                if (string.IsNullOrEmpty(value))
                {
                    value = "";
                }
                this._catchHandler.Replace(dto.Key, value);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);
            }
            return result;
        }




        private string GetSettingQuery(SettingSearchDto dto)
        {
            try
            {
                var query = "";

                if (!string.IsNullOrEmpty(dto.Key))
                {
                    query = "WHERE [Key] LIKE '%" + dto.Key + "%'";
                }

                if (!string.IsNullOrEmpty(dto.Value))
                {
                    query = "WHERE [Value] LIKE '%" + dto.Value + "%'";
                }

                if (!string.IsNullOrEmpty(dto.Key) && !string.IsNullOrEmpty(dto.Value))
                {
                    query = "WHERE [Key] LIKE '%" + dto.Key + "%' AND [MenuName] LIKE '%" + dto.Value + "%'";
                }

                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
