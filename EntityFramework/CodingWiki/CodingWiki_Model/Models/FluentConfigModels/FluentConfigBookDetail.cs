using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models.FluentConfigModels
{
    public class FluentConfigBookDetail
    {
        public int BookDetail_Id { get; set; }
        public int NumberOfChapters { get; set; }
        public int NumberOfPages { get; set; }
        public string Weight { get; set; }

        public int BookId { get; set; }
        public FluentConfigBook FluentConfigBook { get; set; }
    }
}
