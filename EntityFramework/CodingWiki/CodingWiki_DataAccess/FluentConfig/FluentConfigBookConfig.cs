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
    public class FluentConfigBookConfig : IEntityTypeConfiguration<FluentConfigBook>
    {
        public void Configure(EntityTypeBuilder<FluentConfigBook> modelBuilder)
        {
            modelBuilder.ToTable("tblBook");
            modelBuilder.HasKey(u=>u.BookId);
            modelBuilder.Property(u => u.ISBN).IsRequired().HasMaxLength(20);
            modelBuilder.Ignore(u=>u.PriceRange);
            modelBuilder.HasOne(u => u.FluentConfigPublisher).WithMany(u => u.FluentConfigBooks)
                .HasForeignKey(u => u.Publisher_Id);
        }
    }
}
