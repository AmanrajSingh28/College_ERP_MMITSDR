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
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public void getsession()
        {
            string id = Session["aid"] + "";
            if (id != "" && id != null)
            { 

            }
            else
            {
                Response.Redirect("/Home/Index");
            }
        }
        DatabaseManager db = new DatabaseManager();
        [HttpGet]
        public ActionResult Index()
        {
            getsession();
            string q = "select count(*) from students";
            int n = db.CountData(q);
            if (n >0) 
            {
                ViewBag.show = n;
            }
            else
            {
                ViewBag.show = "No student Record";   
            }
            //string p = "select count(*) from AddCourse";
            // int m = db.CountData(p);
            //if (m > 0)
            //{
               
            //   ViewBag.show2 = m;
            //}
            //else
            //{
            //    ViewBag.show2 = "No student Record";
            //}
            
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
        
        [HttpGet]
        public ActionResult Course(string year, string branch, string semester, string Roll)
        {
            getsession();
            string total = "";
          string cmd = "select * from Addcourse where year='"+year+"' and branch='"+branch+"'and semester='"+semester+"'";
          DataTable dt = db.GetAllRecord(cmd);
          if (dt.Rows.Count > 0)
          {
              for (int i = 0; i < dt.Rows.Count; i++)
               {
                  total += "<input type='checkbox' name='txtsubject' value='" + dt.Rows[i]["course"] + "'/>" + dt.Rows[i]["course"] + "<br>";
              }
              ViewBag.get += total;

          }
            ViewBag.sh = cmd;
            ViewBag.roll = Roll;
            return View();
        }
        [HttpPost]
       // public ActionResult Course(string Branch, string year, string txtsubject, string txtroll,string abbb)
       // {
       //     getsession();
       //     DatabaseManager db = new DatabaseManager();
       //    string qu = "update Students set subject='" + txtsubject + "' where RollNo='" + txtroll + "'";
       //    // string cmd = "update Students set subject='" + fc[0] + "' where RollNo='" + fc[1] + "'";
       //     if (db.InertUpdateAndDelete(qu) == true)
       //{
       //        Response.Write("<script>alert('Record seve')</script>");
       //     }
       //     else
       //    {
       //     Response.Write("<script>alert('Record not  seve')</script>");
       //     }
       //     return View();
       // }
        public ActionResult Course(FormCollection fc)
        {
            getsession();
           // string msg = "";
            string cmd = "update Students set subject='" + fc[0] + "' where RollNo='" + fc[1] + "'";
            if (db.InertUpdateAndDelete(cmd))
            {

                Response.Write("<script>alert('Subject Allot successfully');window.location.href='/Admin/Course'</script>");
            }
            //return Json(msg, JsonRequestBehavior.AllowGet);
            return View();
        }
        [HttpGet]
        public ActionResult Students()
        {
            getsession();
           
            return View();
        }
        [HttpPost]
        public ActionResult Students(string year,string Branch,string Rollno,string DOB,string FName,string Lname,string Email,string subject,string number,string State,string Gender,string Mothername,string Fathername,HttpPostedFileBase pic,string City,string sem)
        {
            getsession();
           
            string file = Path.Combine(Server.MapPath("~/Content/pic/"), pic.FileName);
            pic.SaveAs(file);
            DatabaseManager db = new DatabaseManager();
            string queary = "insert into Students values('" + year + "','" + Branch + "','" + Rollno + "','" + DOB + "','" + FName + "','" + Lname + "','" + Email + "',' "+subject+"','" + number + "','" + State + "','" + Gender + "','" + Mothername + "','" + Fathername + "','" + pic.FileName + "','" + City + "','"+sem+"','True')";
            string q2 = "insert into Login values('"+Email+"','"+Rollno+"','Student','True')  ";

            if (db.InertUpdateAndDelete(queary) && db.InertUpdateAndDelete(q2))  
            {
                Response.Write("<script>alert('Record seve')</script>");
            }
            else
            {
                Response.Write("<script>alert('Record not seve')</script>");
            }
           
            return View();
        }
        [HttpGet]
        public ActionResult Subject()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public ActionResult Subject(string year,string branch,string semester,string txtcourse)
        {
            getsession();
           
            string cmd = "select * from AddCourse where year='" + year + "' and branch='"+branch+"'and semester='"+semester+"'";
            DataTable dt=db.GetAllRecord(cmd);
        
                string sub="";
                for(int i=0;i<dt.Rows.Count;i++)
                {
                 sub=dt.Rows[i]["course"]+"";
                }
                if (txtcourse == sub)
                {
                    Response.Write("<script>alert('Subject Allready Exist')</script>");
                }
                else
                {
                    string cmd1 = "insert into AddCourse values('" + year + "','" + branch + "','" + semester + "','" + txtcourse + "','true')";
                    if (db.InertUpdateAndDelete(cmd1) == true)
                    {
                        Response.Write("<script>alert('Subject Saved')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Subject Not Saved')</script>");
                    }
                }
            
         
            return View();
        }
        [HttpGet]
        public ActionResult Faculties()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public ActionResult Faculties(string name, string Id, string State, string city, string Email, string Mob, string Quali, string Exp, string branch1, string DOB, string GENDER, string abc, string sub,string sem, string branch)
        {
            getsession();
            try
            {
                DatabaseManager db = new DatabaseManager();
                //string query1 = "insert into tbl_subjects values('" + sub + "','" + Id + "','" + sem + "','" + branch + "')";
                //string qu = "select * from tbl_subjects where teacherId='" + Id + "'and semester='" + sem + "'and branch='" + branch + "'and subject='" + sub + "'";
                //if (btn2 == "Assign")
                //{
                //    DataTable dt = db.GetAllRecord(qu);
                //    if (dt.Rows.Count > 0)
                //    { 
                //        Response.Write("<script>alert('subject is already Exist')</script>");
                //    }
                //    else
                //    {
                //        if (db.InertUpdateAndDelete(query1) == true)
                //        {
                //            Response.Write("<script>alert('subject assign succss')</script>");
                //        }
                //        else
                //        {
                //            Response.Write("<script>alert('Erorr')</script>");
                //        }
                //    }
                //}
                {
                    string queary = "insert into Faculties values('" + name + "','" + Id + "','" + State + "','" + city + "','" + Email + "','" + Mob + "','" + Quali + "','" + Exp + "','" + branch1 + "','" + DOB + "','" + GENDER + "','" + abc + "','" + sub + "',1)";
                    string q2 = "insert into Login values('" + Email + "','" + Id + "','Teacher','True')  ";
                    if (db.InertUpdateAndDelete(queary) && db.InertUpdateAndDelete(q2))
                    {
                        Response.Write("<script>alert('Record seve')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Record not seve')</script>");
                    }
                }
               
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Time_Table()
        {
            getsession();
            return View();
        }
        public ActionResult Users()
        {
            getsession();
            return View();
        }
        [HttpGet]
        public ActionResult Students_Fine()
        {
            getsession();
            return View();
        }
        [HttpPost]
        public ActionResult Students_Fine(string roll,string fine,string reson)
        {
            getsession();
            
            DatabaseManager db = new DatabaseManager();
            string queary = "insert into StudentFine values('" + roll + "','" + fine + "','" + reson + "',1)";
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
        //[HttpGet]
        //public ActionResult Project_Report()
        //{
        //    //getsession();
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Project_Report(string branch, string ptitle, string ptechnology ,HttpPostedFileBase preport)
        //{
        //    DatabaseManager db = new DatabaseManager();
        //    string path = Path.Combine(Server.MapPath("~/Content/pic"), preport.FileName);
        //    preport.SaveAs(path);
        //    string queary = "insert into ProjectReport values('" + branch + "','" + ptitle + "','" + ptechnology + "','" + preport.FileName + "',1)";
        //    if (db.InertUpdateAndDelete(queary) == true)
        //    {
        //        Response.Write("<script>alert('Record seve')</script>");
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Record  not seve')</script>");
        //    }
         
        //       return View();
        //}
        [HttpGet]
        public ActionResult Syllabus()
        {
            getsession();
            DatabaseManager db = new DatabaseManager();
            string cmd = "select *from Syllabus";
            DataTable dt = db.GetAllRecord(cmd);
            string type = "";
            string tbl = "<table id='example' class='display' style='width:100%;'>";
            tbl += "<thead><tr><th>Branch</th><th>year</th><th>Type</th><th>message</th><th>Syllabus</th></tr></thead>";
            tbl += "<tbody>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows.Count > 0)
                {
                    type = dt.Rows[i]["type"] + "";
                    if (type == "pdf" || type == "ppt")
                    {
                        tbl += "<tr><td>" + dt.Rows[i]["Branch"] + "</td><td>" + dt.Rows[i]["Year"] + "</td><td>" + dt.Rows[i]["type"] + "</td><td>" + dt.Rows[i]["Notic"] + "</td><td><a href='../Content/pic/" + dt.Rows[i]["File"] +"'><span class='fa fa-download' style='color:blue;'></span></a></td></tr>";
                    }
                }
            
            }
            tbl += "</tbody>";
            tbl += "</table>";
            ViewBag.file = tbl;
            return View();
        }
        [HttpPost]
        public ActionResult Syllabus(string Branch,string year,string type,string msg,HttpPostedFileBase pic)
        {
            getsession();
            DatabaseManager db = new DatabaseManager();
            string path = Path.Combine(Server.MapPath("~/content/pic"),pic.FileName);
            string queary = "insert into Syllabus values('" + Branch + "','" + year + "','"+type+"','"+msg+"','" + pic.FileName + "','"+DateTime.Now.ToString()+"',1)";
            if (db.InertUpdateAndDelete(queary) == true)
            {
                Response.Write("<script>alert('Record seve')</script>");
            }
            else
            {
                Response.Write("<script>alert('Record not seve')</script>");
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
            getsession();
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
       
        public ActionResult Assign_Subject()
        {
            getsession();
            return View();
        }
        public JsonResult Asign(string Branch)
        {
            getsession();
            string total = "";
            try
            {
                string msg = ""; 
                string cmd = "select * from Addcourse where branch='" + Branch + "'";
                DatabaseManager db = new DatabaseManager();
                DataTable dt = db.GetAllRecord(cmd);
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            total += "<input type='checkbox' name='txtsubject' value='" + dt.Rows[i]["course"] + "'/>" + dt.Rows[i]["course"] + "<br>";
                        }
                    }
                }
            }
            catch(Exception ex)
            { }
            return Json(total, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Allotsubject(string course,string id)
        {
            getsession();
            try
            {
                string total = "";
                string cmd = "select * from Addcourse where branch='" + course + "'";
                DatabaseManager db = new DatabaseManager();
                DataTable dt = db.GetAllRecord(cmd);
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            total += "<input type='checkbox' name='txtsubject' value='" + dt.Rows[i]["course"] + "'/>" + dt.Rows[i]["course"] + "<br>";
                        }
                        ViewBag.get += total;
                        
                    }
                }
                ViewBag.show = id;
            }
            catch (Exception ex)
            { }
            return View();
        }
        [HttpPost]
        public ActionResult Allotsubject(FormCollection fc)
        {
            getsession();
            string msg = "";
            string cmd = "update faculties set subject='" + fc[0] + "' where TeacherId='" + fc[1] + "'";
            if (db.InertUpdateAndDelete(cmd))
            {

                Response.Write("<script>alert('Subject Allot successfully');window.location.href='/Admin/AllotSubject'</script>");
            }
            //return Json(msg, JsonRequestBehavior.AllowGet);
            return View();
        }
        //public JsonResult Assign_Subject(string Branch, string Year, string Sem)
        //{

        //    string cmd = "select * from AddCourse where year='" + Year + "'and semester='" + Sem + "'and branch='" + Branch + "'";
        //    DataTable dt = db.GetAllRecord(cmd);
        //    string td = "";
        //    if (dt.Rows.Count > 0)
        //    {

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            td += "<input type='checkbox'name='" + dt.Rows[i]["subject"] + "'>'" + dt.Rows[i]["subject"] + "'";
        //        }

        //    }
        //    return Json("", JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult RollNo(string Branch,string Year )
        public JsonResult RollNo(string Branch,string year)
        {
            getsession();
            string  roll="";
            //string query = "select COUNT(*) from Course where Branch='"+Branch+"' and year='"+Year +"'";
            string query = "select COUNT(*) from Students where year='"+year+"' and Branch='"+Branch+"'";
            DatabaseManager db = new DatabaseManager();
            int n=db.CountData(query)+1;
            if (n>0 && n<=9)
            {
                roll = Branch + year + "00"+n;
            }
            else if(n>=10 && n<=99)
            {
                roll = Branch + year + "0" + n;
            }
            else
            {
                roll = Branch + year + "" + n;
            }
            return Json(roll, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]  
        public ActionResult blockuser( string blk)
        {
            getsession();
            string cmd = "update Login set Status='false' where password='"+blk+"' ";
            if (db.InertUpdateAndDelete(cmd)==true)
            {
                Response.Write("<script>alert('user block');window.location.href='/Admin/Users'</script>");
            }
            else
            {
                Response.Write("<script>alert('user not block');window.location.href='/Admin/Users'</script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult CountSubject()
        {
            getsession();
            return View();
        }
    }
}
 