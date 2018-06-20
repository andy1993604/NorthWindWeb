using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NorthWindWeb.Models
{
    public class Customer
    {
        [StringLength(5),Required]
        [Display(Name = "客戶編號")]
        public string CustomerID { get; set; }
        [StringLength(40),Required]
        [Display(Name = "公司名稱")]
        public string CompanyName { get; set; }
        [StringLength(30)]
        [Display(Name = "聯絡人姓名")]
        public string ContactName { get; set; }
        [StringLength(30)]
        [Display(Name = "聯絡人職稱")]
        public string ContactTitle { get; set; }
        [StringLength(60)]
        [Display(Name = "地址")]
        public string Address { get; set; }
        [StringLength(15)]
        [Display(Name = "城市")]
        public string City { get; set; }
        [StringLength(10)]
        [Display(Name = "地區")]
        public string Region { get; set; }
        [StringLength(15)]
        [Display(Name = "郵遞區號")]
        public string PostalCode { get; set; }
        [StringLength(15)]
        [Display(Name = "國家")]
        public string Country { get; set; }
        [StringLength(24)]
        [Display(Name = "電話號碼")]
        public string Phone { get; set; }
        [StringLength(24)]
        [Display(Name = "傳真號碼")]
        public string Fax { get; set; }
    }
}