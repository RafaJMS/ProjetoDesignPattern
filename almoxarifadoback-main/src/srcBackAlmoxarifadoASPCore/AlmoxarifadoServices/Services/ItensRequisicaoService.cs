using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.Services
{
    public class ItensRequisicaoService
    {
        private readonly IItensRequisicaoRepository _repository;
        private readonly MapperConfiguration _config;

        public ItensRequisicaoService(IItensRequisicaoRepository repository)
        {
            _repository = repository;
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Itens_Requisicao, ItensRequisicaoGetDTO>();
                cfg.CreateMap<ItensRequisicaoPostDTO, Itens_Requisicao>();
            });
        }

        public List<ItensRequisicaoGetDTO> ObterTodosItensRequisicao()
        {
            var mapper = _config.CreateMapper();
            return mapper.Map<List<ItensRequisicaoGetDTO>>(_repository.ObterTodosItensRequisicao());
        }

        public ItensRequisicaoGetDTO CriarItemRequisicao(ItensRequisicaoPostDTO itensRequisicao)
        {
            var itemRequisicaoSalvo = _repository.CriarItemRequisicao(
                new Itens_Requisicao
                {
                    NUM_ITEM = itensRequisicao.NUM_ITEM,
                    ID_PRO = itensRequisicao.ID_PRO,
                    ID_REQ = itensRequisicao.ID_REQ,
                    ID_SEC = itensRequisicao.ID_SEC,
                    PRE_UNIT = itensRequisicao.PRE_UNIT,
                    QTD_PRO = itensRequisicao.QTD_PRO,
                    TOTAL_REAL = itensRequisicao.TOTAL_REAL,
                });
            return new ItensRequisicaoGetDTO
            {
                NUM_ITEM = itemRequisicaoSalvo.NUM_ITEM,
                ID_PRO = itemRequisicaoSalvo.ID_PRO,
                ID_REQ = itemRequisicaoSalvo.ID_REQ,
                ID_SEC = itemRequisicaoSalvo.ID_SEC,
                PRE_UNIT = itemRequisicaoSalvo.PRE_UNIT,
                QTD_PRO = itemRequisicaoSalvo.QTD_PRO,
                TOTAL_REAL = itemRequisicaoSalvo.TOTAL_REAL,

            };
        }

        public async Task<bool> UpdateItemRequisicao(int NUM_ITEM, int ID_REQ, int ID_PRO, int ID_SEC, ItensRequisicaoPutDTO itensRequisicaoPut)
        {
            return await _repository.UpdateItemRequisicaoAsync(NUM_ITEM, ID_REQ, ID_PRO, ID_SEC,
                new Itens_Requisicao
                {
                    ID_PRO = ID_PRO,
                    ID_REQ = ID_REQ,
                    ID_SEC = ID_SEC,
                    NUM_ITEM = NUM_ITEM,
                    PRE_UNIT = itensRequisicaoPut.PRE_UNIT,
                    QTD_PRO = itensRequisicaoPut.QTD_PRO,
                    TOTAL_REAL = itensRequisicaoPut.TOTAL_REAL,

                });
        } 

        public void DeleteItemRequisicao(int NUM_ITEM, int ID_REQ, int ID_PRO, int ID_SEC) 
        {
            _repository.DeleteItemRequisicao(NUM_ITEM,ID_REQ,ID_PRO,ID_SEC);
        }
    }
}
