using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AlmoxarifadoDomain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.Services
{
    public class RequisicaoService
    {
        private readonly IRequisicaoRepository _requisicaoRepository;
        private readonly MapperConfiguration _configurationMapper;

        public RequisicaoService(IRequisicaoRepository requisicaoRepository)
        {
            _requisicaoRepository = requisicaoRepository;
            _configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Requisicao, RequisicaoGetDTO>();
                cfg.CreateMap<RequisicaoPostDTO, Requisicao>();
            });
        }

        public List<RequisicaoGetDTO> ObterTodasRequisicoes()
        {
            var mapper = _configurationMapper.CreateMapper();
            return mapper.Map<List<RequisicaoGetDTO>>(_requisicaoRepository.ObterTodasRequisicoes());
        }

        public RequisicaoGetDTO CriarRequisicao(RequisicaoPostDTO requisicaoPostDTO)
        {
            var requisicaoSalva = _requisicaoRepository.CriarRequisicao(
                new Requisicao
                {
                    ANO = requisicaoPostDTO.ANO,
                    DATA_REQ = requisicaoPostDTO.DATA_REQ,
                    ID_CLI = requisicaoPostDTO.ID_CLI,
                    ID_SEC = requisicaoPostDTO.ID_SEC,
                    ID_SET = requisicaoPostDTO.ID_SET,
                    MES = requisicaoPostDTO.MES,
                    OBSERVACAO = requisicaoPostDTO.OBSERVACAO,
                    QTD_ITEN = requisicaoPostDTO.QTD_ITEN,
                    TOTAL_REQ = requisicaoPostDTO.TOTAL_REQ
                }
            );

            return new RequisicaoGetDTO
            {
                ID_REQ = requisicaoSalva.ID_REQ,
                ANO = requisicaoSalva.ANO,
                DATA_REQ = requisicaoSalva.DATA_REQ,
                ID_CLI = requisicaoSalva.ID_CLI,
                ID_SEC = requisicaoSalva.ID_SEC,
                ID_SET = requisicaoSalva.ID_SET,
                MES = requisicaoSalva.MES,
                OBSERVACAO = requisicaoSalva.OBSERVACAO,
                QTD_ITEN = requisicaoSalva.QTD_ITEN,
                TOTAL_REQ = requisicaoSalva.TOTAL_REQ
            };
        }

        public async Task<bool> PutRequisicao(int ID_REQ, RequisicaoPostDTO requisicaoPostDTO)
        {
            return await _requisicaoRepository.UpdateRequisicao(ID_REQ,
                new Requisicao
                {
                    ID_REQ = ID_REQ,
                    ANO = requisicaoPostDTO.ANO,
                    DATA_REQ = requisicaoPostDTO.DATA_REQ,
                    ID_CLI = requisicaoPostDTO.ID_CLI,
                    ID_SEC = requisicaoPostDTO.ID_SEC,
                    ID_SET = requisicaoPostDTO.ID_SET,
                    MES = requisicaoPostDTO.MES,
                    OBSERVACAO = requisicaoPostDTO.OBSERVACAO,
                    QTD_ITEN = requisicaoPostDTO.QTD_ITEN,
                    TOTAL_REQ = requisicaoPostDTO.TOTAL_REQ
                });
        }

        public void DeleteRequisicao(int ID_REQ)
        {
            _requisicaoRepository.DeleteRequisicao(ID_REQ);
        }
    }
}
