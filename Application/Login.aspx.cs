using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Microsoft.SqlServer.Server;

namespace Application
{
    public partial class Login : System.Web.UI.Page
    {
        
        public string UserName;
        public string Password;
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.Items.Add("Admin");
            DropDownList1.Items.Add("Customer");

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string type = DropDownList1.Text.ToString();
           

            ClsMaster login = new ClsMaster(txtUseName.Text,txtpassword.Text,type);
            SqlDataReader dr;
            dr = login.Login();
            while (dr.Read())
            {
                type = dr["TypeName"].ToString();
                UserName = dr["UserName"].ToString();
                Password = dr["Password"].ToString();


            }
            if (txtUseName.Text== UserName && txtpassword.Text==Password)

            {
                Session["Type"] = type;
                Response.Redirect("Admin.aspx");



            }





            //    if (dr.HasRows == true)
            //    {
            //        if (type == "Admin")
            //        {
                        
            //            Response.Redirect("Admin.aspx");
                        
                        
                        
            //        }
            //    else if (type == "Custmer")
            //        {

            //            Response.Redirect("Customer.aspx");

            //        }



            //         }


                
           

            dr.Close();


            

















}
    }
}