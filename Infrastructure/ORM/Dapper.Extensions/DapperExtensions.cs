﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using DapperExtensions.Sql;
using DapperExtensions.Mapper;
using DataAccess;
using System.Threading.Tasks;

namespace DapperExtensions
{
    public static class DapperExtensions
    {
        private readonly static object _lock = new object();

        private static Func<IDapperExtensionsConfiguration, IDapperImplementor> _instanceFactory;
        private static IDapperImplementor _instance;
        private static IDapperExtensionsConfiguration _configuration;

        /// <summary>
        /// Gets or sets the default class mapper to use when generating class maps. If not specified, AutoClassMapper<T> is used.
        /// DapperExtensions.Configure(Type, IList<Assembly>, ISqlDialect) can be used instead to set all values at once
        /// </summary>
        public static Type DefaultMapper
        {
            get
            {
                return _configuration.DefaultMapper;
            }

            set
            {
                Configure(value, _configuration.MappingAssemblies, _configuration.Dialect);
            }
        }

        /// <summary>
        /// Gets or sets the type of sql to be generated.
        /// DapperExtensions.Configure(Type, IList<Assembly>, ISqlDialect) can be used instead to set all values at once
        /// </summary>
        public static ISqlDialect SqlDialect
        {
            get
            {
                return _configuration.Dialect;
            }

            set
            {
                Configure(_configuration.DefaultMapper, _configuration.MappingAssemblies, value);
            }
        }

        /// <summary>
        /// Get or sets the Dapper Extensions Implementation Factory.
        /// </summary>
        public static Func<IDapperExtensionsConfiguration, IDapperImplementor> InstanceFactory
        {
            get
            {
                if (_instanceFactory == null)
                {
                    _instanceFactory = config => new DapperImplementor(new SqlGeneratorImpl(config));
                }

                return _instanceFactory;
            }
            set
            {
                _instanceFactory = value;
                Configure(_configuration.DefaultMapper, _configuration.MappingAssemblies, _configuration.Dialect);
            }
        }

        /// <summary>
        /// Gets the Dapper Extensions Implementation
        /// </summary>
        //private static IDapperImplementor Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            lock (_lock)
        //            {
        //                if (_instance == null)
        //                {
        //                    _instance = InstanceFactory(_configuration);
        //                }
        //            }
        //        }

        //        return _instance;
        //    }
        //}

        private static IDapperImplementor CreateInstance(DatabaseType databaseType)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = CreateImplementor(databaseType);
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// 自定义Implementor创建方法，暂停用
        /// </summary>    
        private static IDapperImplementor CreateImplementor(DatabaseType databaseType)
        {
            IDapperImplementor implementor = null;
            switch (databaseType)
            {
                case DatabaseType.Postgresql:
                    implementor = InstanceFactory(new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new PostgreSqlDialect()));
                    break;
                case DatabaseType.SqlServer:
                    implementor = InstanceFactory(new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new SqlServerDialect()));
                    break;
                default:
                    break;
            }
            return implementor;
        }

        static DapperExtensions()
        {
            Configure(typeof(AutoClassMapper<>), new List<Assembly>(), new PostgreSqlDialect());
        }

        /// <summary>
        /// Add other assemblies that Dapper Extensions will search if a mapping is not found in the same assembly of the POCO.
        /// </summary>
        /// <param name="assemblies"></param>
        public static void SetMappingAssemblies(IList<Assembly> assemblies)
        {
            Configure(_configuration.DefaultMapper, assemblies, _configuration.Dialect);
        }

        /// <summary>
        /// Configure DapperExtensions extension methods.
        /// </summary>
        /// <param name="defaultMapper"></param>
        /// <param name="mappingAssemblies"></param>
        /// <param name="sqlDialect"></param>
        public static void Configure(IDapperExtensionsConfiguration configuration)
        {
            _instance = null;
            _configuration = configuration;
        }

        /// <summary>
        /// Configure DapperExtensions extension methods.
        /// </summary>
        /// <param name="defaultMapper"></param>
        /// <param name="mappingAssemblies"></param>
        /// <param name="sqlDialect"></param>
        public static void Configure(Type defaultMapper, IList<Assembly> mappingAssemblies, ISqlDialect sqlDialect)
        {
            Configure(new DapperExtensionsConfiguration(defaultMapper, mappingAssemblies, sqlDialect));
        }

        /// <summary>
        /// Executes a query for the specified id, returning the data typed as per T
        /// </summary>
        public static T Get<T>(this IDbConnection connection, dynamic id, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var result = CreateInstance(databaseType).Get<T>(connection, id, transaction, commandTimeout);
            return (T)result;
        }

        /// <summary>
        /// Executes a query for the specified id, returning the data typed as per T
        /// </summary>
        public async static Task<T> GetAsync<T>(this IDbConnection connection, dynamic id, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var result = await CreateInstance(databaseType).GetAsync<T>(connection, id, transaction, commandTimeout);
            return (T)result;
        }

        /// <summary>
        /// Executes an insert query for the specified entity.
        /// </summary>
        public static void Insert<T>(this IDbConnection connection, IEnumerable<T> entities, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            CreateInstance(databaseType).Insert<T>(connection, entities, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes an insert query for the specified entity.
        /// </summary>
        public async static Task InsertAsync<T>(this IDbConnection connection, IEnumerable<T> entities, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            await CreateInstance(databaseType).InsertAsync<T>(connection, entities, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes an insert query for the specified entity, returning the primary key.  
        /// If the entity has a single key, just the value is returned.  
        /// If the entity has a composite key, an IDictionary&lt;string, object&gt; is returned with the key values.
        /// The key value for the entity will also be updated if the KeyType is a Guid or Identity.
        /// </summary>
        public static dynamic Insert<T>(this IDbConnection connection, T entity, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return CreateInstance(databaseType).Insert<T>(connection, entity, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes an insert query for the specified entity, returning the primary key.  
        /// If the entity has a single key, just the value is returned.  
        /// If the entity has a composite key, an IDictionary&lt;string, object&gt; is returned with the key values.
        /// The key value for the entity will also be updated if the KeyType is a Guid or Identity.
        /// </summary>
        public async static Task<dynamic> InsertAsync<T>(this IDbConnection connection, T entity, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return await CreateInstance(databaseType).InsertAsync<T>(connection, entity, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes an update query for the specified entity.
        /// </summary>
        public static bool Update<T>(this IDbConnection connection, T entity, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class
        {
            return CreateInstance(databaseType).Update<T>(connection, entity, transaction, commandTimeout, ignoreAllKeyProperties);
        }

        /// <summary>
        /// Executes an update query for the specified entity.
        /// </summary>
        public async static Task<bool> UpdateAsync<T>(this IDbConnection connection, T entity, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class
        {
            return await CreateInstance(databaseType).UpdateAsync<T>(connection, entity, transaction, commandTimeout, ignoreAllKeyProperties);
        }

        /// <summary>
        /// Executes a delete query for the specified entity.
        /// </summary>
        public static bool Delete<T>(this IDbConnection connection, T entity, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return CreateInstance(databaseType).Delete<T>(connection, entity, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes a delete query for the specified entity.
        /// </summary>
        public async static Task<bool> DeleteAsync<T>(this IDbConnection connection, T entity, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return await CreateInstance(databaseType).DeleteAsync<T>(connection, entity, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes a delete query using the specified predicate.
        /// </summary>
        public static bool Delete<T>(this IDbConnection connection, object predicate, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return CreateInstance(databaseType).Delete<T>(connection, predicate, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes a delete query using the specified predicate.
        /// </summary>
        public async static Task<bool> DeleteAsync<T>(this IDbConnection connection, object predicate, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return await CreateInstance(databaseType).DeleteAsync<T>(connection, predicate, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes a select query using the specified predicate, returning an IEnumerable data typed as per T.
        /// </summary>
        public static IEnumerable<T> GetList<T>(this IDbConnection connection, DatabaseType databaseType, object predicate = null, IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null, bool buffered = true) where T : class
        {
            return CreateInstance(databaseType).GetList<T>(connection, predicate, sort, transaction, commandTimeout, buffered);
        }

        /// <summary>
        /// Executes a select query using the specified predicate, returning an IEnumerable data typed as per T.
        /// </summary>
        public async static Task<IEnumerable<T>> GetListAsync<T>(this IDbConnection connection, DatabaseType databaseType, object predicate = null, IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null, bool buffered = true) where T : class
        {
            var result = await CreateInstance(databaseType).GetListAsync<T>(connection, predicate, sort, transaction, commandTimeout, buffered);
            return result;
        }

        /// <summary>
        /// Executes a select query using the specified predicate, returning an IEnumerable data typed as per T.
        /// Data returned is dependent upon the specified page and resultsPerPage.
        /// </summary>
        public static IEnumerable<T> GetPage<T>(this IDbConnection connection, object predicate, IList<ISort> sort, int page, int resultsPerPage, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null, bool buffered = true) where T : class
        {
            return CreateInstance(databaseType).GetPage<T>(connection, predicate, sort, page, resultsPerPage, transaction, commandTimeout, buffered);
        }

        /// <summary>
        /// Executes a select query using the specified predicate, returning an IEnumerable data typed as per T.
        /// Data returned is dependent upon the specified page and resultsPerPage.
        /// </summary>
        public async static Task<IEnumerable<T>> GetPageAsync<T>(this IDbConnection connection, object predicate, IList<ISort> sort, int page, int resultsPerPage, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null, bool buffered = true) where T : class
        {
            return await CreateInstance(databaseType).GetPageAsync<T>(connection, predicate, sort, page, resultsPerPage, transaction, commandTimeout, buffered);
        }

        /// <summary>
        /// Executes a select query using the specified predicate, returning an IEnumerable data typed as per T.
        /// Data returned is dependent upon the specified firstResult and maxResults.
        /// </summary>
        public async static Task<IEnumerable<T>> GetSetAsync<T>(this IDbConnection connection, object predicate, IList<ISort> sort, int firstResult, int maxResults, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null, bool buffered = true) where T : class
        {
            return await CreateInstance(databaseType).GetSetAsync<T>(connection, predicate, sort, firstResult, maxResults, transaction, commandTimeout, buffered);
        }

        /// <summary>
        /// Executes a query using the specified predicate, returning an integer that represents the number of rows that match the query.
        /// </summary>
        public static int Count<T>(this IDbConnection connection, object predicate, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return CreateInstance(databaseType).Count<T>(connection, predicate, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes a query using the specified predicate, returning an integer that represents the number of rows that match the query.
        /// </summary>
        public async static Task<int> CountAsync<T>(this IDbConnection connection, object predicate, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return await CreateInstance(databaseType).CountAsync<T>(connection, predicate, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes a select query for multiple objects, returning IMultipleResultReader for each predicate.
        /// </summary>
        public static IMultipleResultReader GetMultiple(this IDbConnection connection, GetMultiplePredicate predicate, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return CreateInstance(databaseType).GetMultiple(connection, predicate, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes a select query for multiple objects, returning IMultipleResultReader for each predicate.
        /// </summary>
        public async static Task<IMultipleResultReader> GetMultipleAsync(this IDbConnection connection, GetMultiplePredicate predicate, DatabaseType databaseType, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return await CreateInstance(databaseType).GetMultipleAsync(connection, predicate, transaction, commandTimeout);
        }

        /// <summary>
        /// Gets the appropriate mapper for the specified type T. 
        /// If the mapper for the type is not yet created, a new mapper is generated from the mapper type specifed by DefaultMapper.
        /// </summary>
        public static IClassMapper GetMap<T>(DatabaseType databaseType) where T : class
        {
            return CreateInstance(databaseType).SqlGenerator.Configuration.GetMap<T>();
        }

        /// <summary>
        /// Clears the ClassMappers for each type.
        /// </summary>
        public static void ClearCache(DatabaseType databaseType)
        {
            CreateInstance(databaseType).SqlGenerator.Configuration.ClearCache();
        }

        /// <summary>
        /// Generates a COMB Guid which solves the fragmented index issue.
        /// See: http://davybrion.com/blog/2009/05/using-the-guidcomb-identifier-strategy
        /// </summary>
        public static Guid GetNextGuid(DatabaseType databaseType)
        {
            return CreateInstance(databaseType).SqlGenerator.Configuration.GetNextGuid();
        }
    }
}
