using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models.FluentConfigModels
{
    public class FluentConfigBook
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string PriceRange { get; set; }

        public FluentConfigBookDetail FluentConfigBookDetail { get; set; }

        public int Publisher_Id { get; set; }
        public FluentConfigPublisher FluentConfigPublisher { get; set; }

        public List<FluentConfigAuthorBook> FluentConfigAuthorBooks { get; set; }
    }
}
