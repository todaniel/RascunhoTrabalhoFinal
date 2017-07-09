using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1stVersionFinalWork.Models{
    public class Clientes{

        public Clientes(){
            // inicialização da lista de Encomendas dum determinado cliente
            ListaDeEncomendas = new HashSet<Encomendas>();
            ListaDeMensagensEnviadas = new HashSet<Mensagens>();
        }

        [Key]
        public int ClienteID { get; set; }


        [Required(ErrorMessage = "O {0} é de Preenchimento Obrigatório")]
        [Display(Name = "Nome do Cliente")]
        [RegularExpression("[A-ZÍÂÓÁ][a-záéíóúàèìòùâêîôûãõäëïöüç']+((-| )((a|de|da|do|dos) )?[A-ZÍÂÓÁÉÀ][a-záéíóúàèìòùâêîôûãõäëïöüç']+)*",
            ErrorMessage = "No {0} só se permitem letras. Cada nome deverá começar com letra maiúscula!")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O {0} é de Preenchimento Obrigatório")]
        [RegularExpression("[0-9]{9}",
            ErrorMessage = "Introduza APENAS 9 dígitos.")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "O {0} é de Preenchimento Obrigatório")]
        [RegularExpression("[0-9]{9}",
            ErrorMessage = "Introduza APENAS 9 dígitos.")]
        public string Contribuinte { get; set; }


        //Não funcionaram as expressões regulares nem a mensagem de erro! Mensagem p/ defeito da anotação "[EmailAddress]"
        //[a-z0-9._%+-]+@[a-z0-9.-]+\.([a-z])
        //[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$
        [Required(ErrorMessage = "O {0} é de Preenchimento Obrigatório")]
        [Display(Name = "Email")]
        [EmailAddress]
        //[DataType(DataType.EmailAddress, 
        //ErrorMessage = "O E-mail não cumpre o formato válido.")]  
        public string Mail { get; set; }


        // especificar que um CLIENTE tem várias ENCOMENDAS
        public virtual ICollection<Encomendas> ListaDeEncomendas { get; set; }

        // especificar que um CLIENTE pode submeter várias MENSAGENS
        public virtual ICollection<Mensagens> ListaDeMensagensEnviadas { get; set; }

    }
}