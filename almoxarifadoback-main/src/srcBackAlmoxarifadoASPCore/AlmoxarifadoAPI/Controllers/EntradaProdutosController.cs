using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntradaProdutoController : ControllerBase
    {
        private readonly EntradaProdutoService _entradaProdutoService;

        public EntradaProdutoController(EntradaProdutoService entradaProdutoService)
        {
            _entradaProdutoService = entradaProdutoService;
        }

        [HttpPost]
        public IActionResult RegistrarEntradaProduto(EntradaProdutosDTO entradaProdutoDTO)
        {
            try
            {
                _entradaProdutoService.RegistrarEntradaProduto(entradaProdutoDTO);
                return Ok("Entrada de produto registrada com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao registrar a entrada de produto: {ex.Message}");
            }
        }
    }
}
