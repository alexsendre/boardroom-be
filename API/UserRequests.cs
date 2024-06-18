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

            app.MapPost("/users/new", (BoardRoomDbContext db, CreateUserDTO dto) =>
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
                        IsSeller = dto.IsSeller,
                        Uid = dto.Uid
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return Results.Created($"/users/{newUser.Id}", newUser);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex);
                }
            });

            app.MapPatch("/users/{userId}/update", (BoardRoomDbContext db, int userId, CreateUserDTO dto) =>
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    return Results.NotFound();
                }

                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.Bio = dto.Bio;
                user.Email = dto.Email;
                user.ImageUrl = dto.ImageUrl;

                db.SaveChanges();
                return Results.Ok(user);
            });

            app.MapPost("/checkuser/{uid}", (BoardRoomDbContext db, UserAuthDTO authUser) =>
            {
                var userUid = db.Users.Where(u => u.Uid == authUser.Uid).FirstOrDefault();

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
