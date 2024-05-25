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
public class EntradaProdutoService
{
    private readonly INotaFiscalRepository _notaFiscalRepository;
    private readonly IItensNotaRepository _itensNotaRepository;
    private readonly MapperConfiguration _configurationMapper;

    public EntradaProdutoService(INotaFiscalRepository notaFiscalRepository, IItensNotaRepository itensNotaRepository)
    {
        _notaFiscalRepository = notaFiscalRepository;
        _itensNotaRepository = itensNotaRepository;
        _configurationMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<NotaFiscalPostDTO, Nota_Fiscal>();
            cfg.CreateMap<ItensNotaPostDTO, Itens_Nota>();
        });
    }

    public void RegistrarEntradaProduto(EntradaProdutosDTO entradaProdutoDTO)
    {
        using var transaction = _notaFiscalRepository.BeginTransaction();
        try
        {
            var mapper = _configurationMapper.CreateMapper();
            var notaFiscal = mapper.Map<Nota_Fiscal>(entradaProdutoDTO.NotaFiscal);
            var notaFiscalSalva = _notaFiscalRepository.CriarNotaFiscal(notaFiscal);

            foreach (var itemNotaDTO in entradaProdutoDTO.ItensNota)
            {
                var itemNota = mapper.Map<Itens_Nota>(itemNotaDTO);
                itemNota.ID_NOTA = notaFiscalSalva.ID_NOTA;
                itemNota.ID_SEC = notaFiscalSalva.ID_SEC;
                _itensNotaRepository.CriarItemNota(itemNota);
                
            }

            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public List<NotaFiscalGetDTO> ObterTodasNotasFiscais()
        {
        var mapper = _configurationMapper.CreateMapper();
        return mapper.Map<List<NotaFiscalGetDTO>>(_notaFiscalRepository.ObterTodasNotasFiscais());
    }
}
}

