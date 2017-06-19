using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _1stVersionFinalWork.Models{
    public class Encomendas{

        public Encomendas () {
            ListaDeProdutos = new HashSet<ItensEncomenda>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EncomendaID { get; set; }

        [Required(ErrorMessage = "O {0} é de Preenchimento Obrigatório")]
        [StringLength(40)]
        public string LocalExpedicao { get; set; }

        [Required(ErrorMessage = "A {0} é de Preenchimento Obrigatório")]
        [DataType(DataType.Date)]
        public DateTime? DataExpedicao { get; set; }


        /* colocar atributos como 
        - morada de entrega
        - morada de faturação
        - estado (paga, entregue, anulada, etc......)
        */


        [ForeignKey("Dono")]
        public int DonoFK { get; set; }
        public Clientes Dono { get; set; }

        //public int DonoFK { get; set; }
        //[ForeignKey("DonoFK")]
        //public Clientes Dono { get; set; }
        
        [ForeignKey("Jornada")]
        public int JornadaFK { get; set; }
        public Jornadas Jornada { get; set; }

        public virtual ICollection<ItensEncomenda> ListaDeProdutos { get; set; }
    }
}