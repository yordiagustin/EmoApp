﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmoApp.Web.Models
{
    public class Home
    {
        public int Id { get; set; }
        public string WelcomeMessage { get; set; }
        public string FooterMessage { get; set; } = "See in www.yordiap.com";
    }

}