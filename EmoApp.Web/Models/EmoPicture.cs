using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmoApp.Web.Models
{
    public class EmoPicture
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "No se permiten más de 300 caracteres")]
        public string Path { get; set; }

        public virtual ObservableCollection<EmoFace> Faces { get; set; }
    }
}