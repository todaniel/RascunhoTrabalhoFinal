using System;
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
            ListaDeEncomendas = new HashSet<ItensEncomenda>();
        }

        [Key]
        public int ProdutoID { get; set; }

        [Required(ErrorMessage = "O {0} é de Preenchimento Obrigatório")]
        [Display(Name = "Nome do Produto")]
        [RegularExpression("[A-ZÍÂÓÁ][a-záéíóúàèìòùâêîôûãõäëïöüç']+((-| )((a|de|da|do|dos) )?[A-ZÍÂÓÁÉÀ][a-záéíóúàèìòùâêîôûãõäëïöüç']+)*",
            ErrorMessage = "No {0} só se permitem letras. Cada nome deverá começar com letra maiúscula!")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Tipo de Produto")]
        [StringLength(15)]
        public string Tipo { get; set; }

        [Required]
        [Display(Name = "Descrição do Produto")]
        public string Descricao { get; set; }

  
        [Required(ErrorMessage = "O {0} é de Preenchimento Obrigatório")]
        [RegularExpression("[0-9]+(,[0-9]{1,2})?",
            ErrorMessage = "Introduza um valor inteiro ou decimal com vírgula!")]
        public decimal Preco { get; set; }

        //VERSÃO DO PEDRO NUNES
        //[Required(ErrorMessage = "A introdução do Preço é obrigatório")]
        //[Display(Name = "Preço: ")]
        //public double Preco { get; set; }


        [Required]
        [Display(Name = "Taxa de Iva")]
        public decimal IVA { get; set; }


        public string Imagem { get; set; }


        // especificar que "um PRODUTO está" em várias ENCOMENDAS
        public virtual ICollection<ItensEncomenda> ListaDeEncomendas { get; set; }

    }
}