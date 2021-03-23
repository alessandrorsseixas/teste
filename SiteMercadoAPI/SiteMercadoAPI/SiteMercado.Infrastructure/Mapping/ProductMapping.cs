using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteMercado.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteMercado.Infrastructure.Mapping
{
    public class ProductfMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("product");

            entity.Property(e => e.Name)
               .HasMaxLength(100)
               .IsUnicode(false);

            entity.Property(e => e.Value).HasColumnType("datetime");

            entity.Property(e => e.Image)
            .HasMaxLength(255)
            .IsUnicode(false);

            entity.Property(e => e.Active).HasColumnName("active");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.CreatedUser)
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.Property(e => e.UpdatedUser)
                .HasMaxLength(11)
                .IsUnicode(false);
        }
    }
}
