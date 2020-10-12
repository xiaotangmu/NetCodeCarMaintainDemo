using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.System
{
    public class SystemConfigurationViewModel
    {
        public string NewStudentApplicationStartDate { get; set; }
        public string NewStudentApplicationEndDate { get; set; }
        public string OldStudentApplicationStartDate { get; set; }
        public string OldStudentApplicationEndDate { get; set; }
        public string FirstSemesterCheckOutDate { get; set; }
        public string SecondSemesterCheckOutDate { get; set; }
        public string CredentialUserName { get; set; }
        public string CredentialUserPwd { get; set; }
        public string FromEmail { get; set; }
        public string EmailDomain { get; set; }
    }
}
