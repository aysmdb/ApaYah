using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ApaYah.Helper;

namespace ApaYah.Models
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Titlenya minimal 3 maksimal 12 bro")]
        [MustHaveWord("Ahay")]
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPublished { get; set; }
        public string Image { get; set; }
    }
}
