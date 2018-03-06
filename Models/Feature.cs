using System.ComponentModel.DataAnnotations.Schema;

namespace angular2.Models
{
    [Table("Features")]
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}