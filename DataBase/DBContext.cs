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
            public DbSet<Product> Products { get; set; }

            //Model
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  // Configuración para la entidad Account
                  modelBuilder.Entity<Account>(entity =>
                  {
                        // Clave primaria
                        entity.HasKey(a => a.IdAccount);
                        
                        
                        entity.HasOne(a => a.Employee)
                        .WithOne(e => e.Account)
                        .HasForeignKey<Account>(a => a.IdEmployee)
                        .OnDelete(DeleteBehavior.Cascade); // Eliminación en cascada*/

                        // Restricciones en las columnas
                        entity.Property(a => a.Username)
                        .IsRequired();

                        entity.Property(a => a.PasswordHash)
                        .IsRequired();

                        entity.Property(a => a.LastPasswordUpdate)
                        .HasColumnName("last_password_update");
                        entity.ToTable("account");
                  });

                  // Configuración para la entidad Employee

                  modelBuilder.Entity<Employee>(entity =>
                  {
                        entity.ToTable("employee"); // Nombre exacto de la tabla en la BD

                        entity.HasKey(e => e.IdEmployee); // Clave primaria

                        entity.HasOne(e => e.Role)
                              .WithMany() // Sin relación inversa
                              .HasForeignKey(e => e.IdRole)
                              .OnDelete(DeleteBehavior.Restrict); // Puedes usar Cascade si lo prefieres
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
                        entity.ToTable("Role");
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

                        entity.ToTable("role_type");
                  });

                  modelBuilder.Entity<Product>(entity =>
                  {
                  // Configuración de clave primaria y nombre de tabla
                  entity.HasKey(p => p.IdProduct)
                        .HasName("id_product");

                  entity.ToTable("Product");

                  
                  entity.Property(p => p.IsActive)
                        .HasColumnName("is_active")
                        .HasColumnType("bit")
                        .HasDefaultValue(true); // Valor por defecto
                  });
            }
      }
}
