using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace MvcNotes.Models
{
    public class Note
    {
        public int Id { get; set; }
        [Display(Name = "Twoje imię")]
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Tytuł notatki")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Treść notatki")]
        public string NoteContents { get; set; }
        [Required]
        [RegularExpression(@"\B#(\w\w+)", ErrorMessage=("Hashtag musi zaczynać się od #"))]
        public string Hashtag { get; set; }
    }
}
