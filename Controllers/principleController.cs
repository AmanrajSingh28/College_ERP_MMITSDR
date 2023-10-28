using mycollage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mycollage.Controllers
{
    public class principleController : Controller
    {
        //
        // GET: /principle/
        public void getsession()
        {
            string id = Session["pid"] + "";
            if (id != "" && id != null)
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
        public ActionResult view_Course()
        {
            getsession();
            return View();
        }
        public ActionResult view_Students()
        {
            getsession();
            return View();
        }
        public ActionResult view_Faculties()
        {
            getsession();
            return View();
        }
        public ActionResult view_Time_Table()
        {
            getsession(); getsession();
            return View();
        }
        [HttpGet]
        public ActionResult Project_Report()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public ActionResult Project_Report(string branch, string ptitle, string ptechnology)
        {
            DatabaseManager db = new DatabaseManager();
            string queary = "insert into ProjectReport values('" + branch + "','" + ptitle + "','" + ptechnology + "',1)";
            if (db.InertUpdateAndDelete(queary) == true)
            {
                Response.Write("<script>alert('Record seve')</script>");
            }
            else
            {
                Response.Write("<script>alert('Record seve')</script>");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Change_Password()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public ActionResult Change_Password(string newPass, string oldPass)
        {
            DatabaseManager db = new DatabaseManager();
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
                        Response.Write("<script>alert('Password Changed');window.location.href='/Home/Index'</script>");
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
