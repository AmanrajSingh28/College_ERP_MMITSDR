using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace mycollage.Models
{
    public   class DatabaseManager
    {
        SqlConnection con = new SqlConnection(@"Data Source=AYUSH-SINGH-CHA;Initial Catalog=Collegeerp;Integrated Security=True");
       public bool InertUpdateAndDelete(string command)
        {
            SqlCommand cmd2 = new SqlCommand(command, con);
           if(con.State!=ConnectionState.Open)
           {
               con.Open();
           }
           int n = cmd2.ExecuteNonQuery();
           if(n>0)
           {
               return true;
           }
           else
           {
               return false;
           }
        }
        public DataTable GetAllRecord(string command)
       {
           SqlDataAdapter sa = new SqlDataAdapter(command, con);
           DataTable dt = new DataTable();
           sa.Fill(dt);
           return dt;
       }

       public int CountData(string command)
        {
            SqlCommand cmd = new SqlCommand(command,con);
            con.Open();
            int n = Convert.ToInt32(cmd.ExecuteScalar());
           if(n>0)
           {
               return n;
           }
           else
           {
               return 0;
           }
        }
    }
}
