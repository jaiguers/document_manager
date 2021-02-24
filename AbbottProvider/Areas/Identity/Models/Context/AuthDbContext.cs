﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DocumentManager.Areas.Identity.Models.Context
{
    public class AuthDbContext : IdentityDbContext<Users, Role, string, IdentityUserClaim<string>, UsersRoles, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {

        private static DbContextOptions<AuthDbContext> options;

        public AuthDbContext(DbContextOptions<AuthDbContext> opts)
            : base(opts)
        {
            options = opts;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("dbo");
            builder.Entity<UsersRoles>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UsersRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.Users)
                    .WithMany(r => r.UsersRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
