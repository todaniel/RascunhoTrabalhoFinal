﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1stVersionFinalWork.Models
{
    public class Produtos{

        public Produtos()
        {
            // inicialização da lista de Encomendas de um Cliente
            ListaDeEncomendas = new HashSet<Encomendas>();
        }

        [Key]
        public int ProdutoID { get; set; }

        [Required]
        [StringLength(40)]
        public string Nome { get; set; }

        [Required]
        [StringLength(15)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(80)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(10)]
        public float Preco { get; set; }


        // especificar que "um PRODUTO está" em várias ENCOMENDAS
        public ICollection<Encomendas> ListaDeEncomendas { get; set; }

    }
}