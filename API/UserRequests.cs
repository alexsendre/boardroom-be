using BoardRoom.DTOs;
using BoardRoom.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardRoom.API
{
    public class UserRequests
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/users/{id}", (BoardRoomDbContext db, int id) =>
            {
                var user = db.Users
                    .FirstOrDefault(x => x.Id == id);

                if (user != null)
                {
                    return Results.Ok(user);
                }
                else
                {
                    return Results.NotFound();
                }
            });

            app.MapGet("/users", (BoardRoomDbContext db) =>
            {
                return db.Users.ToList();
            });

            app.MapPost("/register", (BoardRoomDbContext db, CreateUserDTO dto) =>
            {
                try
                {
                    User newUser = new()
                    { 
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        Username = dto.Username,
                        ImageUrl = dto.ImageUrl,
                        Bio = dto.Bio,
                        Email = dto.Email,
                        IsHost = dto.IsHost,
                        Uid = dto.Uid
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return Results.Created($"/users/{newUser.Id}", newUser);
                }
                catch
                {
                    return Results.BadRequest();
                }
            });

            app.MapPost("/checkuser", (BoardRoomDbContext db, UserAuthDTO authUser) =>
            {
                var userUid = db.Users.SingleOrDefault(u => u.Uid == authUser.Uid);

                if (userUid == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(userUid);
                }
            });
        }
    }
}
