using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models.FluentModels
{
    public class FluentAuthorBook
    {
        public int BookId { get; set; }
        public int Author_Id { get; set; }

        public FluentBook Book { get; set; }
        public FluentAuthor Author { get; set; }
    }
}
