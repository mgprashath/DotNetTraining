using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models.FluentModels
{
    public class FluentCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int DisplayOrder { get; set; }
    }
}
 