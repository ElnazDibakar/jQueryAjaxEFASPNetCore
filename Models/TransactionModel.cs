using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jQueryAjaxEFASPNetCore.Models
{
    public class TransactionModel
    {
        [Key]
        public int TransactionId { get; set; }

        [MaxLength(12)]
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [DisplayName("Numéro de Compte")]
        [Column(TypeName ="nvarchar(12)")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [DisplayName("Nom du Bénéficiaire")]
        [Column(TypeName = "nvarchar(100)")]
        public string BeneficiaryName { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Nom de la banque")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Code SWIFT")]
        public string SWIFTCode { get; set; }

        [DisplayName("Montante")]
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public int Amount { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

    }
}
