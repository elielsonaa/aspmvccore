using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace copave.Models
{
    public class Maquina {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Você deve informar o tipo da Maquina")]
        [Range(1, int.MaxValue, ErrorMessage = "Escolha um tipo de maquina")]
        public int TipoId { get; set; }
        public virtual TipoMaquina Tipo {get;set;}
       
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "A Data de instalação é obrgatória")]
        [Display(Name = "Data da Instalação")]
        public DateTime Instalacao { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Valor da Compra")]
        [Range(1, double.MaxValue, ErrorMessage = "O valor da compra tem que ser mior que 0")]
        public decimal Valor { get; set; }
    }
}