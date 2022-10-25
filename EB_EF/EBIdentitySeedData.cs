using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EB_EF
{
    public class EBIdentitySeedData : ISeedData
    {
        private readonly UserManager<IdentityUser> _userManager;

        public EBIdentitySeedData(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task EnsurePopulated(bool dropExisting = false)
        {
            const string CLAIMNAME_USERTYPE = "UserType";

            const string PASSWORD = "Secret123$";

            const string EMPLOYEENUMBER_EMPLOYEEUSER = "123456789";
            const string EMAIL_STUDENTUSER = "chevyriet040104@gmail.com";

            
            var existingUser = await _userManager.FindByNameAsync(EMPLOYEENUMBER_EMPLOYEEUSER);
            if (existingUser != null)
                await _userManager.DeleteAsync(existingUser);

            existingUser = await _userManager.FindByNameAsync(EMAIL_STUDENTUSER);
            if (existingUser != null)
                await _userManager.DeleteAsync(existingUser);
           
            IdentityUser employeeUser = await _userManager.FindByIdAsync(EMPLOYEENUMBER_EMPLOYEEUSER);
            if (employeeUser == null)
            {
                employeeUser = new IdentityUser(EMPLOYEENUMBER_EMPLOYEEUSER);

                await _userManager.CreateAsync(employeeUser, PASSWORD);
                await _userManager.AddClaimAsync(employeeUser, new Claim(CLAIMNAME_USERTYPE, "employeeuser"));
            }

            IdentityUser studentUser = await _userManager.FindByIdAsync(EMAIL_STUDENTUSER);
            if (studentUser == null)
            {
                studentUser = new IdentityUser(EMAIL_STUDENTUSER);

                await _userManager.CreateAsync(studentUser, PASSWORD);
                await _userManager.AddClaimAsync(studentUser, new Claim(CLAIMNAME_USERTYPE, "studentuser"));
            }

        }
    }
}
