using Estimationtool.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estimationtool.Data
{
    public class DataAcess : DbContext
    {
        private IDbConn dbcom;

        public DataAcess()
        {
            dbcom = new DbConn
            {
                server_dbname = "Estimation",
                server_name = "192.168.56.1",
                server_user = "sa",
                server_pass = "sms@123"
            };

        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbcom.connection);

            //if (!optionsBuilder.IsConfigured)
            //{

            //    optionsBuilder.UseSqlServer(dbcom.connection);
            //}
        }

    }
}
