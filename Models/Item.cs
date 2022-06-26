
using System.ComponentModel.DataAnnotations;

namespace bsis3a_webapp.Models
{
    public class item
    {
        public int Id { get; set; }     
        [Required]  
        [StringLength(50)]
        public string Name { get; set; }

        
        
       
    }
}