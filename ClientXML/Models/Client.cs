using ClientXML.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientXML.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public long CardCode { get; set; }
        [Required]
        public string StartDate { get; set; }
        public string FinishDate { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Gender { get; set; }
        [Required]
        public string BirthDay { get; set; }
        public string PhoneHome { get; set; }
        [Required]
        public string PhoneMobil { get; set; }
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string House { get; set; }
        public string Apartment { get; set; }
    }
}
