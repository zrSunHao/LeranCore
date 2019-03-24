using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Data.View.System;
using Sun.DatingApp.Model.Common;
using Sun.DatingApp.Model.System.Users.Dto;
using Sun.DatingApp.Model.System.Users.Model;
using Sun.DatingApp.Services.Services.Common.BaseServices;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Services.Services.System.UserServices
{
    public class UserService : BaseService, IUserService
    {
        public UserService(DataContext dataContext, IMapper mapper, ICacheHandler catchHandler) : base(dataContext, mapper, catchHandler)
        {

        }


        public async Task<WebApiResult<UserInfoModel>> GetUserInfo(Guid accountId)
        {
            var result = new WebApiResult<UserInfoModel>();
            try
            {
                var entity = await _dataContext.SystemUserInfos.FirstOrDefaultAsync(x => x.AccountId == accountId);
                if (entity == null)
                {
                    return result;
                }

                var model = new UserInfoModel
                {
                    Name = entity.Name,
                    Sex = entity.Sex,
                    Birthday = entity.Birthday,
                    Motto = entity.Motto,
                    QQ = entity.QQ,
                    WeChart = entity.WeChart,
                    Occupation = entity.Occupation,
                    Company = entity.Company,
                    Address = entity.Address,
                    Intro = entity.Intro
                };

                result.Data = model;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);

            }
            return result;
        }

        public async Task<WebApiResult> EditUserInfo(UserInfoDto dto, Guid accountId)
        {
            var result = new WebApiResult();
            try
            {
                var entity = await _dataContext.SystemUserInfos.FirstOrDefaultAsync(x => x.AccountId == accountId);
                if (entity == null)
                {
                    var info = new SystemUserInfo
                    {
                        Id = Guid.NewGuid(),
                        AccountId = accountId,
                        Name = dto.Name,
                        Sex = dto.Sex,
                        Birthday = dto.Birthday,
                        Motto = dto.Motto,
                        QQ = dto.QQ,
                        WeChart = dto.WeChart,
                        Occupation = dto.Occupation,
                        Company = dto.Company,
                        Address = dto.Address,
                        Intro = dto.Intro,
                        CreatedAt = DateTime.Now,
                        CreatedById = accountId,
                        Deleted = false
                    };

                    _dataContext.Add(info);
                }
                else
                {
                    entity.Name = dto.Name;
                    entity.Sex = dto.Sex;
                    entity.Birthday = dto.Birthday;
                    entity.Motto = dto.Motto;
                    entity.QQ = dto.QQ;
                    entity.WeChart = dto.WeChart;
                    entity.Occupation = dto.Occupation;
                    entity.Company = dto.Company;
                    entity.Address = dto.Address;
                    entity.Intro = dto.Intro;
                    entity.UpdatedById = accountId;
                    entity.UpdatedAt = DateTime.Now;
                }

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.AddError(ex.InnerException?.Message);

            }
            return result;
        }

        public WebApiResult Test()
        {
            var result = new WebApiResult();
            try
            {
                var roleId = Guid.Parse("1426DE8F-D0F4-428A-BC1E-91F36BE1EFE4");

                using (var conn = new SqlConnection("Data Source=192.168.1.201; Database=Sunny_D; User ID=sa; Password=123456;"))
                {
                    string sql = @"SELECT * FROM [dbo].[ViewAuthorizationRolePermission] WHERE [RoleId] = @RoleId";

                    var ttt = conn.QueryMultiple(sql, new { RoleId = roleId });
                    var yyy = ttt.Read<ViewAuthorizationRolePermission>().ToList();
                    var tetete = yyy;
                }
            }
            catch (Exception ex)
            {
               result.AddError(ex.Message);
               result.AddError(ex.InnerException?.Message);
            }

            return result;
        }
    }
}
