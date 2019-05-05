using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUDWeb.Models
{
    public class Book
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name ="書名")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name ="作者")]
        public string Author { get; set;}

        [Required]
        [StringLength(20)]
        [Display(Name ="出版商")]
        public string Publisher { get; set; }

        [Required]
        [Display(Name ="頁數")]
        public int Page { get; set; }

        [Required]
        [Display(Name ="價格")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "內容描述")]
        public string Description { get; set; }

        [Required]
        [Display(Name ="建立時間")]
        public DateTime Created { get; set; }
    }
}