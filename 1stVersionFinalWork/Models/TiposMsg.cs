using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalWork.Models
{
    public class TiposMsg{

        public TiposMsg(){
            // inicialização da lista de Mensagens
            ListaDeMensagens = new HashSet<Mensagens>();
        }

        [Key]
        public int TipoID { get; set; }

        [Required]
        [StringLength(15)]
        public string Descricao { get; set; }


        // especificar QUE um TIPO de MENSAGEM pode estar associado a várias MENSAGENS
        public ICollection<Mensagens> ListaDeMensagens { get; set; }

    }
}