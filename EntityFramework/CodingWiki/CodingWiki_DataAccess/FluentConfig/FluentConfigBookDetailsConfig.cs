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
    public class FluentConfigBookDetailsConfig : IEntityTypeConfiguration<FluentConfigBookDetail>
    {
        public void Configure(EntityTypeBuilder<FluentConfigBookDetail> modelBuilder)
        {
            modelBuilder.ToTable("tblBookDetails");
            modelBuilder.HasKey(u=>u.BookDetail_Id);
            modelBuilder.Property(u => u.NumberOfChapters).IsRequired();
            modelBuilder.HasOne(u => u.FluentConfigBook)
                .WithOne(u => u.FluentConfigBookDetail).HasForeignKey<FluentConfigBookDetail>(u => u.BookId);
        }        
    }
}
