using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEBMVCTrabalho2.Models
{
    public class Conta_Bancaria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Bancos")]
        public int bancosID { get; set; }
        [ForeignKey("bancosID")]
        public Bancos bancos { get; set; }

        [Required(ErrorMessage = "Campo descrião é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo saldo é obrigatório")]
        [Display(Description = "saldo", Name = "Saldo: ")]
        public float Saldo { get; set; }
    }
}
