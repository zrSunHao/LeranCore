using System;
using System.Collections.Generic;
using System.Text;
using Sun.DatingApp.Model.Common;

namespace Sun.DatingApp.Utility.SqlUtility
{
    public static class ListSqlUtility
    {
        /// <summary>
        /// 列表分页SQL
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="query">查询条件</param>
        /// <param name="paging">分页数据</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public static string GetListSql<T>(string table, string query, PagingOptions<T> paging, string order)
        {
            try
            {
                var top = "SELECT * FROM [" + table + "] ";
                var page = GetPagingSql(paging, order);

                return top + query + page;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 列表分页SQL
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="query">查询条件</param>
        /// <param name="paging">分页数据</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public static string GetListSql(string table, string query, PagingOptions paging, string order)
        {
            try
            {
                var top = "SELECT * FROM [" + table + "] ";
                var page = GetPagingSql(paging, order);

                return top + query + page;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 列表条数SQL
        /// </summary>
        /// <param name="table"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static string GetListCountSql(string table, string query)
        {
            return "SELECT COUNT(*) FROM [" + table + "] " + query + ";";
        }

        private static string GetPagingSql<T>(PagingOptions<T> paging, string order)
        {
            var pageIndex = paging.PageIndex;
            if (pageIndex < 1)
            {
                pageIndex = 0;
            }
            var pageSize = paging.PageSize;
            if (pageIndex < 1)
            {
                pageIndex = 10;
            }

            var page = " ORDER BY [" + order + "] OFFSET " + pageSize * pageIndex + " rows FETCH next " +
                       pageSize + " rows only" + ";";
            return page;
        }

        private static string GetPagingSql(PagingOptions paging, string order)
        {
            var pageIndex = paging.PageIndex;
            if (pageIndex < 1)
            {
                pageIndex = 0;
            }
            var pageSize = paging.PageSize;
            if (pageIndex < 1)
            {
                pageIndex = 10;
            }

            var page = " ORDER BY [" + order + "] OFFSET " + pageSize * pageIndex + " rows FETCH next " +
                       pageSize + " rows only" + ";";
            return page;
        }
    }
}
