using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaidaProdutosController : ControllerBase
    {
        private readonly SaidaProdutosService _saidaProdutoService;

        public SaidaProdutosController(SaidaProdutosService saidaProdutoService)
        {
            _saidaProdutoService = saidaProdutoService;
        }

        [HttpPost]
        public IActionResult RegistrarEntradaProduto(SaidaProdutosDTO saidaProdutoDTO)
        {
            try
            {
                _saidaProdutoService.RegistrarSaidaProduto(saidaProdutoDTO);
                return Ok("Saida de produto registrada com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao registrar a saida de produto: {ex.Message}");
            }
        }
    }
}
