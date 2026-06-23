using EF10.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010.CodeFirstMigration.Data.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Office)
                .WithOne(x => x.Instructor)
                .HasForeignKey<Instructor>(x => x.OfficeId)
                .IsRequired(false);

            builder.ToTable("Instructors");

            builder.HasData(LoadInstructors());
        }

        private static List<Instructor> LoadInstructors()
        {
            return new List<Instructor>
            {
                new Instructor { Id = 1, Name = "Ahmed Abdullah", OfficeId = 1 },
                new Instructor { Id = 2, Name = "Yasmeen Yasmeen", OfficeId = 2 },
                new Instructor { Id = 3, Name = "Khalid Hassan", OfficeId = 3 },
                new Instructor { Id = 4, Name = "Nadia Ali", OfficeId = 4 },
                new Instructor { Id = 5, Name = "Ahmed Abdullah", OfficeId = 5 }
            };
        }
    }


}