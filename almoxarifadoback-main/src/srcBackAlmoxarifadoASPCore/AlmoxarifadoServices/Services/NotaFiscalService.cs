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
    public class NotaFiscalService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly MapperConfiguration _configurationMapper;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Nota_Fiscal, NotaFiscalGetDTO>();
                cfg.CreateMap<NotaFiscalPostDTO, Nota_Fiscal>();
            });
        }

        public List<NotaFiscalGetDTO> ObterTodasNotasFiscais()
        {
            var mapper = _configurationMapper.CreateMapper();
            return mapper.Map<List<NotaFiscalGetDTO>>(_notaFiscalRepository.ObterTodasNotasFiscais());
        }

        public NotaFiscalGetDTO CriarNotaFiscal(NotaFiscalPostDTO notaFiscal)
        {
            var notaFiscalSalva = _notaFiscalRepository.CriarNotaFiscal(
                new Nota_Fiscal
                {
                    ID_FOR = notaFiscal.ID_FOR,
                    ID_SEC = notaFiscal.ID_SEC,
                    NUM_NOTA = notaFiscal.NUM_NOTA,
                    VALOR_NOTA = notaFiscal.VALOR_NOTA,
                    QTD_ITEM = notaFiscal.QTD_ITEM,
                    ICMS = notaFiscal.ICMS,
                    ISS = notaFiscal.ISS,
                    ANO = notaFiscal.ANO,
                    MES = notaFiscal.MES,
                    DATA_NOTA = notaFiscal.DATA_NOTA,
                    ID_TIPO_NOTA = notaFiscal.ID_TIPO_NOTA,
                    OBSERVACAO_NOTA = notaFiscal.OBSERVACAO_NOTA,
                    EMPENHO_NUM = notaFiscal.EMPENHO_NUM
                }
            );

            return new NotaFiscalGetDTO
            {
                ID_NOTA = notaFiscalSalva.ID_NOTA,
                ID_FOR = notaFiscalSalva.ID_FOR,
                ID_SEC = notaFiscalSalva.ID_SEC,
                NUM_NOTA = notaFiscalSalva.NUM_NOTA,
                VALOR_NOTA = notaFiscalSalva.VALOR_NOTA,
                QTD_ITEM = notaFiscalSalva.QTD_ITEM,
                ICMS = notaFiscalSalva.ICMS,
                ISS = notaFiscalSalva.ISS,
                ANO = notaFiscalSalva.ANO,
                MES = notaFiscalSalva.MES,
                DATA_NOTA = notaFiscalSalva.DATA_NOTA,
                ID_TIPO_NOTA = notaFiscalSalva.ID_TIPO_NOTA,
                OBSERVACAO_NOTA = notaFiscalSalva.OBSERVACAO_NOTA,
                EMPENHO_NUM = notaFiscalSalva.EMPENHO_NUM
            };
        }

        public async Task<bool> PutNotaFiscal(int idNota, NotaFiscalPostDTO notaFiscal)
        {
            return await _notaFiscalRepository.UpdateNotaFiscal(idNota, new Nota_Fiscal
            {
                ID_NOTA = idNota,
                ID_FOR = notaFiscal.ID_FOR,
                ID_SEC = notaFiscal.ID_SEC,
                NUM_NOTA = notaFiscal.NUM_NOTA,
                VALOR_NOTA = notaFiscal.VALOR_NOTA,
                QTD_ITEM = notaFiscal.QTD_ITEM,
                ICMS = notaFiscal.ICMS,
                ISS = notaFiscal.ISS,
                ANO = notaFiscal.ANO,
                MES = notaFiscal.MES,
                DATA_NOTA = notaFiscal.DATA_NOTA,
                ID_TIPO_NOTA = notaFiscal.ID_TIPO_NOTA,
                OBSERVACAO_NOTA = notaFiscal.OBSERVACAO_NOTA,
                EMPENHO_NUM = notaFiscal.EMPENHO_NUM
            });
        }

        public void DeleteNotaFiscal(int idNota)
        {
            _notaFiscalRepository.DeleteNotaFiscal(idNota);
        }
    }
}
