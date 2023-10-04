using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBMVCTrabalho2.Models
{
    public class Categoria_Gastos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo descrião é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}
