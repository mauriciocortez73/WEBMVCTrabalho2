using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBMVCTrabalho2.Models
{
    [Table("Pessoas")]
    public class Pessoas
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório...")]
        [StringLength(35)]
        [Display(Name = "Nome")]
        public string nome { get; set; }
    }
}
