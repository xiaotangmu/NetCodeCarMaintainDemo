
using System.Threading.Tasks;
using ViewModel.Client;

namespace Supervisor.Client
{
    /// <summary>
    /// </summary>
    public interface IClientSupervisor: IBaseSupervisor
    {
        Task<bool> Add(ClientViewModel viewModel);

        Task<bool> Update(ClientViewModel viewModel);

        Task<bool> Delete(string addressCode);
    }
}
