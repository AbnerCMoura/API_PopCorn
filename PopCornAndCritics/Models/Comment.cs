using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace PopCornAndCritics.Models
{
    [Table("Comment")]
    public class Comment
    {
        public int Id { get; set; }

        [Column]
        [Required]
        public int Author { get; set; }

        [Column]
        [Required]
        public int Movie { get; set; }

        [Column]
        [Required(ErrorMessage = "Conteúdo do comentário é obrigatório")]
        [Range(50, 300, ErrorMessage = "O Comentário deve ter entre 50 a 300 caracteres")]
        public string Content { get; set; }
    }
}
