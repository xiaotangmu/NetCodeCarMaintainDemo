using DAO.System;
using DateModel.System;
using Interface.System;
using Supervisor.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.System;

namespace BLL.System
{
    public class EmailTemplateSupervisor : BaseBLL, IEmailTemplateSupervisor
    {
        private readonly IEmailTemplateRepository _emailTemplateRepository;

        public EmailTemplateSupervisor(IEmailTemplateRepository emailTemplateRepository = null)
        {
            _emailTemplateRepository = InitDAO<EmailTemplateRepository>(emailTemplateRepository) as IEmailTemplateRepository;
        }

        public async Task<bool> Add(EmailTemplateInfoViewModel viewModel)
        {
            T_EMAIL_TEMPLATE entity = new T_EMAIL_TEMPLATE
            {
                BCC_NAME = viewModel.BCCUser,
                CC_NAME = viewModel.CCUser,
                CODE = viewModel.TemplateCode,
                CONTENT = viewModel.Content,
                OCD = DateTime.Now,
                NAME = viewModel.TemplateName,
                SUBJECT = viewModel.Subject,
                TO_NAME = viewModel.ToUser,
                LUD = DateTime.Now
            };
            await VerifyEnitty(entity);

            string id = await _emailTemplateRepository.Insert(entity);
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            return true;
        }

        private async Task VerifyEnitty(T_EMAIL_TEMPLATE entity)
        {
            if (string.IsNullOrEmpty(entity.CODE))
            {
                throw new Exception(await Localization.Localizer.GetValueAsync("請輸入模板編號"));
            }
            if (string.IsNullOrEmpty(entity.NAME))
            {
                throw new Exception(await Localization.Localizer.GetValueAsync("請輸入模板名稱"));
            }
        }

        public async Task<bool> Delete(EmailTemplateDeleteViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.TemplateCode))
            {
                throw new Exception(await Localization.Localizer.GetValueAsync("模板編號丟失，刪除失敗"));
            }
            return await _emailTemplateRepository.Delete(viewModel.TemplateCode);
        }

        public async Task<EmailTemplatePagingViewModel> QueryPageAsync(EmailTemplateSearchViewModel searchViewModel)
        {
            T_EMAIL_TEMPLATE entity = new T_EMAIL_TEMPLATE
            {
                CODE = searchViewModel.TemplateCode,
                NAME = searchViewModel.TemplateName
            };
            EmailTemplatePagingViewModel result = new EmailTemplatePagingViewModel();
            int totalCount = await _emailTemplateRepository.Count(entity);
            if (totalCount == 0)
            {
                return result;
            }
            result.TotalCount = totalCount;
            IEnumerable<T_EMAIL_TEMPLATE> entityGroup = await _emailTemplateRepository.GetGroupWithPaging(entity, searchViewModel.PageIndex, searchViewModel.PageSize);
            result.Group = BuildViewModelGroup(entityGroup);

            return result;
        }

        private IEnumerable<EmailTemplateInfoViewModel> BuildViewModelGroup(IEnumerable<T_EMAIL_TEMPLATE> entityGroup)
        {
            List<EmailTemplateInfoViewModel> viewModelGroup = new List<EmailTemplateInfoViewModel>();
            if (entityGroup == null)
            {
                return viewModelGroup;
            }
            foreach (T_EMAIL_TEMPLATE entity in entityGroup)
            {
                EmailTemplateInfoViewModel viewModel = new EmailTemplateInfoViewModel
                {
                    BCCUser = entity.BCC_NAME,
                    CCUser = entity.CC_NAME,
                    Content = entity.CONTENT,
                    Subject = entity.SUBJECT,
                    TemplateCode = entity.CODE,
                    TemplateName = entity.NAME,
                    ToUser = entity.TO_NAME
                };
                viewModelGroup.Add(viewModel);
            }
            return viewModelGroup;
        }

        public async Task<bool> Update(EmailTemplateInfoViewModel viewModel)
        {
            Dictionary<string, object> setting = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(viewModel.BCCUser))
            {
                setting.Add(T_EMAIL_TEMPLATE.FIELD_BCC_NAME, viewModel.BCCUser);
            }
            if (!string.IsNullOrEmpty(viewModel.CCUser))
            {
                setting.Add(T_EMAIL_TEMPLATE.FIELD_CC_NAME, viewModel.CCUser);
            }
            if (!string.IsNullOrEmpty(viewModel.Content))
            {
                setting.Add(T_EMAIL_TEMPLATE.FIELD_CONTENT, viewModel.Content);
            }
            if (!string.IsNullOrEmpty(viewModel.Subject))
            {
                setting.Add(T_EMAIL_TEMPLATE.FIELD_SUBJECT, viewModel.Subject);
            }
            if (!string.IsNullOrEmpty(viewModel.TemplateName))
            {
                setting.Add(T_EMAIL_TEMPLATE.FIELD_TO_NAME, viewModel.ToUser);
            }
            if (!string.IsNullOrEmpty(viewModel.ToUser))
            {
                setting.Add(T_EMAIL_TEMPLATE.FIELD_NAME, viewModel.TemplateName);
            }
            setting.Add(T_EMAIL_TEMPLATE.FIELD_LUD, DateTime.Now);
            Dictionary<string, object> where = new Dictionary<string, object>();
            if (string.IsNullOrEmpty(viewModel.TemplateCode))
            {
                throw new Exception(await Localization.Localizer.GetValueAsync("請選擇更新的模板"));
            }
            where.Add(T_EMAIL_TEMPLATE.FIELD_CODE, viewModel.TemplateCode);

            return await _emailTemplateRepository.Edit(setting, where);
        }
    }
}
