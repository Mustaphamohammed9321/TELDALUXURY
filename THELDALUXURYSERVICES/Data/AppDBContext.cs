using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYECOMMERCE.Models;

namespace THELDALUXURYECOMMERCE.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<tb_State> states { get; set; }
        public DbSet<AdminUserModel> adminusers { get; set; } 

    }
}
