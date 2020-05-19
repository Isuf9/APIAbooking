using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIAbooking.Models
{
    public partial class APIAbookingContext : DbContext
    {
        public APIAbookingContext()
        {
        }

        public APIAbookingContext(DbContextOptions<APIAbookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aventure> Aventures { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Explore> Explores { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<PayMethod> PayMethods { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomOwner> RoomOwners { get; set; }
        public virtual DbSet<RoomSpaceItem> RoomSpaceItems { get; set; }
        public virtual DbSet<SentMoney> SentMoneys { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.; Database=APIAbooking; user id=sa; password=isufisuf");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aventure>(entity =>
            {
                entity.ToTable("Aventure");

                entity.Property(e => e.AventureId)
                    .HasColumnName("Aventure_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Describe)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Expl).HasColumnName("expl");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ExplNavigation)
                    .WithMany(p => p.Aventures)
                    .HasForeignKey(d => d.Expl)
                    .HasConstraintName("FK__Aventure__expl__15502E78");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientId)
                    .HasColumnName("Client_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePicture).HasColumnType("text");
            });

            modelBuilder.Entity<Explore>(entity =>
            {
                entity.ToTable("Explore");

                entity.Property(e => e.ExploreId)
                    .HasColumnName("Explore_id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");

                entity.Property(e => e.FoodId)
                    .HasColumnName("Food_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Describe)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Expl).HasColumnName("expl");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ExplNavigation)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.Expl)
                    .HasConstraintName("FK__Food__expl__182C9B23");
            });

            modelBuilder.Entity<PayMethod>(entity =>
            {
                entity.HasKey(e => e.PayIdForSentMoney)
                    .HasName("PK__PayMetho__CA4530CC667B5EFD");

                entity.ToTable("PayMethod");

                entity.Property(e => e.PayIdForSentMoney)
                    .HasColumnName("Pay_id_for_sent_money")
                    .ValueGeneratedNever();

                entity.Property(e => e.CardNr)
                    .HasColumnName("card_Nr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Confirmaton).HasColumnName("confirmaton");

                entity.Property(e => e.ExperationDate)
                    .HasColumnName("experation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pay)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PayId).HasColumnName("Pay_id");

                entity.Property(e => e.Reservation).HasColumnName("reservation");

                entity.Property(e => e.SecurityCode)
                    .HasColumnName("security_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasColumnName("zip_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ReservationNavigation)
                    .WithMany(p => p.PayMethods)
                    .HasForeignKey(d => d.Reservation)
                    .HasConstraintName("FK__PayMethod__reser__44FF419A");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("Place");

                entity.Property(e => e.PlaceId)
                    .HasColumnName("Place_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Describe)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Expl).HasColumnName("expl");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ExplNavigation)
                    .WithMany(p => p.Places)
                    .HasForeignKey(d => d.Expl)
                    .HasConstraintName("FK__Place__expl__1273C1CD");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.ReservationId)
                    .HasColumnName("Reservation_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PayId).HasColumnName("Pay_id");

                entity.Property(e => e.RoomId).HasColumnName("Room_id");

                entity.HasOne(d => d.R)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => new { d.ReservationId, d.RoomId })
                    .HasConstraintName("FK__Reservation__286302EC");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => new { e.ReservationIdFk, e.RoomId })
                    .HasName("PK__Room__259D75836950ACB3");

                entity.ToTable("Room");

                entity.Property(e => e.ReservationIdFk).HasColumnName("Reservation_idFK");

                entity.Property(e => e.RoomId).HasColumnName("Room_id");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientIdFk).HasColumnName("Client_idFK");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Describe)
                    .HasColumnName("describe")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ExploreIdFk).HasColumnName("Explore_idFK");

                entity.Property(e => e.HouseRoule)
                    .HasColumnName("House_Roule")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NoHouse)
                    .HasColumnName("No_House")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerIdFk).HasColumnName("Owner_idFK");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.RoomSpaceItemIdFk).HasColumnName("RoomSpaceItem_idFK");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WhatAmenitiesDoYouOffer).HasColumnName("What_amenities_do_you_offer");

                entity.Property(e => e.WhatSpaceCanUseGuests).HasColumnName("What_space_can_use_Guests");

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClientIdFkNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.ClientIdFk)
                    .HasConstraintName("FK__Room__Client_idF__22AA2996");

                entity.HasOne(d => d.ExploreIdFkNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.ExploreIdFk)
                    .HasConstraintName("FK__Room__Explore_id__25869641");

                entity.HasOne(d => d.OwnerIdFkNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.OwnerIdFk)
                    .HasConstraintName("FK__Room__Owner_idFK__239E4DCF");

                entity.HasOne(d => d.RoomSpaceItemIdFkNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomSpaceItemIdFk)
                    .HasConstraintName("FK__Room__RoomSpaceI__24927208");
            });

            modelBuilder.Entity<RoomOwner>(entity =>
            {
                entity.HasKey(e => e.OwnerId)
                    .HasName("PK__RoomOwne__BD605693E4F6BA60");

                entity.ToTable("RoomOwner");

                entity.Property(e => e.OwnerId)
                    .HasColumnName("Owner_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePicture).HasColumnType("text");
            });

            modelBuilder.Entity<RoomSpaceItem>(entity =>
            {
                entity.HasKey(e => e.SpaceId)
                    .HasName("PK__RoomSpac__793ECA551C45145F");

                entity.ToTable("RoomSpaceItem");

                entity.Property(e => e.SpaceId)
                    .HasColumnName("space_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.SpaceItem)
                    .HasColumnName("space_item")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SentMoney>(entity =>
            {
                entity.HasKey(e => e.MoneyId)
                    .HasName("PK__sentMone__290ACE1B96DAB96B");

                entity.ToTable("sentMoney");

                entity.Property(e => e.MoneyId)
                    .HasColumnName("money_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AcceptAmount)
                    .HasColumnName("acceptAmount")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DataOfAcceptAmount)
                    .HasColumnName("dataOfAcceptAmount")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataOfSentAmount)
                    .HasColumnName("dataOfSentAmount")
                    .HasColumnType("datetime");

                entity.Property(e => e.SentAmount)
                    .HasColumnName("sentAmount")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Money)
                    .WithOne(p => p.SentMoney)
                    .HasForeignKey<SentMoney>(d => d.MoneyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sentMoney__money__5070F446");

                entity.HasOne(d => d.MoneyNavigation)
                    .WithOne(p => p.SentMoney)
                    .HasForeignKey<SentMoney>(d => d.MoneyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sentMoney__money__5165187F");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id_")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(24)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
