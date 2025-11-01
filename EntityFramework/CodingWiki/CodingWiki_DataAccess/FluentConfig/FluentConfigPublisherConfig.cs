using CodingWiki_Model.Models.FluentConfigModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentConfigPublisherConfig : IEntityTypeConfiguration<FluentConfigPublisher>
    {
        public void Configure(EntityTypeBuilder<FluentConfigPublisher> modelBuilder)
        {
            modelBuilder.ToTable("tblPublisher");
            modelBuilder.HasKey(u=>u.Publisher_Id);
            modelBuilder.Property(u=>u.Name).IsRequired();
        }
    }
}
