using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _1stVersionFinalWork.Models
{
    public class Mensagens
    {

        [Key]
        public int MensagemID { get; set; }

        [Required]
        [StringLength(255)]
        public string Texto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }


        public Boolean Respondida { get; set; }

        public DateTime? DataResposta { get; set; }

        public string TextoResposta { get; set; }

        [ForeignKey("DonoDaMensagem")]
        public int DonoDaMensagemFK { get; set; }
        public Clientes DonoDaMensagem { get; set; }


        [ForeignKey("Tipo")]
        public int TipoFK { get; set; }
        public TiposMsg Tipo { get; set; }
    }
}