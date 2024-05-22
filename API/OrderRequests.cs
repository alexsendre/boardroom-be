using BoardRoom.DTOs;
using BoardRoom.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardRoom.API
{
    public class OrderRequests
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/orders/all", (BoardRoomDbContext db) =>
            {
                return db.Orders.Include(x => x.Rooms).Include(x => x.Users).Include(x => x.Items).ToList();
            });

            app.MapGet("/orders/{id}", (BoardRoomDbContext db, int id) =>
            {
                var order = db.Orders
                    .Include(x => x.Rooms)
                    .Include(x => x.Items)
                    .Include(x => x.Users)
                    .FirstOrDefault(p => p.Id == id);

                if (order == null)
                {
                    return Results.NotFound();
                }

                var response = new
                {
                    id = id,
                    total = order.Total,
                    items = order.Items.Select(item => new
                    {
                        id = item.Id,
                        name = item.Name,
                        price = item.Price,
                        imageUrl = item.ImageUrl,
                    }),
                    rooms = order.Rooms.Select(room => new
                    {
                        id = room.Id,
                        title = room.Title,
                        price = room.Price,
                        imageUrl = room.ImageUrl,
                        isLeasable = room.IsLeasable,
                    }),
                    buyer = order.Users.Select(user => new
                    {
                        id = user.Id,
                        username = user.Username,
                        firstName = user.FirstName,
                        lastName = user.LastName,
                        email = user.Email,
                    })
                };
                return Results.Ok(response);
            });

            app.MapPost("/orders/items/add", (BoardRoomDbContext db, OrderItemDTO orderItem) =>
            {
                var order = db.Orders
                    .Include(o => o.Items)
                    .FirstOrDefault(o => o.Id == orderItem.OrderId);

                if (order == null)
                {
                    return Results.NotFound();
                }

                var item = db.Items.Find(orderItem.ItemId);
                if (item == null)
                {
                    return Results.NotFound();
                }

                if (order.Items == null)
                {
                    order.Items = new List<Item>();
                }

                order.Items.Add(item);
                db.SaveChanges();

                return Results.Created($"/orders/{orderItem.OrderId}/items/{orderItem.ItemId}", item);
            });

            app.MapPost("/orders/rooms/add", (BoardRoomDbContext db, OrderRoomDTO orderRoom) =>
            {
                var order = db.Orders
                    .Include(o => o.Rooms)
                    .FirstOrDefault(o => o.Id == orderRoom.OrderId);

                if (order == null)
                {
                    return Results.NotFound();
                }

                var room = db.Rooms.Find(orderRoom.RoomId);
                if (room == null)
                {
                    return Results.NotFound();
                }

                if (order.Rooms == null)
                {
                    order.Rooms = new List<Room>();
                }

                order.Rooms.Add(room);
                db.SaveChanges();

                return Results.Created($"/orders/{orderRoom.OrderId}/rooms/{orderRoom.RoomId}", room);
            });

            app.MapDelete("/orders/{orderId}/items/{itemId}", (BoardRoomDbContext db, int orderId, int itemId) =>
            {
                var order = db.Orders
                    .Include(o => o.Items)
                    .FirstOrDefault(o => o.Id == orderId);

                if (order == null)
                {
                    return Results.NotFound();
                }

                var item = order.Items.FirstOrDefault(i => i.Id == itemId);
                if (item == null)
                {
                    return Results.NotFound();
                }

                order.Items.Remove(item);
                db.SaveChanges();

                return Results.Ok();
            });

            app.MapDelete("/orders/{orderId}/rooms/{roomId}", (BoardRoomDbContext db, int orderId, int roomId) =>
            {
                var order = db.Orders
                    .Include(o => o.Rooms)
                    .FirstOrDefault(o => o.Id == orderId);

                if (order == null)
                {
                    return Results.NotFound();
                }

                var room = order.Rooms.FirstOrDefault(r => r.Id == roomId);
                if (room == null)
                {
                    return Results.NotFound();
                }

                order.Rooms.Remove(room);
                db.SaveChanges();

                return Results.Ok();
            });

        }
    }
}
