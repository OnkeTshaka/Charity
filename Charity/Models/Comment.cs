using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Charity.Models
{
    public class Comment
    {

        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public string Comments { get; set; }
        [Display(Name = "Date")]
        public DateTime? ThisDateTime { get; set; }
        public int ArticleId { get; set; }
        public int? Rating { get; set; }
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}