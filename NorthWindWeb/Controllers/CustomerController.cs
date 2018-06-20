using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthWindWeb.Models;
using Newtonsoft.Json;
using System.Web.Http;

namespace NorthWindWeb.Controllers
{
    
    public class CustomerController : Controller
    {
        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\芮君\source\repos\NorthWindWeb\NorthWindWeb\App_Data\northwnd.mdf;Integrated Security = True";
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        public JsonResult Add([FromBody]Customer AddCus)
        {
            if(ModelState.IsValid && !String.IsNullOrEmpty(AddCus.CustomerID) && !String.IsNullOrEmpty(AddCus.CompanyName))
            {
                string addnull = "nadd";
                string pk = "pk";
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(@"insert into Customers(CustomerID, 
                                                                                                                    CompanyName,
                                                                                                                    ContactName,
                                                                                                                    ContactTitle,
                                                                                                                    Address,
                                                                                                                    City,Region,
                                                                                                                    PostalCode,
                                                                                                                    Country,
                                                                                                                    Phone,
                                                                                                                    Fax)
                                                                                                          values(@CustomerID,
                                                                                                                    @CompanyName,
                                                                                                                    @ContactName,
                                                                                                                    @ContactTitle,
                                                                                                                    @Address,
                                                                                                                    @City,
                                                                                                                    @Region,
                                                                                                                    @PostalCode,
                                                                                                                    @Country,
                                                                                                                    @Phone,
                                                                                                                    @Fax)", conn);
                cmd.Parameters.Add(new SqlParameter("@CustomerID", AddCus.CustomerID ?? pk));
                cmd.Parameters.Add(new SqlParameter("@CompanyName", AddCus.CompanyName ?? addnull));
                cmd.Parameters.Add(new SqlParameter("@ContactName", (object)AddCus.ContactName ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@ContactTitle", (object)AddCus.ContactTitle ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Address", (object)AddCus.Address ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@City", (object)AddCus.City ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Region", (object)AddCus.Region ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@PostalCode", (object)AddCus.PostalCode ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Country", (object)AddCus.Country ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Phone", (object)AddCus.Phone ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Fax", (object)AddCus.Fax ?? DBNull.Value));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                return Json(new {staus="新增失敗"});
            }

            return Json(new { staus="新增成功"});
        }
        public ActionResult Edit()
        {

            return View();
        }
        public ActionResult Insert()
        {
         
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        public JsonResult Query(Customer cus)
        {
            //新增一個DataTable資料容器
            DataTable dt = new DataTable();
            //建立資料庫連結
            SqlConnection conn = new SqlConnection(connStr);
            //撰寫SQL語法
            //SqlCommand cmd = new SqlCommand(@"select*from Customers where (datalength(@CustomerID) = 0 or  CustomerID=@CustomerID)", conn);
            SqlCommand cmd = new SqlCommand(@"select*from Customers where (@CustomerID is null or  CustomerID=@CustomerID)", conn);
            //SqlCommand cmd = new SqlCommand(@"select*from Customers where CustomerID=@CustomerID 
            //                                                                                                               and CompanyName=@CompanyName 
            //                                                                                                               and ContactTitle=@ContactTitle 
            //                                                                                                               and Address=@Address 
            //                                                                                                               and City=@City 
            //                                                                                                               and Region=@Region 
            //                                                                                                               and Country=@Country 
            //                                                                                                               and Phone=@Phone 
            //                                                                                                               and Fax=@Fax", conn);
            //cmd.Parameters.Add(new SqlParameter("@CustomerID", cus.CustomerID??DBNull.Value.ToString()));
            cmd.Parameters.Add(new SqlParameter("@CustomerID", (object)cus.CustomerID ?? DBNull.Value));
            //cmd.Parameters.Add(new SqlParameter("@CompanyName", cus.CompanyName));
            //cmd.Parameters.Add(new SqlParameter("@ContactTitle", cus.ContactTitle));
            //cmd.Parameters.Add(new SqlParameter("@Address", cus.Address));
            //cmd.Parameters.Add(new SqlParameter("@City", cus.City));
            //cmd.Parameters.Add(new SqlParameter("@Region", cus.Region));
            //cmd.Parameters.Add(new SqlParameter("@Country", cus.Country));
            //cmd.Parameters.Add(new SqlParameter("@Phone", cus.Phone));
            //cmd.Parameters.Add(new SqlParameter("@Fax", cus.Fax));
            //打開資料庫連結
            conn.Open();
            //建立資料讀取器
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //將讀取的資料放入DataTable
            ad.Fill(dt);
          
            List<Customer> getCustomerList = new List<Customer>();
                  {
                for (int i = 0; i< dt.Rows.Count; i++)
                {
                    Customer prodBasic = new Customer();
                    prodBasic.CustomerID = dt.Rows[i]["CustomerID"].ToString();
                    prodBasic.CompanyName = dt.Rows[i]["CompanyName"].ToString();
                    prodBasic.ContactName = dt.Rows[i]["ContactName"].ToString();
                    prodBasic.ContactTitle =dt.Rows[i]["ContactTitle"].ToString();
                    prodBasic.Address = dt.Rows[i]["Address"].ToString();
                    prodBasic.City = dt.Rows[i]["City"].ToString();
                    prodBasic.Region =dt.Rows[i]["Region"].ToString();
                    prodBasic.Country = dt.Rows[i]["Country"].ToString();
                    prodBasic.Phone = dt.Rows[i]["Phone"].ToString();
                    prodBasic.Fax =dt.Rows[i]["Fax"].ToString();


                    getCustomerList.Add(prodBasic);
                }
            }
            return Json(getCustomerList);
        }
    }
}