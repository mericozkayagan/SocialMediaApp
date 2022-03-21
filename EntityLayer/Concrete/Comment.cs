﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int? UserId { get; set; }        
        public User User { get; set; }        
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }        
        public bool CommentStatus { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
