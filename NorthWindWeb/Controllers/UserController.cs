using Newtonsoft.Json.Linq;
using NorthWindWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace NorthWindWeb.Controllers
{
    public class UserController : Controller
    {
        UserLogin m = new UserLogin();
        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\芮君\source\repos\NorthWindWeb\NorthWindWeb\App_Data\northwnd.mdf;Integrated Security = True";

        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            var UserData = JObject.Parse(((FormsIdentity)User.Identity).Ticket.UserData);
            ViewBag.UserName = (String)UserData["UserName"];
            return View();


        }
        public ActionResult Login(String UserID= "" , String Password = "", Boolean IsPersistent = false, String ReturnUrl = "Index")
        {
            if (!String.IsNullOrEmpty(Request.Form.Get("SignIn")))
            {
                //新增一個DataTable資料容器
                DataTable dt = new DataTable();
                //建立資料庫連結
                SqlConnection conn = new SqlConnection(connStr);
                //撰寫SQL語法
                SqlCommand cmd = new SqlCommand(@"select Username from UserProfile where UserID=@UserID and Password=@Password", conn);
                cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmd.Parameters.Add(new SqlParameter("@Password", Password));
                cmd.Parameters.Add(new SqlParameter("@IsPersistent", IsPersistent));
                //打開資料庫連結
                conn.Open();
                //建立資料讀取器
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                //將讀取的資料放入DataTable
                ad.Fill(dt);
                if (ModelState.IsValid && dt.Rows.Count > 0 && UserID.Length > 0 && Password.Length > 0)
                {
                    String Username2 = dt.Rows[0][0].ToString();
                    string UserData = JObject.FromObject(new { UserName = Username2, Age = 18 }).ToString();

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, UserID,
                            DateTime.Now, DateTime.Now.AddMinutes(30), IsPersistent,
                            UserData, FormsAuthentication.FormsCookiePath);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    if (IsPersistent)
                    {
                        cookie.Expires = DateTime.Now.AddYears(1);
                    }
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    ModelState.AddModelError(
                        "Password", "您輸入的帳號或密碼錯誤,請重新輸入!"
                        );
                    if (!ModelState.IsValidField("Password"))
                    {
                        var emptyValue = new ValueProviderResult(
                            string.Empty,
                            string.Empty,
                            System.Globalization.CultureInfo.CurrentCulture);

                        ModelState.SetModelValue(
                            "Password",
                            emptyValue);
                    }
                    return View(m);
                }
                return Redirect(ReturnUrl);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");   
        }
    }
}