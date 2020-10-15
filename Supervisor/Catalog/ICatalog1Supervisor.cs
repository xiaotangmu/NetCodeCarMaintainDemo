using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace Supervisor.Catalog
{
    public interface ICatalog1Supervisor
    {
        Task<bool> Delete(Catalog1Model model);
        Task<bool> Update(Catalog1Model model);
        Task<IEnumerable<Catalog1Model>> GetAll();
        Task<string> Add(Catalog1AddModel model);
        Task<bool> AddBatch(IEnumerable<Catalog1AddModel> models);
        Task<bool> DeleteBatch(IEnumerable<Catalog1Model> models);
    }
}
