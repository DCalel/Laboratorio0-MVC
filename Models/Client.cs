using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio0_MVC.Models
{
    public class Client
    {
        [Display(Name = "ID")]
        [Required]
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string Surname { get; set; }
        [Display(Name = "Number Phone")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public int? Phone { get; set; }
       
        [Required]
        public string Description { get; set; }
       
        

  
    }
}
