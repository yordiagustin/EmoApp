﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmoApp.Web.Models
{
    public class EmoAppWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EmoAppWebContext() : base("name=EmoAppWebContext")
        {
        }

        public DbSet<EmoPicture> EmoPictures { get; set; }

        public DbSet<EmoFace> EmoFaces { get; set; }

        public DbSet<EmoEmotion> EmoEmotions { get; set; }

        public DbSet<Home> Homes { get; set; }
    }
}
