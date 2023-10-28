using mycollage.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace mycollage.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        DatabaseManager db = new DatabaseManager();
        string id = "";
        public void getsession()
        {
            id = Session["sid"] + "";
            if(id!="" && id!=null)
            {

            }
            else
            {
                Response.Redirect("/Home/Index");
            }
        }
        public ActionResult Index()
        {
            getsession();
            return View();
        }
        public ActionResult Home()
        {
            getsession();
            return View();
        }
        public ActionResult My_Subject ()
        {
            getsession();
            return View();
        }
        public ActionResult My_Faculties()
        {
            getsession();
            return View();
        }
        public ActionResult Time_Table()
        {
            getsession();
            return View();
        }
        [HttpGet]
        public ActionResult Change_Password()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public ActionResult Change_Password(string newPass,string oldPass)
        {
            if (oldPass != "" && oldPass != null)
            {
                string pass = "";
                string q = "select Password from Login where Password='" + oldPass + "'";
                //  SqlCommand cmd = new SqlCommand(q, con);
                DataTable dt = db.GetAllRecord(q);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; dt.Rows.Count > i; i++)
                    {
                        pass = dt.Rows[i]["Password"] + "";
                    }
                }
                if (oldPass == pass)
                {
                    string cmd = "update Login set password='" + newPass + "' where password='" + oldPass + "'";
                    if (db.InertUpdateAndDelete(cmd) == true)
                    {
                        Response.Write("<script>alert('Password Changed')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Password Not Change')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Password Not Match')</script>");
                }
            }
            
            getsession();
            return View();
        }
        public ActionResult Marks()
        {
            getsession();
            return View();
        }
      
        public ActionResult Fine()
        {
            getsession();
            return View();
        }
        public ActionResult Assignments()
        {
            getsession();
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("/Home/Index");
            return View();
        }
        [HttpPost]
        public ActionResult Logout(string cmd)
        {
           
            return View();
        }


    }
}
