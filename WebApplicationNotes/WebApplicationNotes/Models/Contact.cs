using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationNotes.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Указывает автоинкремент
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(15), Phone]
        public string Phone { get; set; }

        [MaxLength(15), Phone]
        public string AlternatePhone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [ValidateNever]
        public virtual IEnumerable<Note> Notes { get; set; }
    }
}

