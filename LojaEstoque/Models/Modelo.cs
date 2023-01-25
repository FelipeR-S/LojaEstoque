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

        public Produto(string nome, double valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public string Nome { get; set; } = string.Empty;
        public double Valor { get; set; }
    }
}
