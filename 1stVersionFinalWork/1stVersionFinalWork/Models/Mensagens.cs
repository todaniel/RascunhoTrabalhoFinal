using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1stVersionFinalWork.Models
{
    public class Mensagens{

        [Key]
        public int MensagemID { get; set; }

        [Required]
        [StringLength(255)]
        public float Texto { get; set; }

        [Required]
        [StringLength(40)]
        [DataType(DataType.Date)]
        public string Data { get; set; }

    }
}