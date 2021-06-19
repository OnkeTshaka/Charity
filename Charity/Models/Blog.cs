using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity.Models
{
    public class Blog
    {
        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }
        [Required(ErrorMessage ="Enter a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Write the Introduction!"), StringLength(120) ,DataType(DataType.MultilineText)]
        public string Intro { get; set; }
        [AllowHtml,StringLength(10000), DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public string Picture { get; set; }
        public bool AllowComments { get; set; }
        public string OnCreated { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}