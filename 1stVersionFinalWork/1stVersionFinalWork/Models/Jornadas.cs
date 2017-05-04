using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1stVersionFinalWork.Models
{
    public class Jornadas{

        public Jornadas(){
            // inicialização da lista de Encomendas de uma Jornada
            ListaDeEncomendas = new HashSet<Encomendas>();
        }

        [Key]
        public int JornadaID { get; set; }

        [Required]
        [StringLength(40)]
        [DataType(DataType.Date)]
        public string DataInicio { get; set; }

        [Required]
        [StringLength(40)]
        [DataType(DataType.Date)]
        public string DataFinal { get; set; }

        [Required]
        [StringLength(80)]
        public string Descricao { get; set; }


        // especificar que uma JORNADA tem várias ENCOMENDAS
        public ICollection<Encomendas> ListaDeEncomendas { get; set; }

    }
}