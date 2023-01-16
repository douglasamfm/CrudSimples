using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prodap.Models
{
    public class Produtos
    {
        [Display(Name = "ID_PRODUTO")]
        [Required(ErrorMessage = "Informe o código do produto.")]
        public string ID_PRODUTO { get; set; }


        [Display(Name = "Descrição do Produto:")]
        [Required(ErrorMessage = "Informe a descrição do Produto.")]
        public string NOME { get; set; }


        [Display(Name = "Quantidade:")]
        [Required(ErrorMessage = "Informe a Quantidade .")]
        public int QUANTIDADE { get; set; }


        [Display(Name = "Centro de Distribuição:")]
        [Required(ErrorMessage = "Informe o Centro de Distribuição.")]
        public string CENTRODISTRIBUICAO { get; set; }

    }
}