using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalWork.Models
{
    public class Mensagens
    {

        [Key]
        [Display(Name = "Mensagem Nº")]
        public int MensagemID { get; set; }

        [Required]
        [Display(Name = "Texto da Mensagem")]
        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        public string Texto { get; set; }

        [Display(Name = "Data de Envio")]
        [DataType(DataType.Date)]
        public DateTime? Data { get; set; }

        //[Display(Name = "Estado")]
        public Boolean Respondida { get; set; }

        [Display(Name = "Data de Resposta")]
        [DataType(DataType.Date)]
        public DateTime? DataResposta { get; set; }

        [Display(Name = "Resposta")]
        public string TextoResposta { get; set; }

        [Display(Name = "Autor")]
        [ForeignKey("DonoDaMensagem")]
        public int DonoDaMensagemFK { get; set; }
        public virtual Clientes DonoDaMensagem { get; set; }

        [Display(Name = "Tipo de Mensagem")]
        [ForeignKey("Tipo")]
        public int TipoFK { get; set; }
        public virtual TiposMsg Tipo { get; set; }
    }
}