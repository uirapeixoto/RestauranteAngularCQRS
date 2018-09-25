using Microsoft.EntityFrameworkCore;

namespace Cafe.Infra.Data
{
    public partial class CafeContext : DbContext
    {
        public CafeContext()
        {
        }

        public CafeContext(DbContextOptions<CafeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<TbAccess> TbAccess { get; set; }
        public virtual DbSet<TbMenuItem> TbMenuItem { get; set; }
        public virtual DbSet<TbOrdered> TbOrdered { get; set; }
        public virtual DbSet<TbOrderedItem> TbOrderedItem { get; set; }
        public virtual DbSet<TbTabClosed> TbTabClosed { get; set; }
        public virtual DbSet<TbTabOpened> TbTabOpened { get; set; }
        public virtual DbSet<TbTodo> TbTodo { get; set; }
        public virtual DbSet<TbWaitstaff> TbWaitstaff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=NBO1340\\SQLEXPRESS;Database=DB_CAFE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<TbAccess>(entity =>
            {
                entity.ToTable("TB_ACCESS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DsEmail)
                    .IsRequired()
                    .HasColumnName("DS_EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsLastName)
                    .IsRequired()
                    .HasColumnName("DS_LAST_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsName)
                    .IsRequired()
                    .HasColumnName("DS_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsPassword)
                    .IsRequired()
                    .HasColumnName("DS_PASSWORD")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsPerfil)
                    .IsRequired()
                    .HasColumnName("DS_PERFIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DtAccess)
                    .HasColumnName("DT_ACCESS")
                    .HasColumnType("datetime");

                entity.Property(e => e.StActive).HasColumnName("ST_ACTIVE");
            });

            modelBuilder.Entity<TbMenuItem>(entity =>
            {
                entity.ToTable("TB_MENU_ITEM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DsDescription)
                    .IsRequired()
                    .HasColumnName("DS_DESCRIPTION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreated)
                    .HasColumnName("DT_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("DT_UPDATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.NuMenuItem).HasColumnName("NU_MENU_ITEM");

                entity.Property(e => e.NuPrice).HasColumnName("NU_PRICE");

                entity.Property(e => e.StActive).HasColumnName("ST_ACTIVE");

                entity.Property(e => e.StIsDrink).HasColumnName("ST_IS_DRINK");
            });

            modelBuilder.Entity<TbOrdered>(entity =>
            {
                entity.ToTable("TB_ORDERED");

                entity.HasIndex(e => e.IdTabOpened)
                    .HasName("IX_ID_TAB_OPENED");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DtService)
                    .HasColumnName("DT_SERVICE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdTabOpened).HasColumnName("ID_TAB_OPENED");

                entity.HasOne(d => d.IdTabOpenedNavigation)
                    .WithMany(p => p.TbOrdered)
                    .HasForeignKey(d => d.IdTabOpened)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TB_ORDERED_dbo.TB_TAB_OPENED_ID_TAB_OPENED");
            });

            modelBuilder.Entity<TbOrderedItem>(entity =>
            {
                entity.ToTable("TB_ORDERED_ITEM");

                entity.HasIndex(e => e.IdMenuItem)
                    .HasName("IX_ID_MENU_ITEM");

                entity.HasIndex(e => e.IdOrdered)
                    .HasName("IX_ID_ORDERED");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DsDescription)
                    .HasColumnName("DS_DESCRIPTION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DtInPreparation)
                    .HasColumnName("DT_IN_PREPARATION")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtServed)
                    .HasColumnName("DT_SERVED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtService)
                    .HasColumnName("DT_SERVICE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtToServe)
                    .HasColumnName("DT_TO_SERVE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdMenuItem).HasColumnName("ID_MENU_ITEM");

                entity.Property(e => e.IdOrdered).HasColumnName("ID_ORDERED");

                entity.Property(e => e.NuAmount).HasColumnName("NU_AMOUNT");

                entity.Property(e => e.NuPriceAdjustiment).HasColumnName("NU_PRICE_ADJUSTIMENT");

                entity.HasOne(d => d.IdMenuItemNavigation)
                    .WithMany(p => p.TbOrderedItem)
                    .HasForeignKey(d => d.IdMenuItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TB_ORDERED_ITEM_dbo.TB_MENU_ITEM_ID_MENU_ITEM");

                entity.HasOne(d => d.IdOrderedNavigation)
                    .WithMany(p => p.TbOrderedItem)
                    .HasForeignKey(d => d.IdOrdered)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TB_ORDERED_ITEM_dbo.TB_ORDERED_ID_ORDERED");
            });

            modelBuilder.Entity<TbTabClosed>(entity =>
            {
                entity.ToTable("TB_TAB_CLOSED");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DtService)
                    .HasColumnName("DT_SERVICE")
                    .HasColumnType("datetime");

                entity.Property(e => e.NuAmountPaid).HasColumnName("NU_AMOUNT_PAID");

                entity.Property(e => e.NuOrderValue).HasColumnName("NU_ORDER_VALUE");

                entity.Property(e => e.NuTipValue).HasColumnName("NU_TIP_VALUE");
            });

            modelBuilder.Entity<TbTabOpened>(entity =>
            {
                entity.ToTable("TB_TAB_OPENED");

                entity.HasIndex(e => e.IdWaiter)
                    .HasName("IX_ID_WAITER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DtService)
                    .HasColumnName("DT_SERVICE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdWaiter).HasColumnName("ID_WAITER");

                entity.Property(e => e.NuTable).HasColumnName("NU_TABLE");

                entity.Property(e => e.StActive).HasColumnName("ST_ACTIVE");

                entity.Property(e => e.StUniqueIdentifier).HasColumnName("ST_UNIQUE_IDENTIFIER");

                entity.HasOne(d => d.IdWaiterNavigation)
                    .WithMany(p => p.TbTabOpened)
                    .HasForeignKey(d => d.IdWaiter)
                    .HasConstraintName("FK_dbo.TB_TAB_OPENED_dbo.TB_WAITSTAFF_ID_WAITER");
            });

            modelBuilder.Entity<TbTodo>(entity =>
            {
                entity.ToTable("TB_TODO");

                entity.HasIndex(e => e.IdTabOpened)
                    .HasName("IX_ID_TAB_OPENED");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DtService)
                    .HasColumnName("DT_SERVICE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdOrdered).HasColumnName("ID_ORDERED");

                entity.Property(e => e.IdTabOpened).HasColumnName("ID_TAB_OPENED");

                entity.HasOne(d => d.IdTabOpenedNavigation)
                    .WithMany(p => p.TbTodo)
                    .HasForeignKey(d => d.IdTabOpened)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TB_TODO_dbo.TB_TAB_OPENED_ID_TAB_OPENED");
            });

            modelBuilder.Entity<TbWaitstaff>(entity =>
            {
                entity.ToTable("TB_WAITSTAFF");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DsName)
                    .IsRequired()
                    .HasColumnName("DS_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreated)
                    .HasColumnName("DT_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("DT_UPDATED")
                    .HasColumnType("datetime");
            });
        }
    }
}
