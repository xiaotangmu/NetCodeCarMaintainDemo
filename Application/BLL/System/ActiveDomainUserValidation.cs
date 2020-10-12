using DataModel.System;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace BLL.System
{
    public class ActiveDomainUserValidation
    {
        public static CurrentUserInfo GenerateActiveDomainUser(string userName, string password, string domainName)
        {
            if (ValidAactiveDomainUser(userName, password, domainName))
            {
                return new CurrentUserInfo
                {
                    Name = userName,
                    UserType = UserType.USER
                };
            }
            return null;
        }

        private static bool ValidAactiveDomainUser(string userName, string password, string domainName)
        {
            PrincipalContext adContext = new PrincipalContext(ContextType.Domain, domainName);
            using (adContext)
            {
                if (adContext.ValidateCredentials(userName, password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
