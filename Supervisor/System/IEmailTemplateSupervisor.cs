using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.System;

namespace Supervisor.System
{
    public interface IEmailTemplateSupervisor : IBaseSupervisor
    {
        Task<bool> Add(EmailTemplateInfoViewModel viewModel);

        Task<bool> Update(EmailTemplateInfoViewModel viewModel);

        Task<bool> Delete(EmailTemplateDeleteViewModel viewModel);

        Task<EmailTemplatePagingViewModel> QueryPageAsync(EmailTemplateSearchViewModel searchViewModel);
    }
}
