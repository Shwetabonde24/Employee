using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = Session["Type"].ToString();

            
            ClsMaster objdata = new ClsMaster();
            if (s =="Admin")
            {
                DataTable dt = new DataTable();
                dt = objdata.AdminDetails();
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            else if (s== "Custmer")
            {
                DataTable dt = new DataTable();
                dt = objdata.AdminDetails();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {

                    GridView1.HeaderRow.Cells[4].Visible = false;
                    GridView1.Rows[i].Cells[4].Visible = false;

                }



            }




            //DataTable dt = new DataTable();
            // dt= objdata.AdminDetails();
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}