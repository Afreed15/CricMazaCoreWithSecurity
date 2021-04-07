using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication28.Models
{
    public partial class CricMaza21Context : DbContext
    {
        public CricMaza21Context()
        {
        }

        public CricMaza21Context(DbContextOptions<CricMaza21Context> options)
            : base(options)
        {
        }

      
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<PlayerProfile> PlayerProfile { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<PointsTable> PointsTable { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Test> Test { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:cricmaza.database.windows.net,1433;Initial Catalog=CricMaza21;Persist Security Info=False;User ID=cricmaza21Y;Password=Cricmaza@21y;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.HasKey(e => e.Mid)
                    .HasName("PK__Matches__C79638C2B18808A8");

                entity.Property(e => e.Mid).ValueGeneratedNever();

                entity.Property(e => e.MatchList)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Mdate)
                    .HasColumnName("MDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mtime)
                    .IsRequired()
                    .HasColumnName("MTime")
                    .HasMaxLength(50);

                entity.Property(e => e.Team1).HasColumnName("team1");

                entity.Property(e => e.Team2).HasColumnName("team2");

                entity.Property(e => e.Venue)
                    .IsRequired()
                    .HasColumnName("venue")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Team1Navigation)
                    .WithMany(p => p.MatchesTeam1Navigation)
                    .HasForeignKey(d => d.Team1)
                    .HasConstraintName("FK__Matches__team1__0B91BA14");

                entity.HasOne(d => d.Team2Navigation)
                    .WithMany(p => p.MatchesTeam2Navigation)
                    .HasForeignKey(d => d.Team2)
                    .HasConstraintName("FK__Matches__team2__0C85DE4D");
            });

            modelBuilder.Entity<PlayerProfile>(entity =>
            {
                entity.HasKey(e => e.Profileid)
                    .HasName("PK__PlayerPr__290DB4DC09D73F94");

                entity.Property(e => e.Profileid).ValueGeneratedNever();

                entity.Property(e => e.BestBowling).HasMaxLength(10);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(50);

                entity.HasOne(d => d.P)
                    .WithMany(p => p.PlayerProfile)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK__PlayerProfi__Pid__6383C8BA");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.PlayerProfile)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("FK__PlayerProfi__Tid__628FA481");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Players__C5705938AB6DCC1B");

                entity.Property(e => e.Pid).ValueGeneratedNever();

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasColumnName("img")
                    .HasMaxLength(1000);

                entity.Property(e => e.Tplayer)
                    .IsRequired()
                    .HasColumnName("TPlayer")
                    .HasMaxLength(50);

                entity.HasOne(d => d.T)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("FK__Players__Tid__5FB337D6");
            });

            modelBuilder.Entity<PointsTable>(entity =>
            {
                entity.HasKey(e => e.Ptid)
                    .HasName("PK__PointsTa__BCC1030745CBBBF6");

                entity.Property(e => e.Ptid)
                    .HasColumnName("PTid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Loss).HasColumnName("loss");

                entity.Property(e => e.NetRate).HasColumnName("netRate");

                entity.Property(e => e.Points).HasColumnName("points");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.PointsTable)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("FK__PointsTable__Tid__03F0984C");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PK__Teams__C451DB3169DC2B47");

                entity.HasIndex(e => e.Tname)
                    .HasName("UQ__Teams__8E5169F50E9CCA1B")
                    .IsUnique();

                entity.Property(e => e.Tid).ValueGeneratedNever();

                entity.Property(e => e.Teamlogo).HasMaxLength(1000);

                entity.Property(e => e.Tname)
                    .IsRequired()
                    .HasColumnName("TName")
                    .HasMaxLength(50);

                entity.Property(e => e.Towner)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__test__A9D1053466726F31")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasColumnName("CName")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
