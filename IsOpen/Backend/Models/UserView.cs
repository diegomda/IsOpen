﻿using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    [NotMapped]

    public class UserView : User
    {
        [Display(Name= "Foto")]
        public HttpPostedFileBase LogoFile { get; set; }

    }
}