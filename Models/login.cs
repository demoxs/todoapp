using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace todoapp.Models
{
    public class login
    {
        [Required(ErrorMessage = "Please seT USERNAME .")]
        public string username { get; set; }
        [Required(ErrorMessage = "Please seT PASSWORD.")]
        public string password { get; set; }
        [Required(ErrorMessage = "Please select a role.")]
        public string roletype { get; set; }
        public List<SelectListItem> role { get; set; }
    }
    public class role
    {
        public string rolename { get; set; }
        public string rolevale { get; set; }
    }
}