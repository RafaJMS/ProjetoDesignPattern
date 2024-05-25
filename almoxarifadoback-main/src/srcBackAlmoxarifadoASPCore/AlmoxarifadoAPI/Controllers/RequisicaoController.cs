using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequisicaoController : ControllerBase
    {
        private readonly RequisicaoService _service;

        public RequisicaoController(RequisicaoService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                var requisicao = _service.ObterTodasRequisicoes();
                return Ok(requisicao);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por Favor tente novamente");
            }
        }
        [HttpPost]
        public IActionResult CriarRequisicao(RequisicaoPostDTO requisicaoPostDTO)
        {
            try
            {
                var requisicao = _service.CriarRequisicao(requisicaoPostDTO);
                return Ok(requisicao);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por Favor tente novamente");
            };
        }

        [HttpPut("{ID_REQ}")]
        public async Task<IActionResult> PutRequisicao(int ID_REQ, RequisicaoPostDTO requisicaoPostDTO)
        {
            var success = await _service.PutRequisicao(ID_REQ, requisicaoPostDTO);

            if (success == false)
            {
                return BadRequest("Ocorreu um erro ao acessar os dados. Por Favor tente novamente");
            }

            return Ok("Item alterado com sucesso!!\n"+success);
        }
        [HttpDelete("{ID_REQ}")]
        public IActionResult DeleteRequisicao(int ID_REQ) 
        { 
            _service.DeleteRequisicao(ID_REQ);
            return Ok("Item deletado com sucesso!!");
        }

    }
}
