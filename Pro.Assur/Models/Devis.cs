using System;
using System.ComponentModel.DataAnnotations;

namespace Pro.Assur.Models
{
    public class Devis
    {
        [Key]
        public Guid DevisGuid { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Marque du Vehicule")]
        public string ModelVehicule { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Puissance Fiscale")]
        public string PuissanceFiscale { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date de mise en circulation")]
        public DateTime? DateCirculation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date d'obtention du Permis")]
        public DateTime? DatePermis { get; set; }

      
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Compagnie Actuelle")]
        public string CompagnieActuelle { get; set; }

       
        [Display(Name = "Motif de Resiliation")]
        public MotifResiliation MotifResiliation { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Sinistres Responsables")]
        public string Responsables { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Sinistres non Responsables")]
        public string NonResponsables	 { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Prenom")]
        public string Prenom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date de Naissance")]
        public DateTime? DateNaissance { get; set; }

      
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Code Postal")]
        public string CodePostal { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "le numéro de télephone est requis")]
        [Display(Name = "Tel")]
        public string Tel { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Ville")]
        public string Ville { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "l'adresse email  est incorrect")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public DateTime? DateDemande { get; set; }
    }
}
