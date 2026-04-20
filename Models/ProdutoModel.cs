using System.ComponentModel.DataAnnotations;

namespace apiCRUD.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool EmEstoque { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataAtualizacao { get; set; } = DateTime.Now.ToLocalTime();
    }
}