using System;
using System.ComponentModel.DataAnnotations;

namespace angular2.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId{get;set;}
        public Model Model{get;set;}
        public bool IsRegistered{get;set;}
       
        [StringLength(255)]
        public string contactEmail { get; set; }
        [Required]
        [StringLength(255)]
        public string contactName { get; set; }
        [Required]
        [StringLength(255)]
        public string contactPhone { get; set; }
        public DateTime LastUpdate{get;set;}

    }
}