using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _1stVersionFinalWork.Models
{
    public class ItensEncomenda
    {
        public int ID { get; set; }

        [Required]
        public float Quantidade { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public decimal IVA { get; set; }



        [ForeignKey("Produto")]
        public int ProdutoFK { get; set; }
        public Produtos Produto { get; set; }

        [ForeignKey("Encomenda")]
        public int EncomendaFK { get; set; }
        public Encomendas Encomenda { get; set; }




    }
}