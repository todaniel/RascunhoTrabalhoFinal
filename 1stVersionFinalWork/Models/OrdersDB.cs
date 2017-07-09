using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace _1stVersionFinalWork.Models
{
    public class OrdersDB : DbContext{


        //representar as tabelas a criar na Base de Dados

        public virtual DbSet<Clientes> Clientes { get; set; }

        public virtual DbSet<Encomendas> Encomendas { get; set; }

        public virtual DbSet<ItensEncomenda> ItensEncomenda { get; set; }

        public virtual DbSet<Jornadas> Jornadas { get; set; }

        public virtual DbSet<Mensagens> Mensagens { get; set; }

        public virtual DbSet<Produtos> Produtos { get; set; }

        public virtual DbSet<TiposMsg> TiposMsg { get; set; }
    


        //especificar ONDE será criada a Base Dados
        public OrdersDB() : base("OrderDataBase") { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // não podemos usar a chave seguinte, nesta geração de tabelas
            // por causa das tabelas do Identity (gestão de utilizadores)
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //tirar cascade delete em relacionamentos 1=>muitos e muitos=>muitos
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }
}