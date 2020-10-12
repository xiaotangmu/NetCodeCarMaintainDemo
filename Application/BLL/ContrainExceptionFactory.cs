using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ContrainExceptionFactory
    {
        public static ContrainExceptionFactory Singleton
        {
            get
            {
                return new ContrainExceptionFactory();
            }
        }

        private ContrainExceptionFactory() { }

        public async Task<Exception> Create<T>(PostgresException exception) where T : Entity.BaseEntity, new()
        {
            return await new T().ContrainException(exception);
        }
    }
}
