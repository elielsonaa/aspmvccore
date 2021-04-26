using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace copave.Models
{
    public class Maquina
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Você deve informar o tipo da Maquina")]
        [Range(1, int.MaxValue, ErrorMessage = "Escolha um tipo de maquina")]
        public int TipoId { get; set; }
        public virtual TipoMaquina Tipo { get; set; }

        [Required(ErrorMessage = "A Data de instalação é obrgatória")]
        [Display(Name = "Data da Instalação")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Instalacao { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Valor da Compra R$")]
        [Required(ErrorMessage = "O campo valor é obrigatório")]
        [Range(1, 999999999, ErrorMessage = "O valor da compra tem que ser mior que 0")]
        public decimal Valor { get; set; }
    }
}