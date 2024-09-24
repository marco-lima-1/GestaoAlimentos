using GestaoAlimentos.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestaoAlimentos.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }

        
        [DisplayName("1 = Saúde , 2 = Cutting, 3 = Bulking")]
        public TipoDeDieta Dieta { get; set; }

        [JsonIgnore]
        public ICollection<RefeicaoModel>? Refeicoes { get; set; }
    }
}
