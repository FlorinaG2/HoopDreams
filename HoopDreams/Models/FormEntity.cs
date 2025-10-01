using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoopDreams.Models
{
    public class FormEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ChildName { get; set; }

        [Required]
        public int ChildAge { get; set; }

        [Required]
        public string Gender { get; set; }

        public string Experience { get; set; }

        public string MedicalConditions { get; set; }

        public string EmergencyContact { get; set; }

        public string Notes { get; set; }
    }
}
