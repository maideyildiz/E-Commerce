using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using E_Commerce.App.AdminPage.Models;

namespace E_Commerce.App.AdminPage.Data
{
    public class E_CommerceAppAdminPageContext : DbContext
    {
        public E_CommerceAppAdminPageContext (DbContextOptions<E_CommerceAppAdminPageContext> options)
            : base(options)
        {
        }

        public DbSet<E_Commerce.App.AdminPage.Models.CategoryViewModel> CategoryViewModel { get; set; }
    }
}
