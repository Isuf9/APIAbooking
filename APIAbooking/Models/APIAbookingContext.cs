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
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<CanAddExplorer> CanAddExplorers { get; set; }
        public virtual DbSet<CancelBooking> CancelBookings { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Explore> Explores { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomOwner> RoomOwners { get; set; }
        public virtual DbSet<TypePay> TypePays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Tornado\\Arber; Database=APIAbooking_II; user id=sa; password=100200300");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aventure>(entity =>
            {
                entity.ToTable("aventure");

                entity.Property(e => e.AventureId)
                    .HasColumnName("aventure_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Describe)
                    .HasColumnName("describe")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Expl)
                    .HasColumnName("expl")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.ExplNavigation)
                    .WithMany(p => p.Aventures)
                    .HasForeignKey(d => d.Expl)
                    .HasConstraintName("FK__aventure__expl__1B0907CE");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("booking");

                entity.Property(e => e.ClientIdFk)
                    .HasColumnName("client_id_fk")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoomIdFk)
                    .HasColumnName("room_id_fk")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeIdFk)
                    .HasColumnName("type_id_fk")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClientIdFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ClientIdFk)
                    .HasConstraintName("FK__booking__client___29221CFB");

                entity.HasOne(d => d.RoomIdFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.RoomIdFk)
                    .HasConstraintName("FK__booking__room_id__2A164134");

                entity.HasOne(d => d.TypeIdFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.TypeIdFk)
                    .HasConstraintName("FK__booking__type_id__2B0A656D");
            });

            modelBuilder.Entity<CanAddExplorer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("can_addExplorer");

                entity.Property(e => e.ClientIdFk)
                    .HasColumnName("client_id_fk")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExplorerIdFk)
                    .HasColumnName("explorer_id_fk")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClientIdFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ClientIdFk)
                    .HasConstraintName("FK__can_addEx__clien__5FB337D6");

                entity.HasOne(d => d.ExplorerIdFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ExplorerIdFk)
                    .HasConstraintName("FK__can_addEx__explo__5EBF139D");
            });

            modelBuilder.Entity<CancelBooking>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cancel_booking");

                entity.Property(e => e.ClientIdFk)
                    .HasColumnName("client_id_fk")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoomIdFk)
                    .HasColumnName("room_id_fk")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeIdFk)
                    .HasColumnName("type_id_fk")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClientIdFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ClientIdFk)
                    .HasConstraintName("FK__cancel_bo__clien__25518C17");

                entity.HasOne(d => d.RoomIdFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.RoomIdFk)
                    .HasConstraintName("FK__cancel_bo__room___2645B050");

                entity.HasOne(d => d.TypeIdFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.TypeIdFk)
                    .HasConstraintName("FK__cancel_bo__type___2739D489");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePicture)
                    .HasColumnName("profile_picture")
                    .HasColumnType("image");

                //entity.Property(e => e.IsExist)
                //    .HasColumnName("profile_picture")
                //    .HasColumnType("image");

                entity.Property(e => e.TypeOfUser).HasColumnName("type_of_user");
            });

            modelBuilder.Entity<Explore>(entity =>
            {
                entity.ToTable("explore");

                entity.Property(e => e.ExploreId)
                    .HasColumnName("explore_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("food");

                entity.Property(e => e.FoodId)
                    .HasColumnName("food_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Describe)
                    .HasColumnName("describe")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Expl)
                    .HasColumnName("expl")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.ExplNavigation)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.Expl)
                    .HasConstraintName("FK__food__expl__20C1E124");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("place");

                entity.Property(e => e.PlaceId)
                    .HasColumnName("place_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Describe)
                    .HasColumnName("describe")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Expl)
                    .HasColumnName("expl")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.ExplNavigation)
                    .WithMany(p => p.Places)
                    .HasForeignKey(d => d.Expl)
                    .HasConstraintName("FK__place__expl__15502E78");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room");

                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Checkin)
                    .HasColumnName("checkin")
                    .HasColumnType("datetime");

                entity.Property(e => e.Checkout)
                    .HasColumnName("checkout")
                    .HasColumnType("datetime");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Describe)
                    .HasColumnName("describe")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longtitude).HasColumnName("longtitude");

                entity.Property(e => e.MaxGuest).HasColumnName("max_guest");

                entity.Property(e => e.NoHouse).HasColumnName("no_house");

                entity.Property(e => e.NoticeGuest)
                    .HasColumnName("notice_guest")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                

                entity.Property(e => e.NrBathroom).HasColumnName("nr_bathroom");

                entity.Property(e => e.OwnerIdFk)
                    .HasColumnName("owner_Id_fk")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("image");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Reserved).HasColumnName("reserved");

                entity.Property(e => e.SpecialItem)
                    .HasColumnName("special_item")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WhatSpaceCanUseGuests).HasColumnName("what_space_can_use_Guests");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.OwnerIdFkNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.OwnerIdFk)
                    .HasConstraintName("FK__room__owner_Id_f__7B5B524B");
            });

            modelBuilder.Entity<RoomOwner>(entity =>
            {
                entity.HasKey(e => e.OwnerId)
                    .HasName("PK__room_own__3C4FBEE44BAC17E4");

                entity.ToTable("room_owner");

                entity.Property(e => e.OwnerId)
                    .HasColumnName("owner_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePicture)
                    .HasColumnName("profile_picture")
                    .HasColumnType("image");

                entity.Property(e => e.TypeOfUser).HasColumnName("type_of_user");
            });

            modelBuilder.Entity<TypePay>(entity =>
            {
                entity.ToTable("type_pay");

                entity.Property(e => e.TypePayId)
                    .HasColumnName("type_pay_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PayPal).HasColumnName("payPal");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
