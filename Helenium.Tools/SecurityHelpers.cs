using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace Helenium.Tools
{
    /// <summary>
    /// Security Helpers.
    /// </summary>
    public class SecurityHelpers
    {

        /// <summary>
        /// Users is in system role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public static bool UserInSystemRole(WindowsBuiltInRole role)
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(role);
        }

        /// <summary>
        /// Users is in custom role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public static bool UserInCustomRole(string role)
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(role);
        }
    }
}
