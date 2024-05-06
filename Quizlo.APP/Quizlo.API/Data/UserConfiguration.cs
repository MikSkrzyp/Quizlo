using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Quizlo.API.Model.Domain;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var hasher = new PasswordHasher<User>();

        builder.HasData(new User
        {
            Id = "admin-user-id",
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "zaq1@WSX"),
            FirstName = "Admin",
            LastName = "User"
        });
    }
}
