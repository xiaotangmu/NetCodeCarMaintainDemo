using DateModel.System;
using Interface.System;
using Supervisor.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ViewModel.System;

namespace BLL.System
{
    public class SystemConfigurationSupervisor : BaseBLL, ISystemConfigurationSupervisor
    {
        private readonly ISystemConfigurationRepository _systemConfigurationRepository;

        public SystemConfigurationSupervisor(ISystemConfigurationRepository systemConfigurationRepository = null)
        {
            _systemConfigurationRepository = systemConfigurationRepository;
        }

        public async Task<SystemConfigurationViewModel> GetParameterGroup()
        {
            SystemConfigurationViewModel configEntity = new SystemConfigurationViewModel();
            PropertyInfo[] properties = configEntity.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property == null)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(property.Name))
                {
                    continue;
                }
                T_SYSTEM_CONFIGURATION config = await _systemConfigurationRepository.GetAsync(property.Name);
                if (config == null)
                {
                    continue;
                }
                property.SetValue(configEntity, config.CONFIG_VALUE);
            }
            return configEntity;
        }

        public async Task<bool> Save(SystemConfigurationViewModel viewModel)
        {
            return await _systemConfigurationRepository.Repository.DbSession.TransactionHandle(async transaction =>
            {
                bool isSuccessful = await _systemConfigurationRepository.Clear(transaction);
                if (isSuccessful)
                {
                    isSuccessful = await InitConfiguration(viewModel, transaction);
                }
                return isSuccessful;
            });
        }

        private async Task<bool> InitConfiguration(SystemConfigurationViewModel viewModel, IDbTransaction transaction)
        {
            bool isSuccessful = true;
            PropertyInfo[] properties = viewModel.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property == null)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(property.Name))
                {
                    continue;
                }
                T_SYSTEM_CONFIGURATION config = new T_SYSTEM_CONFIGURATION
                {
                    CONFIG_CODE = property.Name,
                    CONFIG_VALUE = property.GetValue(viewModel).ToString(),
                    OCD = DateTime.Now,
                    LUD = DateTime.Now
                };
                string result = await _systemConfigurationRepository.AddAsync(config, transaction);
                if (string.IsNullOrEmpty(result))
                {
                    isSuccessful = false;
                }
            }
            return isSuccessful;
        }
    }
}
