using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models.Insureds
{
    public enum InsuranceRole
    {
        [Display(Name = "Pojištěný")]
        Insured,
        [Display(Name = "Pojistník")]
        Policyholder
    }

    public enum Gender
    {
        [Display(Name = "Žena")]
        Woman,
        [Display(Name = "Muž")]
        Man
    }

    public class InsuredBase
    {
        [Required(ErrorMessage = "Zadejte jméno")]
        [StringLength(20, ErrorMessage = "Zadejte jméno v délce 3 až 20 znaků", MinimumLength = 3)]
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Zadejte příjmení")]
        [StringLength(20, ErrorMessage = "Zadejte příjmení v délce 3 až 20 znaků!", MinimumLength = 3)]
        [Display(Name = "Příjmení")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Zvolte jedno z pohlaví")]
        [Display(Name = "Pohlaví")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Zadejte emailovou adresu")]
        [EmailAddress(ErrorMessage = "Zadaná emailová adresa není platná")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zadejte telefonní číslo")]
        [StringLength(20, ErrorMessage = "Zadejtejte telefon o maximální délce 20 čísel")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Zadejte název ulice a číslo popisné")]
        [StringLength(30, ErrorMessage = "Název ulice a čísla popisného je příliš dlouhý")]
        [Display(Name = "Ulice a číslo popisné")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Zadejte název města")]
        [StringLength(25, ErrorMessage = "Název města je příliš dlouhý")]
        [Display(Name = "Město")]
        public string City { get; set; }

        [Required(ErrorMessage = "Zadejte PSČ")]
        [StringLength(15, ErrorMessage = "PSČ je příliš dlouhé")]
        [Display(Name = "PSČ")]
        public string Zip { get; set; }
    }
}
