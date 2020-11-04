using DapperExtensions;
using DateModel.User;
using Interface.Sku;
using ORM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.User;

namespace DAO.User
{
    public class UserDao : BaseDAO, IUserRepository
    {
        public UserDao() { }

        public UserDao(IDataRepository repository) : base(repository) { }
        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }

        public async Task<string> Insert(UMS_USER entity)
        {
            return await Repository.InsertAsync<UMS_USER>(entity);
        }

        public async Task<bool> IsExistUserByNameAndPwd(UserAddModel model)
        {
            var predicateCode = Predicates.Field<UMS_USER>(obj => obj.USER_NAME, Operator.Eq, model.UserName);
            var predicateIsUse = Predicates.Field<UMS_USER>(obj => obj.PWD, Operator.Eq, model.Pwd);
            var predicateGroup = Predicates.Group(GroupOperator.And, predicateCode, predicateIsUse);
            return await Repository.CountAsync<UMS_USER>(predicateGroup) > 0 ? true : false;
        }

        public async Task<bool> IsExistUserName(string userName)
        {
            var predicateCode = Predicates.Field<UMS_USER>(obj => obj.USER_NAME, Operator.Eq, userName);
            var predicateGroup = Predicates.Group(GroupOperator.And, predicateCode);
            return await Repository.CountAsync<UMS_USER>(predicateGroup) > 0 ? true : false;
        }
    }
}
