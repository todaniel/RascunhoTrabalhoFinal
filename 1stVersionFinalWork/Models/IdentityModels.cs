using FinalWork.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinalWork.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class OrdersDB : IdentityDbContext<ApplicationUser>{
        public OrdersDB()
            : base("OrderDataBase", throwIfV1Schema: false){
        }

        static OrdersDB()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<OrdersDB>(new ApplicationDbInitializer());
        }

        public static OrdersDB Create(){
            return new OrdersDB();
        }


        //**************************************************************************
        //**************************************************************************
        //**************************************************************************
        //**************************************************************************
        //**************************************************************************
        //representar as tabelas a criar na Base de Dados

        public virtual DbSet<Clientes> Clientes { get; set; }

        public virtual DbSet<Encomendas> Encomendas { get; set; }

        public virtual DbSet<ItensEncomenda> ItensEncomenda { get; set; }

        public virtual DbSet<Jornadas> Jornadas { get; set; }

        public virtual DbSet<Mensagens> Mensagens { get; set; }

        public virtual DbSet<Produtos> Produtos { get; set; }

        public virtual DbSet<TiposMsg> TiposMsg { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // não podemos usar a chave seguinte, nesta geração de tabelas
            // por causa das tabelas do Identity (gestão de utilizadores)
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //tirar cascade delete em relacionamentos 1=>muitos e muitos=>muitos
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
        //***********************************************************************************
        //***********************************************************************************
        //***********************************************************************************
        //***********************************************************************************



    }
}