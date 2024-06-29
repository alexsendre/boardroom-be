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

            app.MapPost("/checkuser", (BoardRoomDbContext db, UserAuthDTO authUser) =>
            {
                var userUid = db.Users.SingleOrDefault(u => u.Uid == authUser.Uid);

                if (userUid == null)
                {
                    return Results.NotFound("Couldn't find user");
                }
                else
                {
                    return Results.Ok(userUid);
                }
            });

            app.MapPost("/register", async (BoardRoomDbContext db, User user) =>
            {
                var userUid = await db.Users.SingleOrDefaultAsync(u => u.Uid == user.Uid);

                if (userUid != null)
                {
                    return Results.BadRequest("Existing user");
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Results.Created($"/users/{user.Id}", user);
                }
            });

            app.MapGet("/users/{id}/orders", (BoardRoomDbContext db, int id) =>
            {
                var user = db.Users.Include(u => u.Orders).SingleOrDefault(u => u.Id == id);
                var response = new
                {
                    orderDetails = user.Orders.Select(order => new
                    {
                        id = order.Id,
                        userId = id,
                        paymentTypeId = order.PaymentTypeId,
                        address = order.Address,
                        city = order.City,
                        state = order.State,
                        isClosed = order.IsClosed,
                        CalculateTotal = order.CalculateTotal,
                    })
                };
                return Results.Ok(response);
            });
        }
    }
}
