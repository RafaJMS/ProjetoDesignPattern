using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly NotaFiscalService _notaFiscalService;

        public NotaFiscalController(NotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var notaFiscal = _notaFiscalService.ObterTodasNotasFiscais();
                return Ok(notaFiscal);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult CriarNotaFiscal(NotaFiscalPostDTO notaFiscalPostDTO)
        {
            try
            {
                var itemNota = _notaFiscalService.CriarNotaFiscal(notaFiscalPostDTO);
                return Ok(itemNota);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por Favor tente novamente");
            };
        }

        [HttpPut]
        public async Task<IActionResult> PutNotaFiscal([BindRequired] int idNota, NotaFiscalPostDTO notaFiscal)
        {
            var success = await _notaFiscalService.PutNotaFiscal(idNota, notaFiscal);

            if (!success)
            {
                return BadRequest();
            }

            return Ok("Nota fiscal alterada com sucesso!!");
        }

        [HttpDelete]
        public IActionResult DeleteNotaFiscal([BindRequired] int idNota)
        {
            try
            {
                _notaFiscalService.DeleteNotaFiscal(idNota);
                return Ok("Nota fiscal deletada com sucesso!!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
