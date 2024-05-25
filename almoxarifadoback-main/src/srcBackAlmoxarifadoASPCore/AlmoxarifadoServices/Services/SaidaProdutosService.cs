using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.Services
{
    public class SaidaProdutosService
    {
        private readonly IRequisicaoRepository _requisicaoRepository;
        private readonly IItensRequisicaoRepository _itensRequisicaoRepository;
        private readonly MapperConfiguration _mapperConfiguration;

        public SaidaProdutosService(IRequisicaoRepository requisicaoRepository, IItensRequisicaoRepository itensRequisicaoRepository)
        {
            _requisicaoRepository = requisicaoRepository;
            _itensRequisicaoRepository = itensRequisicaoRepository;
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequisicaoPostDTO, Requisicao>();
                cfg.CreateMap<ItensRequisicaoPostDTO, Itens_Requisicao>();
            });
        }

        public void RegistrarSaidaProduto(SaidaProdutosDTO saidaProdutos)
        {
            using var transaction = _requisicaoRepository.BeginTransaction();
            try
            {
                var mapper = _mapperConfiguration.CreateMapper();
                var requisicao = mapper.Map<Requisicao>(saidaProdutos.Requisicao);
                var requisicaoSalva = _requisicaoRepository.CriarRequisicao(requisicao);

                foreach (var itemNotaDTO in saidaProdutos.ItensRequisicao)
                {
                    var itemRequisicao = mapper.Map<Itens_Requisicao>(itemNotaDTO);
                    itemRequisicao.ID_REQ = requisicaoSalva.ID_REQ;
                    itemRequisicao.ID_SEC = requisicaoSalva.ID_SEC;
                    _itensRequisicaoRepository.CriarItemRequisicao(itemRequisicao);
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
        public List<RequisicaoGetDTO> ObterTodasNotasFiscais()
        {
            var mapper = _mapperConfiguration.CreateMapper();
            return mapper.Map<List<RequisicaoGetDTO>>(_requisicaoRepository.ObterTodasRequisicoes());
        }
    }
}
