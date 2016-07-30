﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ZxaUmbraco.Models
{
    public class ContactModel
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public IEnumerable<SelectListItem> ListOfGenders { get; set; }
        public string SelectedGender { get; set; }
    }
}