using BetaLixT.Submissions.Functionality.Interface.Entities;
using BetaLixT.Submissions.Functionality.Interface.Entities.Unstructured;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Functionality.Implementation.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; private set; }
        public DbSet<Namespace> Namespaces { get; private set; }
        public DbSet<NamespaceAdmin> NamespaceAdmins { get; private set; }
        public DbSet<Form> Forms { get; private set; }
        public DbSet<Submission> Submissions { get; private set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().Property(user => user.Configuration).HasJsonConversion();

            modelBuilder.Entity<NamespaceAdmin>()
                .HasOne(na => na.Admin)
                .WithMany(usr => usr.NamespacesAdministered)
                .HasForeignKey(na => na.UserId);
            modelBuilder.Entity<NamespaceAdmin>()
                .HasOne(na => na.Namespace)
                .WithMany(usr => usr.Admins)
                .HasForeignKey(na => na.NamespaceId);
            modelBuilder.Entity<NamespaceAdmin>()
                .HasKey(x => new { x.NamespaceId, x.UserId });

            modelBuilder.Entity<Form>().Property(user => user.FormSchema).HasJsonConversion();
            modelBuilder.Entity<Form>()
                .HasOne(f => f.Namespace)
                .WithMany(ns => ns.Forms)
                .HasForeignKey(f => f.NamespaceId);
            modelBuilder.Entity<Form>()
                .HasKey(x => new { x.Id, x.NamespaceId });

            modelBuilder.Entity<Submission>().Property(user => user.Responses).HasJsonConversion();
            modelBuilder.Entity<Submission>()
                .HasOne(f => f.Form)
                .WithMany(ns => ns.Submissions)
                .HasForeignKey(f => new { f.FormId, f.NamespaceId });
            modelBuilder.Entity<Submission>()
                .HasKey(sub => new { sub.Id, sub.NamespaceId, sub.FormId });
        }
    }
}
