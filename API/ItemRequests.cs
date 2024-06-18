using BoardRoom.DTOs;
using BoardRoom.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardRoom.API
{
    public class ItemRequests
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/items", (BoardRoomDbContext db) =>
            {
                return db.Items.ToList();
            });

            app.MapGet("/items/{id}", (BoardRoomDbContext db, int id) =>
            {
                var item = db.Items
                    .Include(x => x.Rooms)
                    .FirstOrDefault(p => p.Id == id);

                if (item != null)
                {
                    return Results.Ok(item);
                }
                else
                {
                    return Results.NotFound();
                }
            });

            app.MapPost("/items/new", (BoardRoomDbContext db, Item newItem) =>
            {
                db.Items.Add(newItem);
                db.SaveChanges();

                return Results.Created($"/items/{newItem.Id}", newItem);
            });

            app.MapPatch("/items/edit/{id}", (BoardRoomDbContext db, int id, UpdateItemDTO updatedItem) =>
            {
                var itemToUpdate = db.Items.Find(id);

                if (itemToUpdate == null)
                {
                    return Results.NotFound("Error, the room you requested was not found");
                }

                itemToUpdate.Name = updatedItem.Name;
                itemToUpdate.Price = updatedItem.Price;
                itemToUpdate.ImageUrl = updatedItem.ImageUrl;

                db.SaveChanges();
                return Results.Ok(updatedItem);
            });

            app.MapDelete("/items/{id}", (BoardRoomDbContext db, int id) =>
            {
                var item = db.Items.SingleOrDefault(x => x.Id == id);

                if (item == null)
                {
                    return Results.NotFound();
                }

                db.Items.Remove(item);
                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapPost("/rooms/{roomId}/items", (BoardRoomDbContext db, Item newItem, int roomId) =>
            {
                var room = db.Rooms.Include(x => x.Tags).FirstOrDefault(x => x.Id == roomId);

                if (room == null)
                {
                    return Results.NotFound("Unable to find room");
                }

                var item = new Item
                {
                    Id = newItem.Id,
                    Name = newItem.Name,
                    Price = newItem.Price,
                    ImageUrl = newItem.ImageUrl,
                    RoomId = roomId,
                    SellerId = newItem.SellerId,
                };

                if (room.Items == null)
                {
                    room.Items = new List<Item>();
                }

                room.Items.Add(item);
                db.SaveChanges();
                return Results.Created();
            });

            app.MapDelete("/rooms/{roomId}/items/{itemId}", (BoardRoomDbContext db, int roomId, int itemId) =>
            {
                var room = db.Rooms.Include(r => r.Items).FirstOrDefault(r => r.Id == roomId);
                var item = db.Items.Find(itemId);

                if (room == null || item == null)
                {
                    return Results.NotFound("Unable to find the requested data");
                }

                room.Items.Remove(item);
                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapGet("/rooms/{roomId}/items", (BoardRoomDbContext db, int roomId) =>
            {
                var room = db.Rooms.Include(r => r.Items).FirstOrDefault(r => r.Id == roomId);
                if (room == null)
                {
                    return Results.NotFound();
                }

                var response = new
                {
                    items = room.Items.Select(item => new
                    {
                        id = item.Id,
                        name = item.Name,
                        price = item.Price,
                        imageUrl = item.ImageUrl,
                        roomId = roomId,
                    })
                };

                return Results.Ok(response);
            });
        }
    }
}
