using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace Cafe.Infra.Data
{
    public interface ICafeContext : IDisposable
    {
        DbSet<TbAccess> TbAccess { get; set; }
        DbSet<TbMenuItem> TbMenuItem { get; set; }
        DbSet<TbOrdered> TbOrdered { get; set; }
        DbSet<TbOrderedItem> TbOrderedItem { get; set; }
        DbSet<TbTabClosed> TbTabClosed { get; set; }
        DbSet<TbTabOpened> TbTabOpened { get; set; }
        DbSet<TbTodo> TbTodo { get; set; }
        DbSet<TbWaitstaff> TbWaitstaff { get; set; }

        int SaveChanges();
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
