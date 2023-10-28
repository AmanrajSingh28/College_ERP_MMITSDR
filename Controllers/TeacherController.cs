using mycollage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mycollage.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        DatabaseManager db = new DatabaseManager();
        public void getsession()
        {
            string id = Session["tid"] + "";
            if (id != "" && id != null)
            {

            }
            else
            {
                Response.Redirect("/Home/Index");
            }
        }
        [HttpGet]
        public ActionResult Index()
        {
            getsession();
            return View();
        }
        [HttpPost]
     public ActionResult Index(string type, string msg)
        {
            DatabaseManager db = new DatabaseManager();
            string queary = "insert into notification values('" + type + "','" + msg + "','" + DateTime.Now.ToString() + "',1)";
            if (db.InertUpdateAndDelete(queary) == true)
            {
                Response.Write("<script>alert('Record seve')</script>");
            }
            else
            {
                Response.Write("<script>alert('Record  not seve')</script>");
            }
            return View();
        }
  
       
        //public ActionResult Home()
        //{
        //    getsession();
        //    return View();
        //}
        public ActionResult My_Subject()
        {
            getsession();
            return View();
        }
        public ActionResult Internal_Mark()
        {
            getsession();
            return View();
        }
        public ActionResult Attendence()
        {
            getsession();
            return View();
        }
        [HttpGet]
        public ActionResult Assigement()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public ActionResult Assigement(string branch, string sem, string assignmentname, HttpPostedFileBase assignment)
        {
            DatabaseManager db = new DatabaseManager();
            string path = Path.Combine(Server.MapPath("~/Content/pic"), assignment.FileName);
            assignment.SaveAs(path);
            string queary = "insert into assigement values('" + branch + "','" + sem + "','" + assignmentname + "','" + assignment.FileName + "','" + DateTime.Now.ToString() + "')";
            if (db.InertUpdateAndDelete(queary) == true)
            {
                Response.Write("<script>alert('Record seve')</script>");
            }
            else
            {
                Response.Write("<script>alert('Record  not seve')</script>");
            }
            getsession();
            return View();
        }
        [HttpGet]
        public ActionResult Time_Table()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public ActionResult Time_Table(string branch,string sem,HttpPostedFileBase timetable)
        {
            DatabaseManager db = new DatabaseManager();
            string path = Path.Combine(Server.MapPath("~/Content/pic"),timetable .FileName);
            timetable.SaveAs(path);
            string queary = "insert into tbl_TimeTable values('" + branch + "','" + sem + "','" + timetable.FileName + "','" + DateTime.Now.ToString() + "')";
            if (db.InertUpdateAndDelete(queary) == true)
            {
                Response.Write("<script>alert('Record seve')</script>");
            }
            else
            {
                Response.Write("<script>alert('Record  not seve')</script>");
            }
            getsession();
            return View();
        }
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
        [HttpGet]
        public ActionResult Change_Password()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public ActionResult Change_Password(string newPass, string oldPass)
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
        public ActionResult Student_Fine()
        {
            getsession();
            return View();
        }
        [HttpGet]
        public ActionResult Upload_Project_Report()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public ActionResult Upload_Project_Report(string branch, string ptitle, string ptechnology, HttpPostedFileBase preport)
        {
            DatabaseManager db = new DatabaseManager();
            string path = Path.Combine(Server.MapPath("~/Content/pic"), preport.FileName);
            preport.SaveAs(path);
            string queary = "insert into ProjectReport values('" + branch + "','" + ptitle + "','" + ptechnology + "','" + preport.FileName + "',1)";
            if (db.InertUpdateAndDelete(queary) == true)
            {
                Response.Write("<script>alert('Record seve')</script>");
            }
            else
            {
                Response.Write("<script>alert('Record  not seve')</script>");
            }

            return View();
        }

    }
}
