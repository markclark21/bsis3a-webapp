using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace bsis3a_webapp.Models
{
    public class type
    {
        public int Id { get; set; }     
        [Required]  
        [StringLength(50)]
        
        public string Name { get; set; }

        public item item { get; set; }
        public int itemid { get; set; }
    }
}