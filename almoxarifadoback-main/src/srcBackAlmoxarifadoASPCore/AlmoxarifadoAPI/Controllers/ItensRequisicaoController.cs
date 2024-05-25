using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensRequisicaoController : ControllerBase
    {
        private readonly ItensRequisicaoService _itensRequisicaoService;
        private readonly IServiceProvider _serviceProvider;

        public ItensRequisicaoController(IServiceProvider serviceProvider, ItensRequisicaoService itensRequisicaoService) 
        {
            _itensRequisicaoService = itensRequisicaoService;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public IActionResult Get()
        {
            using var scope = HttpContext.RequestServices.CreateScope();
            {
                try
                {
                    var itensReq = _itensRequisicaoService.ObterTodosItensRequisicao();
                    return Ok(itensReq);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
                }
            }
            
        }
        [HttpPost]
        public IActionResult CriarItemRequisicao(ItensRequisicaoPostDTO itemRequisicaoPostDTO)
        {
            try
            {
                var itemRequisicao = _itensRequisicaoService.CriarItemRequisicao(itemRequisicaoPostDTO);
                return Ok(itemRequisicao);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por Favor tente novamente");
            };
        }

        [HttpPut]
        public async Task<IActionResult> PutItemRequisicao([BindRequired] int ItemNum, [BindRequired] int IDPro, [BindRequired] int IDReq, [BindRequired] int IDSec, ItensRequisicaoPutDTO itemRequisicao)
        {
            var success = await _itensRequisicaoService.UpdateItemRequisicao(ItemNum, IDReq, IDPro, IDSec, itemRequisicao);

            if (!success)
            {
                return BadRequest();
            }

            return Ok("Item alterado com sucesso!!");
        }

        [HttpDelete]
        public IActionResult DeleteItemNota([BindRequired] int ItemNum, [BindRequired] int IDPro, [BindRequired] int IDNota, [BindRequired] int IDSec)
        {
            _itensRequisicaoService.DeleteItemRequisicao(ItemNum, IDPro, IDNota, IDSec);
            return Ok("Item deletado com sucesso!!");
        }
    }
}
