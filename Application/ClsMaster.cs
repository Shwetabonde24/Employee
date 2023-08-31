using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application
{
    public class ClsMaster
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3151QSI;Initial Catalog=Management;Integrated Security=True");

        public string UserName { get; set; }
        public string Password { get; set; }
        public string TypeName { get; set; }
        public ClsMaster(string userName, string Pass, string type)
        {
            UserName = userName;
            Password = Pass;
            TypeName = type;

        }

        public ClsMaster()
        {
        }

        //Login Function
        public SqlDataReader Login()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Masteradmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Login");
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@TypeName", TypeName);
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }


        public DataTable AdminDetails()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Masteradmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AdminDetails");
            SqlDataAdapter adpt1 = new SqlDataAdapter();
            adpt1.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adpt1.Fill(dt);
            return dt;
            con.Close();



        }
        public DataTable Custumberdetails()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Masteradmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "custumer");
            SqlDataAdapter adpt1 = new SqlDataAdapter();
            adpt1.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adpt1.Fill(dt);
            return dt;
            con.Close();



        }























    }
}