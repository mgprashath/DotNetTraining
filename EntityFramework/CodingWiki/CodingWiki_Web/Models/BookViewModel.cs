using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingWiki_Web.Models
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> PublisherList { get; set; }
    }
}
