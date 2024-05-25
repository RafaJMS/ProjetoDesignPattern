using AlmoxarifadoDomain.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Logging
{
    public class CsvLogStrategy : ILogStrategy
    {
        public void CriarLog(Estoque estoque, decimal ID_REQ)
        {
            string dataAtual = DateTime.Now.ToString("yyyyMMddHHmmss");
            string nomeArquivo = $"produtosAbaixoMinimoEm_{dataAtual}_{ID_REQ}.csv";

            string pastaLogs = Path.Combine(Environment.CurrentDirectory, "LOGS");

            if (!Directory.Exists(pastaLogs))
            {
                Directory.CreateDirectory(pastaLogs);
            }
            string caminhoArquivo = Path.Combine(pastaLogs, nomeArquivo);
            using var writer = new StreamWriter(caminhoArquivo);
            using var csv = new CsvWriter(writer, new CultureInfo("pt-BR", true));
            csv.WriteField("Codigo Produto");
            csv.WriteField("Codigo Secretaria");
            csv.WriteField("Codigo Requisicao");
            csv.WriteField("Quantidade Atual");
            csv.WriteField("Data do Registro");
            csv.NextRecord();

            csv.WriteField(estoque.ID_PRO);
            csv.WriteField(estoque.ID_SEC);
            csv.WriteField(ID_REQ);
            csv.WriteField(estoque.QTD_PRO);
            csv.WriteField(DateTime.Now);
            csv.NextRecord();

        }
    }
}
