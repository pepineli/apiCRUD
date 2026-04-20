using apiCRUD.DataContext;
using apiCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace apiCRUD.Services.ProdutoService
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly ApplicationDbContext _context;

        public ProdutoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> CreateProduto(ProdutoModel novoProduto)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                if (novoProduto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados do produto!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Add(novoProduto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Produtos.ToListAsync();
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> DeleteProduto(int id)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                ProdutoModel produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);

                if (produto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Produtos.ToListAsync();
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ProdutoModel>> GetProdutoById(int id)
        {
            ServiceResponse<ProdutoModel> serviceResponse = new ServiceResponse<ProdutoModel>();

            try
            {
                ProdutoModel produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);

                if (produto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Dados = produto;
                    serviceResponse.Sucesso = true;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> GetProduto()
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                serviceResponse.Dados = await _context.Produtos.ToListAsync();
                serviceResponse.Sucesso = true;

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum produto encontrado.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> InativarProduto(int id)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                ProdutoModel produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);

                if (produto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                produto.EmEstoque = false;
                produto.DataAtualizacao = DateTime.Now.ToLocalTime();

                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Produtos.ToListAsync();
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> UpdateProduto(ProdutoModel editadoProduto)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                ProdutoModel produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == editadoProduto.Id);

                if (produto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                produto.Nome = editadoProduto.Nome;
                produto.Descricao = editadoProduto.Descricao;
                produto.Preco = editadoProduto.Preco;
                produto.Categoria = editadoProduto.Categoria;
                produto.Quantidade = editadoProduto.Quantidade;
                produto.EmEstoque = editadoProduto.EmEstoque;
                produto.DataAtualizacao = DateTime.Now.ToLocalTime();

                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Produtos.ToListAsync();
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}