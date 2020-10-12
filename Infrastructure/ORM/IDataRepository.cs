using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DataAccess;

/// <summary>
/// 提供数据层使用，继承了IDataServiceRepository，支持传入sql
/// </summary>
namespace ORM
{
    public interface IDataRepository
    {
        IDBSession DbSession { get; }

        IEnumerable<T> GetGroup<T>(string sql, dynamic param = null, bool buffered = true) where T : class, new();

        Task<IEnumerable<T>> GetGroupAsync<T>(string sql, dynamic param = null, bool buffered = true) where T : class, new();

        IEnumerable<dynamic> GetCustomReturnTypeGroup(string sql, dynamic param = null, bool buffered = true);

        Task<IEnumerable<dynamic>> GetCustomReturnTypeGroupAsync(string sql, dynamic param = null, bool buffered = true);

        IEnumerable<TReturn> GetGroup<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map,
            dynamic param = null, bool buffered = true,
            string splitOn = "Id", int? commandTimeout = null);

        Task<IEnumerable<TReturn>> GetGroupAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null,
            bool buffered = true, string splitOn = "Id", int? commandTimeout = null);

        IEnumerable<TReturn> GetGroup<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map,
           dynamic param = null, bool buffered = true,
           string splitOn = "Id", int? commandTimeout = null);

        Task<IEnumerable<TReturn>> GetGroupAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, dynamic param = null,
            bool buffered = true, string splitOn = "Id", int? commandTimeout = null);

        T GetFirst<T>(IPredicate predicate = null, IList<ISort> sort = null, bool buffered = true) where T : class, new();

        Task<T> GetFirstAsync<T>(IPredicate predicate = null, IList<ISort> sort = null, bool buffered = true, IDbTransaction transaction = null) where T : class, new();

        T GetFirst<T>(string sql, dynamic param = null, bool buffered = true) where T : class, new();

        Task<T> GetFirstAsync<T>(string sql, dynamic param = null, bool buffered = true) where T : class, new();

        SqlMapper.GridReader GetMultiple(string sql, dynamic param = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<SqlMapper.GridReader> GetMultipleAsync(string sql, dynamic param = null, int? commandTimeout = null, CommandType? commandType = null);

        IEnumerable<T> GetPage<T>(int pageIndex, int pageSize, out long allRowsCount, string sql, string orderby, dynamic param = null, string allRowsCountSql = null, dynamic allRowsCountParam = null, bool buffered = true) where T : class, new();

        Task<IEnumerable<T>> GetPageAsync<T>(int pageIndex, int pageSize, string sql, string orderby, dynamic param = null, string allRowsCountSql = null, dynamic allRowsCountParam = null, bool buffered = true) where T : class, new();

        Int32 Execute(string sql, dynamic param = null, IDbTransaction transaction = null);

        Task<Int32> ExecuteAsync(string sql, dynamic param = null, IDbTransaction transaction = null);

        T GetById<T>(dynamic primaryId) where T : class, new();

        Task<T> GetByIdAsync<T>(dynamic primaryId) where T : class, new();

        IEnumerable<T> GetAll<T>() where T : class, new();

        int Count<T>(IPredicate predicate, bool buffered = true) where T : class, new();

        Task<int> CountAsync(string sql, dynamic param = null);

        Task<int> CountAsync<T>(IPredicate predicate, bool buffered = true) where T : class, new();

        //lsit
        IEnumerable<T> GetList<T>(IPredicate predicate = null, IList<ISort> sort = null, bool buffered = true) where T : class, new();

        Task<IEnumerable<T>> GetListAsync<T>(IPredicate predicate = null, IList<ISort> sort = null, bool buffered = true) where T : class, new();

        IEnumerable<T> GetPageList<T>(int pageIndex, int pageSize, out long allRowsCount, IPredicate predicate = null, IList<ISort> sort = null, bool buffered = true) where T : class, new();

        Task<IEnumerable<T>> GetPageListAsync<T>(int pageIndex, int pageSize, IPredicate predicate = null, IList<ISort> sort = null, bool buffered = true) where T : class, new();

        dynamic Insert<T>(T entity, IDbTransaction transaction = null) where T : class, new();

        Task<dynamic> InsertAsync<T>(T entity, IDbTransaction transaction = null) where T : class, new();

        bool InsertBatch<T>(IEnumerable<T> entityList, IDbTransaction transaction = null) where T : class, new();

        Task<bool> InsertBatchAsync<T>(IEnumerable<T> entityList, IDbTransaction transaction = null) where T : class, new();

        bool Update<T>(T entity, IDbTransaction transaction = null) where T : class, new();

        Task<bool> UpdateAsync<T>(T entity, IDbTransaction transaction = null) where T : class, new();

        Task<bool> UpdateAsync<T>(Dictionary<string, object> setCollection, Dictionary<string, object> whereCollection, IDbTransaction transaction = null) where T : class, new();

        bool UpdateBatch<T>(IEnumerable<T> entityList, IDbTransaction transaction = null) where T : class, new();

        int Delete<T>(dynamic primaryId, IDbTransaction transaction = null) where T : class, new();

        Task<int> DeleteAsync<T>(dynamic primaryId, IDbTransaction transaction = null) where T : class, new();

        int Delete<T>(IPredicate predicate, IDbTransaction transaction = null) where T : class, new();

        Task<int> DeleteAsync<T>(IPredicate predicate = null, IDbTransaction transaction = null) where T : class, new();

        bool DeleteBatch<T>(IEnumerable<dynamic> ids, IDbTransaction transaction = null) where T : class, new();
    }
}
