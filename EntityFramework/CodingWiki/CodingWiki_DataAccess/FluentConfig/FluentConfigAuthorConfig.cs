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
    public class FluentConfigAuthorConfig : IEntityTypeConfiguration<FluentConfigAuthor>
    {
        public void Configure(EntityTypeBuilder<FluentConfigAuthor> modelBuilder)
        {
            modelBuilder.ToTable("tblAuthor");
            modelBuilder.HasKey(u => u.Author_Id);
            modelBuilder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Property(u => u.LastName).IsRequired();
            modelBuilder.Ignore(u=>u.FullName);
        }
    }
}
