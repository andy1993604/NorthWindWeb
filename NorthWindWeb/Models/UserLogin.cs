using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NorthWindWeb.Models
{
    public class UserLogin
    {
        [Required]
        [Display(Name = "帳號")]
        [DataType(DataType.Text)]
        public String UserID { get; set; }
        [Required]
        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Display(Name = "保持登入狀態")]
        public bool IsPersistent { get; set; }
    }
}