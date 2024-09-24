using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestaoAlimentos.Models
{
    public class RefeicaoModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Tipo { get; set; } // ex. café da manha etc
        [Required]
        public string? Descricao { get; set; }

        public int UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}
