using BoardRoom.Models;
using Microsoft.EntityFrameworkCore;
using BoardRoom.DTOs;
using Microsoft.Extensions.Hosting;

namespace BoardRoom.API
{
    public class RoomRequests
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/rooms", (BoardRoomDbContext db) =>
            {
                return db.Rooms.Include(x => x.Users).Include(x => x.Tags).Include(x => x.Items).ToList();
            });

            app.MapGet("/rooms/{id}", (BoardRoomDbContext db, int id) =>
            {
                var room = db.Rooms
                    .Include(x => x.Items)
                    .Include(x => x.Tags)
                    .FirstOrDefault(p => p.Id == id);

                if (room == null)
                {
                    return Results.NotFound();
                }

                var response = new
                {
                    id = id,
                    title = room.Title,
                    price = room.Price,
                    imageUrl = room.ImageUrl,
                    description = room.Description,
                    tags = room.Tags.Select(tag => new
                    {
                        id = tag.Id,
                        label = tag.Label,
                    }),
                    items = room.Items.Select(item => new
                    {
                        id = item.Id,
                        name = item.Name,
                        price = item.Price,
                        imageUrl = item.ImageUrl,
                    })
                };
                return Results.Ok(response);
            });

            app.MapPost("/rooms/new", (Room newRoom, BoardRoomDbContext db) =>
            {
                db.Rooms.Add(newRoom);
                db.SaveChanges();

                return Results.Created($"/rooms/{newRoom.Id}", newRoom);
            });

            app.MapDelete("/rooms/{id}", (BoardRoomDbContext db, int id) =>
            {
                var room = db.Rooms.SingleOrDefault(x => x.Id == id);

                if (room == null)
                {
                    return Results.NotFound();
                }

                db.Rooms.Remove(room);
                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapPatch("/rooms/edit/{id}", (BoardRoomDbContext db, int id, Room updatedRoom) =>
            {
                Room roomToUpdate = db.Rooms.SingleOrDefault(x => x.Id == id);

                if (roomToUpdate == null)
                {
                    return Results.NotFound("Error, the room you requested was not found");
                }

                roomToUpdate.Title = updatedRoom.Title;
                roomToUpdate.ImageUrl = updatedRoom.ImageUrl;
                roomToUpdate.Price = updatedRoom.Price;
                roomToUpdate.IsLeasable = updatedRoom.IsLeasable;
                roomToUpdate.Description = updatedRoom.Description;

                db.SaveChanges();
                return Results.Created($"/rooms/edit/{updatedRoom.Id}", updatedRoom);
            });

            app.MapPost("/rooms/{roomId}/tags", (BoardRoomDbContext db, RoomTagDTO newTag) =>
            {
                var room = db.Rooms.Include(x => x.Tags).FirstOrDefault(x => x.Id == newTag.RoomId);
                var tagToAdd = db.Tags.Find(newTag.TagId);

                if (room == null || tagToAdd == null)
                {
                    return Results.NotFound();
                }

                try
                {
                    room.Tags.Add(tagToAdd);
                    db.SaveChanges();
                    return Results.Created($"/rooms/{newTag.RoomId}/tags/{newTag.TagId}", tagToAdd);
                }
                catch
                {
                    return Results.BadRequest("There was an error with the data submitted");
                }
            });

            app.MapDelete("/rooms/{roomId}/tags/{tagId}", (BoardRoomDbContext db, int roomId, int tagId) =>
            {
                var room = db.Rooms.Include(x => x.Tags).FirstOrDefault(x => x.Id == roomId);
                var tag = db.Tags.Find(tagId);

                if (room == null || tag == null)
                {
                    return Results.NotFound("Unable to find the requested data");
                }

                room.Tags.Remove(tag);
                db.SaveChanges();
                return Results.NoContent();
            });
        }
    }
}
