using apiCRUD.Models;

namespace apiCRUD.Services.ProdutoService
{
    public interface IProdutoInterface
    {
        Task<ServiceResponse<List<ProdutoModel>>> GetProduto();
        Task<ServiceResponse<List<ProdutoModel>>> CreateProduto(ProdutoModel novoProduto);
        Task<ServiceResponse<ProdutoModel>> GetProdutoById(int id);
        Task<ServiceResponse<List<ProdutoModel>>> UpdateProduto(ProdutoModel editadoProduto);
        Task<ServiceResponse<List<ProdutoModel>>> DeleteProduto(int id);
        Task<ServiceResponse<List<ProdutoModel>>> InativarProduto(int id);
    }
}