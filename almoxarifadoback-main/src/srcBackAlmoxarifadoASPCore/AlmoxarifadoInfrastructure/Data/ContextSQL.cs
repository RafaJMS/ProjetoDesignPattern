using AlmoxarifadoDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data
{
    public  class ContextSQL : DbContext 
    {

        public ContextSQL(DbContextOptions<ContextSQL> options) : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nota_Fiscal>().HasKey(nf => nf.ID_NOTA);
            modelBuilder.Entity<Itens_Nota>().HasKey(i => new { i.ITEM_NUM, i.ID_PRO, i.ID_NOTA, i.ID_SEC });
            modelBuilder.Entity<Requisicao>().HasKey(r => r.ID_REQ);
            modelBuilder.Entity<Itens_Requisicao>().HasKey(ir=>new { ir.NUM_ITEM, ir.ID_REQ, ir.ID_PRO, ir.ID_SEC });
            modelBuilder.Entity<Estoque>().HasKey(e => new { e.ID_PRO, e.ID_SEC }); ;
        }

        public DbSet<Nota_Fiscal> Nota_Fiscal { get; set; }
        public DbSet<Itens_Nota> Itens_Nota { get; set; }
        public DbSet<Requisicao> Requisicao { get; set;}
        public DbSet<Itens_Requisicao> Itens_Req { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
    }
}
