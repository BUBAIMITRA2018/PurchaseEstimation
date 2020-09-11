using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace Estimationtool.Data
{
   public class DbConn : IDbConn
    {

        public string server_name { get; set; }
        public string server_user { get; set; }
        public string server_pass { get; set; }
        public string server_dbname { get; set; }


        private SqlConnection sqlconnection;


        public string GetConncetionString()
        {
            if ( string.IsNullOrEmpty(server_dbname) || string.IsNullOrEmpty(server_name)
                || string.IsNullOrEmpty(server_pass) || string.IsNullOrEmpty(server_user))


                {

                return "error";
            }

            string s = (@"Data Source =(local)\SQLEXPRESS; Initial Catalog = Estimation; User ID = sa; Password = sms@123; ");

            return s;

        }



        public SqlConnection connection
        {
            get
            {
                return new SqlConnection(GetConncetionString());
            }
        }





    }
}
