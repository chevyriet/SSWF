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

            const string EMPLOYEENUMBER_EMPLOYEEUSERBRAM = "987654321";
            const string EMPLOYEENUMBER_EMPLOYEEUSERJAN = "123456789";

            const string EMAIL_STUDENTUSERCHEVY = "chevy@gmail.com";
            const string EMAIL_STUDENTUSERFRANK = "frank@gmail.com";

            var existingUser = await _userManager.FindByNameAsync(EMPLOYEENUMBER_EMPLOYEEUSERJAN);
            if (existingUser != null)
                await _userManager.DeleteAsync(existingUser);

            existingUser = await _userManager.FindByNameAsync(EMAIL_STUDENTUSERCHEVY);
            if (existingUser != null)
                await _userManager.DeleteAsync(existingUser);

            existingUser = await _userManager.FindByNameAsync(EMPLOYEENUMBER_EMPLOYEEUSERBRAM);
            if (existingUser != null)
                await _userManager.DeleteAsync(existingUser);

            existingUser = await _userManager.FindByNameAsync(EMAIL_STUDENTUSERFRANK);
            if (existingUser != null)
                await _userManager.DeleteAsync(existingUser);

            IdentityUser employeeUser = await _userManager.FindByIdAsync(EMPLOYEENUMBER_EMPLOYEEUSERJAN);
            if (employeeUser == null)
            {
                employeeUser = new IdentityUser(EMPLOYEENUMBER_EMPLOYEEUSERJAN);

                await _userManager.CreateAsync(employeeUser, PASSWORD);
                await _userManager.AddClaimAsync(employeeUser, new Claim(CLAIMNAME_USERTYPE, "employeeuser"));
            }

            IdentityUser studentUser = await _userManager.FindByIdAsync(EMAIL_STUDENTUSERCHEVY);
            if (studentUser == null)
            {
                studentUser = new IdentityUser(EMAIL_STUDENTUSERCHEVY);

                await _userManager.CreateAsync(studentUser, PASSWORD);
                await _userManager.AddClaimAsync(studentUser, new Claim(CLAIMNAME_USERTYPE, "studentuser"));
            }

            IdentityUser employeeUser2 = await _userManager.FindByIdAsync(EMPLOYEENUMBER_EMPLOYEEUSERBRAM);
            if (employeeUser2 == null)
            {
                employeeUser2 = new IdentityUser(EMPLOYEENUMBER_EMPLOYEEUSERBRAM);

                await _userManager.CreateAsync(employeeUser2, PASSWORD);
                await _userManager.AddClaimAsync(employeeUser2, new Claim(CLAIMNAME_USERTYPE, "employeeuser"));
            }

            IdentityUser studentUser2 = await _userManager.FindByIdAsync(EMAIL_STUDENTUSERFRANK);
            if (studentUser2 == null)
            {
                studentUser2 = new IdentityUser(EMAIL_STUDENTUSERFRANK);

                await _userManager.CreateAsync(studentUser2, PASSWORD);
                await _userManager.AddClaimAsync(studentUser2, new Claim(CLAIMNAME_USERTYPE, "studentuser"));
            }

        }
    }
}
