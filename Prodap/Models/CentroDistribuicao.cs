using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Prodap.Models
{
    public class CentroDistribuicao
    {
        [Display(Name = "ID:") ]
        public int ID { get; set; }


        [Display(Name = "Descrição:")]
        [Required(ErrorMessage ="Informe o nome do Centro de Distribuição.")]
        public string NOME { get; set; }


        [Display(Name = "Estado:")]
        [Required(ErrorMessage = "Informe o Estado do Centro de Distribuição.")]
        public string UF { get; set; }


        [Display(Name = "Endereço:")]
        [Required(ErrorMessage = "Informe o Endereço do Centro de Distribuição.")]
        public string ENDERECO { get; set; }


        [Display(Name = "Telefone:")]
        [Required(ErrorMessage = "Informe o telefone do Centro de Distribuição.")]
        public string TELEFONE { get; set; }


    }
}