
using BankSimApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSimApi.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("varchar(14)");

            builder.ToTable("users");
        }
    }
}
