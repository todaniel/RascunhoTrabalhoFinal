using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1stVersionFinalWork.Models

{
    public class Clientes{

        public Clientes(){
            // inicialização da lista de Encomendas dum determinado cliente
            ListaDeEncomendas = new HashSet<Encomendas>();
            ListaDeMensagensEnviadas = new HashSet<Mensagens>();
        }

        [Key]
        public int ClienteID { get; set; }

        [Required]
        [StringLength(40)]
        public string Nome { get; set; }

        [Required]
        [StringLength(9)]
        public string Contacto { get; set; }

        [Required]
        [StringLength(9)]
        public string Contribuinte { get; set; }

        [Required]
        [StringLength(30)]
        public string Mail { get; set; }


        // especificar que um CLIENTE tem várias ENCOMENDAS
        public virtual ICollection<Encomendas> ListaDeEncomendas { get; set; }

        // especificar que um CLIENTE pode submeter várias MENSAGENS
        public virtual ICollection<Mensagens> ListaDeMensagensEnviadas { get; set; }

    }
}