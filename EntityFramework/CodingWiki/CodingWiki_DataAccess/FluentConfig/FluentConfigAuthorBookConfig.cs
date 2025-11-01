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
    public class FluentConfigAuthorBookConfig : IEntityTypeConfiguration<FluentConfigAuthorBook>
    {
        public void Configure(EntityTypeBuilder<FluentConfigAuthorBook> modelBuilder)
        {
            modelBuilder.ToTable("tblAuthorBook");
            modelBuilder.HasKey(u => new { u.Author_Id, u.BookId });
            modelBuilder.HasOne(u => u.FluentConfigBook).WithMany(u => u.FluentConfigAuthorBooks)
                .HasForeignKey(u => u.Author_Id);
            modelBuilder.HasOne(u => u.FluentConfigAuthor).WithMany(u => u.FluentConfigAuthorBooks)
                .HasForeignKey(u=>u.BookId);
        }
    }
}
