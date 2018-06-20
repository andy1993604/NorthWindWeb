//using Newtonsoft.Json.Linq;
//using NorthWindWeb.Models;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Security;

//namespace NorthWindWeb.Controllers
//{
//    public class testController : Controller
//    {
//        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\芮君\source\repos\NorthWindWeb\NorthWindWeb\App_Data\northwnd.mdf;Integrated Security = True";
//        // GET: User
//        [Authorize]
//        public ActionResult Index()
//        {
//            var UserData = JObject.Parse(((FormsIdentity)User.Identity).Ticket.UserData);
//            return Content(String.Format("<H2>Hello {0}!!!</H2>", (String)UserData["UserName"]));
//        }
//        public ActionResult Login(String UserID = "", String Password = "", Boolean IsPersistent = false, String ReturnUrl = "Index")
//        {
//            #region 取得資料
//            //新增一個DataTable資料容器
//            DataTable dt = new DataTable();
//            //建立資料庫連結
//            SqlConnection conn = new SqlConnection(connStr);
//            //撰寫SQL語法
//            SqlCommand cmd = new SqlCommand("select * from UserProfile", conn);
//            //打開資料庫連結
//            conn.Open();
//            //建立資料讀取器
//            SqlDataAdapter ad = new SqlDataAdapter(cmd);
//            //將讀取的資料放入DataTable
//            ad.Fill(dt);
//            List<CheckUserData> listProd = new List<CheckUserData>();
//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                CheckUserData prodUserdata = new CheckUserData();
//                prodUserdata.UserID = dt.Rows[i]["UserID"].ToString();
//                prodUserdata.UserName = dt.Rows[i]["UserName"].ToString();
//                prodUserdata.Password = dt.Rows[i]["Password"].ToString();
//                listProd.Add(prodUserdata);

//                string UserData = JObject.FromObject(new { UserName = dt.Rows[i]["UserName"].ToString(), Age = 25 }).ToString();
//                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, UserID,
//                     DateTime.Now, DateTime.Now.AddMinutes(30), IsPersistent,
//                     UserData, FormsAuthentication.FormsCookiePath);
//                if (String.IsNullOrEmpty(Request.Form.Get("SignIn")))
//                {
//                    return View();
//                }
//                else
//                {
//                    if (UserID.Equals(dt.Rows[i]["UserID"].ToString()) && Password.Equals(dt.Rows[i]["Password"].ToString()))
//                    {
//                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
//                        if (IsPersistent)
//                        {
//                            cookie.Expires = DateTime.Now.AddYears(1);
//                        }
//                        Response.Cookies.Add(cookie);
//                    }
//                    return Redirect(ReturnUrl);
//                }

//            }
//            return Redirect(ReturnUrl);
//        }
//        public ActionResult Logout()
//        {


//            return View();
//        }
//    }
//}