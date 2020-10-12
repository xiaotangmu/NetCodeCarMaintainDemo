using System;
using System.Threading.Tasks;

namespace Entity
{
    public class BaseEntity
    {
        /// <summary>
        /// 表ID
        /// </summary>
        private string _id;

        /// <summary>
        /// 表ID
        /// </summary>
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public static readonly string FIELD_CREATE_TIME = "create_time";
        /// <summary>
        /// </summary>
        public DateTime CREATE_TIME { get; set; } = DateTime.Now;

        public static readonly string FIELD_UPDATE_TIME = "update_time";
        /// <summary>
        /// </summary>
        public DateTime UPDATE_TIME { get; set; } = DateTime.Now;

        public BaseEntity()
        {
            _id = Guid.NewGuid().ToString().Replace("-", "");
        }

        /// <summary>
        /// 定位各实体类的约束键异常信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public async Task<Exception> ContrainException(Exception ex)
        {
            ex = await ColumnContrainException(ex);
            ex = await UniqueContrainException(ex);
            return ex;
        }

        protected virtual async Task<Exception> ColumnContrainException(Exception ex)
        {
            return ex;
        }

        protected virtual async Task<Exception> UniqueContrainException(Exception ex)
        {
            return ex;
        }

        protected object GetColumnNamePropertyValue(Exception ex)
        {
            return GetExceptionPropertyValue(ex, "ColumnName");
        }

        protected object GetConstrainNamePropertyValue(Exception ex)
        {
            return GetExceptionPropertyValue(ex, "ConstraintName");
        }

        private object GetExceptionPropertyValue(Exception ex, string propertyName)
        {
            System.Reflection.PropertyInfo nameProperty = ex.GetType().GetProperty(propertyName);
            if (nameProperty == null || nameProperty.GetValue(ex) == null)
            {
                throw ex;
            }
            return nameProperty.GetValue(ex);
        }
    }
}
