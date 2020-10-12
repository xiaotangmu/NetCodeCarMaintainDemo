using ORM;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Interface
{
    public interface IBaseRepository
    {
        IDataRepository Repository { get; set; }
    }
}
