﻿
namespace IADocumentClassifier.Infrastructure.Data
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Infrastructure.Data.Configurations;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public partial class DocumentClassifierDbContext : DbContext
    {
        DocumentClassifierDbContext()
        {
        }

        public DocumentClassifierDbContext(DbContextOptions<DocumentClassifierDbContext> options): base(options)
        {            
        }
        public virtual DbSet<DocumentsType> DocumentType { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<ClientDocumentType> ClientDocumentType { get; set; }
        public virtual DbSet<ClientTag> ClientTag { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesClient> RolesClient { get; set; }
        public virtual DbSet<RolesPermission> RolesPermission { get; set; }
        public virtual DbSet<Setup> Setup { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
