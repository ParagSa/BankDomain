using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Keeper_DbContext_Layer
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var adminRoleId = "382e2325-b2a8-4ba4-a232-2023c053ecd4";
            var superAdminRoleId = "a3b271f3-c5cf-4ff3-9fa1-e8475e64b189";
            var userRoleId = "cc026fb4-fecd-421f-928c-a958ba9267f4";
            //seed roles(user ,admin, super admin )
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName ="Admin",
                    Id=adminRoleId,
                    ConcurrencyStamp=adminRoleId
                }
                ,
                 new IdentityRole
                {
                    Name= "SuperAdmin",
                    NormalizedName= "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp=superAdminRoleId
                },
                  new IdentityRole
                {
                    Name= "User",
                    NormalizedName= "User",
                    Id = userRoleId,
                    ConcurrencyStamp= userRoleId
                }

            };
            //seed superAdminuser
            builder.Entity<IdentityRole>().HasData(roles);

            var superAdminId = "def7ae48-319e-4efd-bb15-651c1464c9d5";

            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@bookeeper.com",
                Email = "superadmin@bookeeper.com",
                NormalizedEmail = "superadmin@bookeeper.com".ToUpper(),
                NormalizedUserName = "superadmin@bookeeper.com".ToUpper(),
                Id = superAdminId,
            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "superadmin@123");
            builder.Entity<IdentityUser>().HasData(superAdminUser);


            //add roles to superAdminUser
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
