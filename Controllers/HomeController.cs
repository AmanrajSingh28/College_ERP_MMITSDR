using mycollage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;


namespace mycollage.Controllers
{
    public class HomeController : Controller
    {
       
        //
        // GET: /Home/
        DatabaseManager db = new DatabaseManager();
        SqlConnection con = new SqlConnection(@"Data Source=AYUSH-SINGH-CHA;Initial Catalog=Collegeerp;Integrated Security=True");
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Username,string password)
        {
            try
            {
                string query = "select type from Login where Username='" + Username + "'and password='" + password + "'and Status='True'";
                SqlDataAdapter sa = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sa.Fill(dt);
                {
                    if (dt.Rows.Count > 0)
                    {
                        string type = dt.Rows[0]["Type"] + "";
                        if (type == "Admin")
                        {
                            Session["aid"] = Username;
                            Response.Redirect("/Admin/Index");
                        }
                        else if (type == "Teacher")
                        {
                            Session["tid"] = Username;
                            Response.Redirect("/Teacher/Index");
                        }
                        else if (type == "Student")
                        {
                            Session["sid"] = Username;
                            Response.Redirect("/Student/Index");
                        }
                        else if (type == "Principle")
                        {
                            Session["pid"] = Username;
                            Response.Redirect("/principle/index");
                        }
                        else
                        {
                            Response.Write("invalid user");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Id or password not found");
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return View();
        }

    }
}
