using Supervisor.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Client;

namespace BLL.Client
{
    public class ClientSupervisor : BaseBLL, IClientSupervisor
    {
        public Task<bool> Add(ClientViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string addressCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ClientViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
