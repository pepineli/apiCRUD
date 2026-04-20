using Microsoft.AspNetCore.Mvc;
using apiCRUD.Models;
using apiCRUD.Services.ProdutoService;

namespace apiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtoInterface;

        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> GetProdutos()
        {
            return Ok(await _produtoInterface.GetProduto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProdutoModel>>> GetProdutoById(int id)
        {
            return Ok(await _produtoInterface.GetProdutoById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> CreateProduto(ProdutoModel novoProduto)
        {
            return Ok(await _produtoInterface.CreateProduto(novoProduto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> UpdateProduto(int id, ProdutoModel editadoProduto)
        {
            return Ok(await _produtoInterface.UpdateProduto(editadoProduto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> DeleteProduto(int id)
        {
            return Ok(await _produtoInterface.DeleteProduto(id));
        }

        [HttpPut("inativar/{id}")]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> InativarProduto(int id)
        {
            return Ok(await _produtoInterface.InativarProduto(id));
        }
    }
}