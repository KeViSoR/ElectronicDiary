using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ElectronicDiary.Entity;

public partial class SchoolDbContext : DbContext
{
    string ConnectionString { get; set; }
    public SchoolDbContext(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    public virtual DbSet<SportCategory> SportCategories { get; set; }

    public virtual DbSet<SportsmensGroup> SportsmensGroups { get; set; }

    public virtual DbSet<SportsmensSportCat> SportsmensSportCats { get; set; }

    public virtual DbSet<Stage> Stages { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC271098B9D4");

            entity.HasIndex(e => e.Name, "UQ__Departme__737584F61DD57C0A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChiefId).HasColumnName("ChiefID");
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.SportId).HasColumnName("SportID");

            entity.HasOne(d => d.Chief).WithMany(p => p.Departments)
                .HasForeignKey(d => d.ChiefId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Departments_To_Persons");

            entity.HasOne(d => d.Sport).WithMany(p => p.Departments)
                .HasForeignKey(d => d.SportId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Departments_To_Sport");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Groups__3214EC2700D51EFC");

            entity.HasIndex(e => new { e.Name, e.DepartmentId, e.TrainerId }, "UQ_Groups").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Name).HasMaxLength(5);
            entity.Property(e => e.StageId).HasColumnName("StageID");
            entity.Property(e => e.TrainerId).HasColumnName("TrainerID");

            entity.HasOne(d => d.Department).WithMany(p => p.Groups)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Groups_To_Departments");

            entity.HasOne(d => d.Stage).WithMany(p => p.Groups)
                .HasForeignKey(d => d.StageId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Groups_To_Stages");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Groups)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Groups_To_Persons");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persons__3214EC27F3490244");

            entity.HasIndex(e => new { e.LastName, e.FirstName, e.SurName, e.DateOfBirth }, "UQ_Persons").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.PlaceOfStudyOrWork).HasMaxLength(50);
            entity.Property(e => e.ReceiptDate).HasColumnType("date");
            entity.Property(e => e.SurName).HasMaxLength(20);
            entity.Property(e => e.TelNumber).HasMaxLength(13);
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sport__3214EC2722FE1699");

            entity.ToTable("Sport");

            entity.HasIndex(e => e.Name, "UQ__Sport__737584F694CAABF8").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<SportCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SportCat__3214EC272B707930");

            entity.HasIndex(e => e.Name, "UQ__SportCat__737584F6D10BA196").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(4);
        });

        modelBuilder.Entity<SportsmensGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sportsme__3214EC2712F9806E");

            entity.ToTable("SportsmensGroup");

            entity.HasIndex(e => new { e.PersonsId, e.GroupId }, "UQ_SportsmensGroup").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.PersonsId).HasColumnName("PersonsID");

            entity.HasOne(d => d.Group).WithMany(p => p.SportsmensGroups)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_SportsmensGroup_To_Groups");

            entity.HasOne(d => d.Persons).WithMany(p => p.SportsmensGroups)
                .HasForeignKey(d => d.PersonsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sportsmen__Perso__5535A963");
        });

        modelBuilder.Entity<SportsmensSportCat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sportsme__3214EC2730E82F07");

            entity.ToTable("SportsmensSportCat");

            entity.HasIndex(e => new { e.PersonsId, e.SportId }, "UQ_SportsmensSportCat").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateOfAssignmentSc)
                .HasColumnType("date")
                .HasColumnName("DateOfAssignmentSC");
            entity.Property(e => e.PersonsId).HasColumnName("PersonsID");
            entity.Property(e => e.SportCatId).HasColumnName("SportCatID");
            entity.Property(e => e.SportId).HasColumnName("SportID");

            entity.HasOne(d => d.Persons).WithMany(p => p.SportsmensSportCats)
                .HasForeignKey(d => d.PersonsId)
                .HasConstraintName("FK_SportsmensSportCat_To_Persons");

            entity.HasOne(d => d.SportCat).WithMany(p => p.SportsmensSportCats)
                .HasForeignKey(d => d.SportCatId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_SportsmensSportCat_To_SportCategories");

            entity.HasOne(d => d.Sport).WithMany(p => p.SportsmensSportCats)
                .HasForeignKey(d => d.SportId)
                .HasConstraintName("FK_SportsmensSportCat_To_Sport");
        });

        modelBuilder.Entity<Stage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stages__3214EC27D4DDA831");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(60);
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trainers__3214EC27629966CA");

            entity.HasIndex(e => e.TrainerPassword, "UQ__Trainers__550E157DD7005CDF").IsUnique();

            entity.HasIndex(e => e.PersonsId, "UQ__Trainers__731B5C3F67D90D2F").IsUnique();

            entity.HasIndex(e => e.TrainerLogin, "UQ__Trainers__91BCC6F6390CC541").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PersonsId).HasColumnName("PersonsID");
            entity.Property(e => e.TrainerLogin).HasMaxLength(30);
            entity.Property(e => e.TrainerPassword).HasMaxLength(30);

            entity.HasOne(d => d.Persons).WithOne(p => p.Trainer)
                .HasForeignKey<Trainer>(d => d.PersonsId)
                .HasConstraintName("FK_Trainers_To_Persons");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
