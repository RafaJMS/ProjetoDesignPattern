using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensNotaController : ControllerBase
    {
        private readonly ItensNotaService _itensNotaService;

        public ItensNotaController(ItensNotaService itensNotaService)
        {
            _itensNotaService = itensNotaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var itensNota = _itensNotaService.ObterTodosItensNota();
                return Ok(itensNota);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult CriarItemNota(ItensNotaPostDTO itemNotaPostDTO)
        {
            try
            {
                var itemNota = _itensNotaService.CriarItemNota(itemNotaPostDTO);
                return Ok(itemNota);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por Favor tente novamente");
            };
        }

        [HttpPut]
        public async Task<IActionResult> PutItemNota([BindRequired] int ItemNum, [BindRequired] int IDPro, [BindRequired] int IDNota, [BindRequired] int IDSec, ItensNotaPutDTO itemNota)
        {
            var success = await _itensNotaService.PutItemNota(ItemNum, IDPro, IDNota, IDSec, itemNota);

            if (!success)
            {
                return BadRequest();
            }

            return Ok("Item alterado com sucesso!!");
        }

        [HttpDelete]
        public IActionResult DeleteItemNota([BindRequired] int ItemNum, [BindRequired] int IDPro, [BindRequired] int IDNota, [BindRequired] int IDSec)
        {
            _itensNotaService.DeleteItemNota(ItemNum, IDPro, IDNota, IDSec);
            return Ok("Item deletado com sucesso!!");
        }
    }
}
