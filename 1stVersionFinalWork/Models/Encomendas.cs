using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalWork.Models{
    public class Encomendas{

        public Encomendas () {
            ListaDeProdutos = new HashSet<ItensEncomenda>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //A PK não será AutoNumber
        [Display(Name = "Nº de Encomenda")]
        public int EncomendaID { get; set; }

        [Required(ErrorMessage = "O {0} é de Preenchimento Obrigatório")]
        [Display(Name = "Local de Expedição")]
        [StringLength(40)]
        public string LocalExpedicao { get; set; }

        [Required(ErrorMessage = "A {0} é de Preenchimento Obrigatório")]
        [Display(Name = "Data de Expedição")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date")]
        //[DataType(DataType.Date, ErrorMessage = "Formato de data inválido! [Datas aceitáveis no formato dd/mm/aa ou aa/mm/dd]")]
        public DateTime? DataExpedicao { get; set; }

        //O MELHOR É ESCOLHER UMA LISTA SELCTED BOX
        //[Required(ErrorMessage = "O {0} é de Preenchimento Obrigatório")]
        //[Display(Name = "Estado da Encomenda")]
        //[RegularExpression("((pendente|entregue|anulada|por pagar|pronta|e|){1})",
        //    ErrorMessage = "No {0} só é permitido [pendente; entregue; anulada; por pagar; pronta; paga] unicamente ou conjugados!")]
        //public string Estado { get; set; }

        /* colocar atributos como 
        - morada de entrega
        - morada de faturação
        - estado (paga, entregue, anulada, etc......)
        */


        [ForeignKey("Dono")]
        [Display(Name = "Autor da Encomenda")]
        public int DonoFK { get; set; }
        public Clientes Dono { get; set; }

        //public int DonoFK { get; set; }
        //[ForeignKey("DonoFK")]
        //public Clientes Dono { get; set; }
        
        [ForeignKey("Jornada")]
        [Display(Name = "Jornada de Trabalho")]
        public int JornadaFK { get; set; }
        public Jornadas Jornada { get; set; }

        public virtual ICollection<ItensEncomenda> ListaDeProdutos { get; set; }
    }
}