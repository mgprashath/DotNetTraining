using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models.FluentModels
{
    public class FluentBook
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string PriceRange { get; set; }
        public FluentBookDetail BookDetail { get; set; }
        public int Publisher_Id { get; set; }
        public FluentPublisher Publisher { get; set; }
        public List<FluentAuthorBook> FluentAuthorBooks { get; set; }
    }
}
