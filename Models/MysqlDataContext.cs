using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.Models
{
    public class MysqlDataContext : DbContext
    {
        public DbSet<User> User { get; set; }
       // public DbSet<SP_T_BASE_MENU> Menu { get; set; }

        public MysqlDataContext(DbContextOptions<MysqlDataContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"");
            //去NuGet逛逛，搜索mysql官方出的驱动包 MySql.Data.EntityFrameworkCore
            //optionsBuilder.UseMySQL(@"Server=127.0.0.1;Database=test; User ID=root;Password=AT*-=uik123;port=3306;CharSet=utf8;pooling=true;");

            optionsBuilder.UseMySQL(@"Server=172.18.15.39;Database=test; User ID=root;Password=AT*-=uik123;port=3306;CharSet=utf8;pooling=true;");
  //          optionsBuilder.UseOracle(@"User Id=ADMIN_PERFORMANCE;Password=ADMIN_PERFORMANCE;Data Source=
  //(DESCRIPTION =
  //  (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.7.101)(PORT = 1521))
  //  (CONNECT_DATA =  
  //    (SERVER = DEDICATED)
  //    (SERVICE_NAME = orcl)
  //  )
  //)");
        }
    }
}
