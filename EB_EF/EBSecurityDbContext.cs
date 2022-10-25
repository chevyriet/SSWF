using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB_EF
{
    public class EBSecurityDbContext : IdentityDbContext
    {
        public EBSecurityDbContext(DbContextOptions<EBSecurityDbContext> options) : base(options)
        {

        }
    }
}
