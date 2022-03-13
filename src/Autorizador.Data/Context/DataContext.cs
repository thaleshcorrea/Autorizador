using Autorizador.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorizador.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Aplicativo> Aplicativos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                bool existeDataCadastro = entry.Entity.GetType().GetProperty("DataCadastro") != null;
                bool existeDataModificado = entry.Entity.GetType().GetProperty("DataModificado") != null;
                if (entry.State == EntityState.Added && existeDataCadastro)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified && existeDataCadastro)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }

                if(entry.State == EntityState.Modified && existeDataModificado)
                {
                    entry.Property("DataModificado").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
