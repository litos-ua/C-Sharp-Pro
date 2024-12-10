using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationNotes.Models
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Указывает автоинкремент
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required, MaxLength(1000)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(500)]
        public string Tags { get; set; } // Теги через запятую

        // Внешний ключ для связи с Contact
        [Required]
        public int ContactId { get; set; }

        [ForeignKey("ContactId")]
        public virtual Contact? Contact { get; set; }
    }

}




