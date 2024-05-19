using Microsoft.EntityFrameworkCore;
using PracticumeServer.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumeServer.Data
{
    public class DataContext:DbContext
    {


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=127.0.0.1;Database=new_practicume_tbl;Uid=root;Pwd=Zz326617339!;Port=3306;", ServerVersion.Parse("8.0.28"));

        }


    }
}
