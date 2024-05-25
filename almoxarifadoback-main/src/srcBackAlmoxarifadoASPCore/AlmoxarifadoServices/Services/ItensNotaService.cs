using System.Collections.Generic;
using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices.DTO;
using AutoMapper;

namespace AlmoxarifadoServices.Services
{
    public class ItensNotaService
    {
        private readonly IItensNotaRepository _itensNotaRepository;
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly MapperConfiguration _configurationMapper;

        public ItensNotaService(IItensNotaRepository itensNotaRepository,IEstoqueRepository estoqueRepository)
        {
            _itensNotaRepository = itensNotaRepository;
            _estoqueRepository = estoqueRepository;
            _configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Itens_Nota, ItensNotaGetDTO>();
                cfg.CreateMap<ItensNotaPostDTO, Itens_Nota>();
            });
        }

        public List<ItensNotaGetDTO> ObterTodosItensNota()
        {
            var mapper = _configurationMapper.CreateMapper();
            return mapper.Map<List<ItensNotaGetDTO>>(_itensNotaRepository.ObterTodosItensNota());
        }

        public ItensNotaGetDTO CriarItemNota(ItensNotaPostDTO itemNota)
        {
            var itemNotaSalvo = _itensNotaRepository.CriarItemNota(
                new Itens_Nota
                {
                    ITEM_NUM = itemNota.ITEM_NUM,
                    ID_PRO = itemNota.ID_PRO,
                    QTD_PRO = itemNota.QTD_PRO,
                    PRE_UNIT = itemNota.PRE_UNIT,
                    EST_LIN = itemNota.EST_LIN,
                    ID_NOTA = itemNota.ID_NOTA,
                    ID_SEC = itemNota.ID_SEC,
                }
            );
            ItensNotaGetDTO itensNotaGet = new()
            {
                ITEM_NUM = itemNotaSalvo.ITEM_NUM,
                ID_PRO = itemNotaSalvo.ID_PRO,
                ID_NOTA = itemNotaSalvo.ID_NOTA,
                ID_SEC = itemNotaSalvo.ID_SEC,
                QTD_PRO = itemNotaSalvo.QTD_PRO,
                PRE_UNIT = itemNotaSalvo.PRE_UNIT,
                EST_LIN = itemNotaSalvo.EST_LIN
            };

            return itensNotaGet;
        }

        public async Task<bool> PutItemNota(int itemNum, int IdPro, int IdNota, int IdSec, ItensNotaPutDTO itemNota)
        {

            return await _itensNotaRepository.UpdateItemNota(itemNum, IdPro, IdNota, IdSec, 
                new Itens_Nota
                {
                ID_NOTA = IdNota,
                ID_PRO = IdPro,
                ID_SEC = IdSec,
                ITEM_NUM = itemNum,
                EST_LIN = itemNota.EST_LIN,
                PRE_UNIT= itemNota.PRE_UNIT,
                QTD_PRO = itemNota.QTD_PRO

                });
        }

        public void DeleteItemNota(int itemNum, int IdPro, int IdNota, int IdSec)
        {
            _itensNotaRepository.DeleteItemNota(itemNum, IdPro, IdNota, IdSec);
        }

        private void AtualizarEstoque(ItensNotaGetDTO itemNota) 
        {
            var estoque = _estoqueRepository.ObterEstoquePorID(itemNota.ID_PRO, itemNota.ID_SEC);
            if (estoque != null)
            {
                estoque.QTD_PRO += itemNota.QTD_PRO;
                _estoqueRepository.AtualizarEstoque(estoque);
            }

        }
    }
}
