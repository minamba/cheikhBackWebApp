using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCheikh.Domain.Models;

public partial class MiaDatabaseContext : DbContext
{
    public MiaDatabaseContext()
    {
    }

    public MiaDatabaseContext(DbContextOptions<MiaDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CloseRegistration> CloseRegistrations { get; set; }

    public virtual DbSet<Home> Homes { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Media> Media { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentPg> PaymentPgs { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<RegistrationQueue> RegistrationQueues { get; set; }

    public virtual DbSet<Seminaire> Seminaires { get; set; }

    public virtual DbSet<SeminaireQueue> SeminaireQueues { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Target> Targets { get; set; }

    public virtual DbSet<Theme> Themes { get; set; }

    public virtual DbSet<Witness> Witnesses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MIA_Database;Trusted_Connection=True; Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CloseRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Close_inscription");

            entity.ToTable("Close_registration");

            entity.Property(e => e.IdBanner).HasColumnName("Id_banner");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Home>(entity =>
        {
            entity.ToTable("Home");

            entity.Property(e => e.IdBanner).HasColumnName("id_banner");
            entity.Property(e => e.IdImage).HasColumnName("Id_image");
            entity.Property(e => e.IdMedia).HasColumnName("Id_media");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.IdImageNavigation).WithMany(p => p.Homes)
                .HasForeignKey(d => d.IdImage)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Home_Image");

            entity.HasOne(d => d.IdMediaNavigation).WithMany(p => p.Homes)
                .HasForeignKey(d => d.IdMedia)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Home_Media");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.ToTable("Image");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Media>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Video");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_name");
            entity.Property(e => e.Mail).HasMaxLength(50);
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(15)
                .HasColumnName("Payment_mode");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Phone_number");
        });

        modelBuilder.Entity<PaymentPg>(entity =>
        {
            entity.ToTable("PaymentPg");

            entity.Property(e => e.IdBanner).HasColumnName("Id_banner");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Inscription");

            entity.ToTable("Registration");

            entity.Property(e => e.IdBanner).HasColumnName("Id_banner");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<RegistrationQueue>(entity =>
        {
            entity.ToTable("Registration_queue");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_name");
            entity.Property(e => e.IsContacted).HasColumnName("Is_contacted");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Phone_number");
            entity.Property(e => e.SendedToBot).HasColumnName("Sended_to_bot");
        });

        modelBuilder.Entity<Seminaire>(entity =>
        {
            entity.ToTable("Seminaire");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.IdBanner).HasColumnName("Id_banner");
            entity.Property(e => e.IdImage).HasColumnName("id_image");
            entity.Property(e => e.IdMedia).HasColumnName("Id_media");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.IdBannerNavigation).WithMany(p => p.Seminaires)
                .HasForeignKey(d => d.IdBanner)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Seminaire_Image");

            entity.HasOne(d => d.IdMediaNavigation).WithMany(p => p.Seminaires)
                .HasForeignKey(d => d.IdMedia)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Seminaire_Media");
        });

        modelBuilder.Entity<SeminaireQueue>(entity =>
        {
            entity.ToTable("Seminaire_queue");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_name");
            entity.Property(e => e.MailSent).HasColumnName("Mail_sent");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.ToTable("Session");

            entity.Property(e => e.Detail).HasMaxLength(50);
            entity.Property(e => e.IdSeminaire).HasColumnName("Id_seminaire");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.IdSeminaireNavigation).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.IdSeminaire)
                .HasConstraintName("FK_Session_Seminaire");
        });

        modelBuilder.Entity<Target>(entity =>
        {
            entity.ToTable("Target");

            entity.Property(e => e.Detail).HasMaxLength(50);
            entity.Property(e => e.IdSeminaire).HasColumnName("Id_seminaire");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.IdSeminaireNavigation).WithMany(p => p.Targets)
                .HasForeignKey(d => d.IdSeminaire)
                .HasConstraintName("FK_Target_Seminaire1");
        });

        modelBuilder.Entity<Theme>(entity =>
        {
            entity.ToTable("Theme");

            entity.Property(e => e.Detail).HasMaxLength(50);
            entity.Property(e => e.IdSeminaire).HasColumnName("Id_seminaire");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.IdSeminaireNavigation).WithMany(p => p.Themes)
                .HasForeignKey(d => d.IdSeminaire)
                .HasConstraintName("FK_Theme_Seminaire");
        });

        modelBuilder.Entity<Witness>(entity =>
        {
            entity.ToTable("Witness");

            entity.Property(e => e.IdMedia).HasColumnName("Id_media");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.IdMediaNavigation).WithMany(p => p.Witnesses)
                .HasForeignKey(d => d.IdMedia)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Witness_Media");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
