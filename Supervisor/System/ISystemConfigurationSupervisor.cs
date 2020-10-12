using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.System;

namespace Supervisor.System
{
    public interface ISystemConfigurationSupervisor : IBaseSupervisor
    {
        Task<SystemConfigurationViewModel> GetParameterGroup();
        Task<bool> Save(SystemConfigurationViewModel viewModel);
    }
}
