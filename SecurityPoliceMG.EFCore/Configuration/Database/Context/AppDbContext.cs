using Microsoft.EntityFrameworkCore;
using SecurityPoliceMG.Domain.Entity.Model;

namespace SecurityPoliceMG.EFCore.Configuration.Database.Context;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Scale> Scales { get; set; }

    public DbSet<RefreshToken> Tokens { get; set; }

    public DbSet<Request> Requests { get; set; }

    public DbSet<RequestExchangeScale> RequestExchangeScales { get; set; }

    public DbSet<PersonScale> PersonScales { get; set; }

    public DbSet<EmailCodeConfirmation> EmailCodeConfirmations { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Request

        modelBuilder.Entity<Request>().ToTable("tb_request");

        modelBuilder.Entity<Request>()
            .Property(p => p.RequesterId)
            .HasColumnName("requester_id")
            .HasColumnType("uuid")
            .IsRequired();

        modelBuilder.Entity<Request>()
            .Property(p => p.Description)
            .HasColumnName("description")
            .HasColumnType("text")
            .IsRequired();

        modelBuilder.Entity<Request>()
            .Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        modelBuilder.Entity<Request>()
            .Property(p => p.RequestType)
            .HasColumnName("request_type")
            .IsRequired();

        modelBuilder.Entity<Request>()
            .Property(p => p.ReceiverId)
            .HasColumnName("receiver_id")
            .IsRequired();

        modelBuilder.Entity<Request>()
            .Property(p => p.IsCompleted)
            .HasColumnName("is_completed")
            .HasColumnType("boolean")
            .IsRequired();

        modelBuilder.Entity<Request>()
            .HasOne(p => p.Requester)
            .WithMany(r => r.SentRequests)
            .HasForeignKey(p => p.RequesterId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        modelBuilder.Entity<Request>()
            .HasOne(p => p.Receiver)
            .WithMany(r => r.ReceiveRequests)
            .HasForeignKey(p => p.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        #endregion

        #region RequestExchangeScale

        modelBuilder.Entity<RequestExchangeScale>().ToTable("tb_request_exchange_scale");

        modelBuilder.Entity<RequestExchangeScale>()
            .Property(p => p.RequestId)
            .HasColumnName("request_id")
            .HasColumnType("uuid")
            .IsRequired();

        modelBuilder.Entity<RequestExchangeScale>()
            .Property(p => p.Status)
            .HasColumnName("status")
            .IsRequired();

        modelBuilder.Entity<RequestExchangeScale>()
            .Property(p => p.AcceptedAt)
            .HasColumnName("accepted_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        modelBuilder.Entity<RequestExchangeScale>()
            .Property(p => p.RequesterScaleId)
            .HasColumnName("requester_scale_id")
            .HasColumnType("uuid")
            .IsRequired();

        modelBuilder.Entity<RequestExchangeScale>()
            .Property(p => p.ReceiverScaleId)
            .HasColumnName("receiver_scale_id")
            .HasColumnType("uuid");

        modelBuilder.Entity<RequestExchangeScale>()
            .HasOne(p => p.Request)
            .WithOne(r => r.RequestExchangeScale)
            .HasForeignKey<RequestExchangeScale>(p => p.RequestId)
            .IsRequired();

        modelBuilder.Entity<RequestExchangeScale>()
            .HasOne(p => p.RequesterScale)
            .WithMany(r => r.RequestExchangeScales)
            .HasForeignKey(p => p.RequesterScaleId);

        modelBuilder.Entity<RequestExchangeScale>()
            .HasOne(p => p.ReceiverScale)
            .WithMany(r => r.ReceiverExchangeScales)
            .HasForeignKey(p => p.ReceiverScaleId);

        #endregion

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
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        modelBuilder.Entity<Scale>()
            .Property(s => s.StartsAt)
            .HasColumnName("starts_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        modelBuilder.Entity<Scale>()
            .Property(s => s.FinishedAt)
            .HasColumnName("finished_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        modelBuilder.Entity<Scale>()
            .Property(s => s.Description)
            .HasColumnName("description")
            .HasColumnType("text")
            .IsRequired();

        modelBuilder.Entity<Scale>()
            .Property(s => s.Status)
            .HasColumnName("status")
            .HasColumnType("int")
            .IsRequired();

        #endregion

        #region User

        modelBuilder.Entity<User>().ToTable("tb_user");

        modelBuilder.Entity<User>().HasIndex(u => u.Email)
            .IsUnique();

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
            .Property(u => u.RefreshTokenId)
            .HasColumnName("token_id")
            .HasColumnType("uuid");

        modelBuilder.Entity<User>()
            .Property(p => p.EmailCodeConfirmationId)
            .HasColumnName("email_code_confirmation_id")
            .HasColumnType("uuid")
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(p => p.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(p => p.Role)
            .HasColumnName("role")
            .IsRequired();

        modelBuilder.Entity<User>()
            .HasOne(p => p.RefreshToken)
            .WithOne(p => p.User)
            .HasForeignKey<User>(u => u.RefreshTokenId);

        modelBuilder.Entity<User>()
            .HasOne(p => p.EmailCodeConfirmation)
            .WithOne(e => e.User)
            .HasForeignKey<User>(p => p.EmailCodeConfirmationId);

        #endregion

        #region PersonScale

        modelBuilder.Entity<PersonScale>().ToTable("tb_person_scale");

        modelBuilder.Entity<PersonScale>().HasKey(s => s.Id);

        modelBuilder.Entity<PersonScale>()
            .Property(p => p.Id)
            .HasColumnName("id")
            .HasDefaultValueSql("gen_random_uuid()");

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

        #region RefreshToken

        modelBuilder.Entity<RefreshToken>().ToTable("tb_refresh_token");

        modelBuilder.Entity<RefreshToken>().HasIndex(p => p.Token)
            .IsUnique();

        modelBuilder.Entity<RefreshToken>()
            .Property(p => p.Token)
            .HasColumnName("refresh_token")
            .HasColumnType("text")
            .IsRequired();

        modelBuilder.Entity<RefreshToken>()
            .Property(p => p.ExpiryTime)
            .HasColumnName("refresh_token_expiry_time")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        #endregion

        #region EmailCodeConfirmation

        modelBuilder.Entity<EmailCodeConfirmation>().ToTable("tb_email_code_confirmation");

        modelBuilder.Entity<EmailCodeConfirmation>().HasIndex(p => p.Code)
            .IsUnique();

        modelBuilder.Entity<EmailCodeConfirmation>()
            .Property(p => p.Code)
            .HasMaxLength(255)
            .HasColumnType("varchar")
            .IsRequired()
            .HasColumnName("code");

        modelBuilder.Entity<EmailCodeConfirmation>()
            .Property(p => p.ExpiryTime)
            .HasColumnName("expiry_time")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        #endregion
    }
}