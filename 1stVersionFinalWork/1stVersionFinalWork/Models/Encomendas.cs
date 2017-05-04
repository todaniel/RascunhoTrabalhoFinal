using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1stVersionFinalWork.Models
{
    public class Encomendas{

        [Key]
        public int EncomendaID { get; set; }

        [Required]
        [StringLength(40)]
        public string LocalExpedicao { get; set; }

        [Required]
        [StringLength(40)]
        [DataType(DataType.Date)]
        public string DataExpedicao { get; set; }
    }
}