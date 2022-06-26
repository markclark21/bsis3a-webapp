using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
namespace bsis3a_webapp.Models.ViewModels


{
    public class TypeViewModel
    {
        public type type { get; set; }     
        public IEnumerable<item> items { get; set; }

        public IEnumerable<SelectListItem> selectListItem(IEnumerable<item> item)
        {
        List<SelectListItem> ItemList = new List<SelectListItem>();
         SelectListItem sli = new SelectListItem
         {
                Text = "Select Item",
                Value = "0"
                
         };
         ItemList.Add(sli);
         foreach(item type in items)
         {
              sli = new SelectListItem
         {
                Text = type.Name,
                Value = type.Id.ToString()
                
         };
            ItemList.Add(sli);
         }
            return ItemList;

        }
    }
}   