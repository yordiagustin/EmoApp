using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmoApp.Web.Models
{
    public class EmoEmotion
    {
        [Key]
        public int Id { get; set; }
        public float Score { get; set; }
        public int EmoFaceId { get; set; }
        public EmoEmotionEnum EmotionType { get; set; }

        public virtual EmoFace Face { get; set; }

    }
}