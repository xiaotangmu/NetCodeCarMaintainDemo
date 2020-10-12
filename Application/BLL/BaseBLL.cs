using Interface;
using DAO;

namespace BLL
{
    public class BaseBLL
    {
        public static readonly string DEFAULT_PARENT_CODE = "ROOT";

        protected IBaseRepository InitDAO<T>(IBaseRepository dao) where T : BaseDAO, new()
        {
            if (dao == null)
            {
                dao = new T();
            }
            return dao;
        }
    }
}