using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace copave.Models
{
    public class TipoMaquina
    {  
       [Key]        
        public int TipoId { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]        
        public string Descricao { get; set; }
        public List<Maquina> Maquinas {get; set;}
    }
}