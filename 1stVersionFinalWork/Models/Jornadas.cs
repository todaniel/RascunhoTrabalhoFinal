using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalWork.Models
{
    public class Jornadas
    {

        public Jornadas()
        {
            // inicialização da lista de Encomendas de uma Jornada
            ListaDeEncomendas = new HashSet<Encomendas>();
        }

        [Key]
        [Display(Name = "Jornada Nº")]
        public int JornadaID { get; set; }

        [Required]
        [Display(Name = "Data de Início")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required]
        [Display(Name = "Data de Finalização")]
        [DataType(DataType.Date)]
        public DateTime DataFinal { get; set; }


        [Display(Name = "Descrição")]
        [StringLength(80)]
        public string Descricao { get; set; }


        // especificar que uma JORNADA tem várias ENCOMENDAS
        public virtual ICollection<Encomendas> ListaDeEncomendas { get; set; }

    }
}