using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace LojaEstoque.Models
{
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember]
        [Key]
        public int Id { get; set; }
    }

    public class Produto : BaseModel
    {
        public Produto()
        {
        }

        public Produto(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }

        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres.")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Range(0.01, 999.99, ErrorMessage = "Valor deve ser maior que 0 e menor que R$ 999,99.")]
        [Required(ErrorMessage = "Valor é obrigatório.")]
        public decimal Valor { get; set; }
    }
}
