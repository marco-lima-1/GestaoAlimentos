using System.ComponentModel.DataAnnotations;

namespace GestaoAlimentos.Models
{
    public class RefeicaoModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Tipo { get; set; } // ex. café da manha etc
        [Required]
        public string Descricao { get; set; }

    }
}
