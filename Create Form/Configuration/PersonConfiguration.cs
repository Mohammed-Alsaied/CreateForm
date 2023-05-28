using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Create_Form.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(11);
            builder.Property(p => p.Age).IsRequired().HasMaxLength(3);
            builder.Property(p => p.Street).IsRequired().HasMaxLength(20);
            builder.Property(p => p.City).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Country).IsRequired().HasMaxLength(20);
        }
    }
}
