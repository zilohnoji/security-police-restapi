using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity.Model;
using File = System.IO.File;

namespace SecurityPoliceMG.EFCore.Configuration.Database.Context;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public DbSet<Photo> Photos { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Scale> Scales { get; set; }

    public DbSet<PersonScale> PersonScales { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Person

        modelBuilder.Entity<Person>().ToTable("tb_person");

        modelBuilder.Entity<Person>()
            .Property(p => p.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(200);

        modelBuilder.Entity<Person>()
            .Property(p => p.BirthDate)
            .HasColumnName("birth_date")
            .IsRequired();

        modelBuilder.Entity<Person>()
            .Property(p => p.Gender)
            .HasColumnName("gender")
            .HasMaxLength(9)
            .IsRequired();

        modelBuilder.Entity<Person>()
            .Property(p => p.MotherName)
            .HasColumnName("mother_name")
            .HasMaxLength(200)
            .IsRequired();

        modelBuilder.Entity<Person>()
            .Property(p => p.DaddyName)
            .HasColumnName("father_name")
            .HasMaxLength(200)
            .IsRequired();

        modelBuilder.Entity<Person>()
            .Property(p => p.AddressId)
            .HasColumnName("address_id")
            .IsRequired();

        modelBuilder.Entity<Person>()
            .Property(p => p.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        modelBuilder.Entity<Person>()
            .HasOne(a => a.Address)
            .WithMany(a => a.Persons)
            .HasForeignKey(p => p.AddressId)
            .IsRequired();

        modelBuilder.Entity<Person>()
            .HasOne(p => p.User)
            .WithOne(u => u.Person)
            .HasForeignKey<Person>(p => p.UserId)
            .IsRequired();

        #endregion

        #region Address

        modelBuilder.Entity<Address>().ToTable("tb_address");

        modelBuilder.Entity<Address>()
            .Property(p => p.PatioType)
            .HasColumnName("street_type")
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<Address>()
            .Property(p => p.Street)
            .HasColumnName("street")
            .HasMaxLength(200)
            .IsRequired();

        modelBuilder.Entity<Address>()
            .Property(p => p.Number)
            .HasColumnName("number")
            .IsRequired();

        modelBuilder.Entity<Address>()
            .Property(p => p.Neighborhood)
            .HasColumnName("neighborhood")
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Address>()
            .Property(p => p.CityId)
            .HasColumnName("city_id")
            .IsRequired();

        modelBuilder.Entity<Address>()
            .HasOne(a => a.City)
            .WithMany()
            .HasForeignKey(a => a.CityId)
            .IsRequired();

        #endregion

        #region City

        modelBuilder.Entity<City>().ToTable("tb_city");

        modelBuilder.Entity<City>()
            .Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();

        modelBuilder.Entity<City>()
            .Property(c => c.Uf)
            .HasColumnName("uf")
            .HasMaxLength(2)
            .IsRequired();

        #endregion

        #region Photo

        modelBuilder.Entity<Photo>().ToTable("tb_photo");

        modelBuilder.Entity<Photo>()
            .Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        modelBuilder.Entity<Photo>()
            .Property(p => p.Bucket)
            .HasColumnName("bucket")
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<Photo>()
            .Property(p => p.Hash)
            .HasColumnName("hash")
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Photo>()
            .Property(p => p.PersonId)
            .HasColumnName("person_id")
            .IsRequired();


        modelBuilder.Entity<Photo>()
            .HasOne(p => p.Person)
            .WithOne(p => p.Photo)
            .HasForeignKey<Photo>(p => p.PersonId)
            .IsRequired();

        #endregion

        #region Scale

        modelBuilder.Entity<Scale>().ToTable("tb_scale");

        modelBuilder.Entity<Scale>()
            .Property(s => s.IsCompleted)
            .HasColumnType("bool")
            .HasColumnName("is_completed")
            .IsRequired();

        modelBuilder.Entity<Scale>()
            .Property(s => s.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamp")
            .IsRequired();

        modelBuilder.Entity<Scale>()
            .Property(s => s.StartsAt)
            .HasColumnName("starts_at")
            .HasColumnType("timestamp")
            .IsRequired();

        modelBuilder.Entity<Scale>()
            .Property(s => s.FinishedAt)
            .HasColumnName("finished_at")
            .HasColumnType("timestamp")
            .IsRequired();

        modelBuilder.Entity<Scale>()
            .Property(s => s.Description)
            .HasColumnName("description")
            .HasColumnType("text")
            .IsRequired();

        #endregion

        #region User

        modelBuilder.Entity<User>().ToTable("tb_user");

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasColumnName("password")
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(u => u.RefreshToken)
            .HasColumnName("refresh_token")
            .HasColumnType("text");

        modelBuilder.Entity<User>()
            .Property(u => u.RefreshTokenExpiryTime)
            .HasColumnName("refresh_token_expiry_time")
            .HasColumnType("timestamp");

        #endregion

        #region PersonScale

        modelBuilder.Entity<PersonScale>().ToTable("tb_person_scale");

        modelBuilder.Entity<PersonScale>()
            .HasKey(s => new { s.PersonId, s.ScaleId });

        modelBuilder.Entity<PersonScale>()
            .Property(p => p.ScaleId)
            .HasColumnName("scale_id")
            .HasColumnType("uuid")
            .IsRequired();

        modelBuilder.Entity<PersonScale>()
            .Property(p => p.PersonId)
            .HasColumnName("person_id")
            .HasColumnType("uuid")
            .IsRequired();

        modelBuilder.Entity<PersonScale>()
            .Property(p => p.HoursWorked)
            .HasColumnName("hours_worked")
            .HasColumnType("int")
            .IsRequired();

        modelBuilder.Entity<PersonScale>()
            .HasOne(s => s.Person)
            .WithMany(p => p.PersonScales)
            .HasForeignKey(s => s.PersonId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        modelBuilder.Entity<PersonScale>()
            .HasOne(s => s.Scale)
            .WithMany(p => p.PersonScales)
            .HasForeignKey(s => s.ScaleId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        #endregion

        #region Document

        modelBuilder.Entity<Document>().ToTable("tb_document");

        modelBuilder.Entity<Document>()
            .Property(p => p.Url)
            .IsRequired();

        modelBuilder.Entity<Document>()
            .Property(p => p.DocType)
            .HasColumnName("document_type")
            .IsRequired();

        modelBuilder.Entity<Document>()
            .Property(p => p.Name)
            .IsRequired();

        modelBuilder.Entity<Document>()
            .Property(p => p.Size)
            .IsRequired();

        #endregion
    }
}