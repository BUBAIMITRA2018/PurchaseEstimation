using Estimationtool.Models;
using EstimationTool.Models;
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
                server_dbname = "EstimationDB",
                server_name = "WAP101478",
                server_user = "Estimation",
                server_pass = "sms@123"
            };

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> users { get; set; }

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
