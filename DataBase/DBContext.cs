using System;
using BroasterWebApp;
using BroasterWebApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BroasterWebApp.DataBase
{
      public class DBContext : DbContext
      {
            public DBContext(DbContextOptions<DBContext> options) : base(options) { }

            //Entities:
            public DbSet<Account> Accounts { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<RoleType> RoleTypes { get; set; }




            //Model

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  // Configuración para la entidad Account
                  modelBuilder.Entity<Account>(entity =>
                  {
                        // Clave primaria
                        entity.HasKey(a => a.IdAccount);

                        // Relación con Employee (uno a uno)
                        entity.HasOne(a => a.Employee)
                        .WithOne(e => e.Account)
                        .HasForeignKey<Account>(a => a.IdEmployee)
                        .OnDelete(DeleteBehavior.Cascade); // Eliminación en cascada

                        // Restricciones en las columnas
                        entity.Property(a => a.Username)
                        .IsRequired()
                        .HasMaxLength(50);

                        entity.Property(a => a.PasswordHash)
                        .IsRequired()
                        .HasMaxLength(255);

                        entity.Property(a => a.LastPasswordUpdate)
                        .HasColumnName("last_password_update");
                  });

                  // Configuración para la entidad Employee
                  modelBuilder.Entity<Employee>(entity =>
                  {
                        // Clave primaria
                        entity.HasKey(e => e.IdEmployee);

                        // Relación con Role (muchos a uno)
                        entity.HasOne(e => e.Role)
                        .WithMany(r => r.Employees)
                        .HasForeignKey(e => e.IdRole)
                        .OnDelete(DeleteBehavior.Restrict); // No eliminar roles si hay empleados asociados

                        // Restricciones en las columnas
                        entity.Property(e => e.FirstName)
                        .IsRequired()
                        .HasMaxLength(50);

                        entity.Property(e => e.LastName)
                        .IsRequired()
                        .HasMaxLength(50);

                        entity.Property(e => e.Email)
                        .HasMaxLength(100);

                        entity.Property(e => e.HireDate)
                        .HasColumnName("hire_date");
                        
                        entity.ToTable("Employee");

                  });

                  // Configuración para la entidad Role
                  modelBuilder.Entity<Role>(entity =>
                  {
                        // Clave primaria
                        entity.HasKey(r => r.IdRole);

                        // Relación con RoleType (muchos a uno)
                        entity.HasOne(r => r.RoleType)
                        .WithMany(rt => rt.Roles)
                        .HasForeignKey(r => r.IdRoleType)
                        .OnDelete(DeleteBehavior.Restrict); // No eliminar tipos de rol si hay roles asociados

                        // Restricciones en las columnas
                        entity.Property(r => r.IdRoleType)
                        .IsRequired();
                  });

                  // Configuración para la entidad RoleType
                  modelBuilder.Entity<RoleType>(entity =>
                  {
                        // Clave primaria
                        entity.HasKey(rt => rt.IdRoleType);

                        // Restricciones en las columnas
                        entity.Property(rt => rt.TypeRole)
                        .IsRequired()
                        .HasMaxLength(50);
                  });
            }
      }
}
