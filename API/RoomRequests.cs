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
                    imageUrl = room.ImageUrl,
                    description = room.Description,
                    location = room.Location,
                    sellerId = room.SellerId,
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

            app.MapPost("/rooms/new", (Room roomObj, BoardRoomDbContext db) =>
            {
                Room newRoom = new Room();
                newRoom.Title = roomObj.Title;
                newRoom.Description = roomObj.Description;
                newRoom.Location = roomObj.Location;
                newRoom.ImageUrl = roomObj.ImageUrl;
                newRoom.SellerId = roomObj.SellerId;

                newRoom.Tags = new List<Tag>();
                foreach (var tag in roomObj.Tags)
                {
                    Tag selectedTag = db.Tags.SingleOrDefault(t => t.Id == tag.Id);
                    newRoom.Tags.Add(selectedTag);
                }

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
                roomToUpdate.Description = updatedRoom.Description;
                roomToUpdate.Location = updatedRoom.Location;

                if (updatedRoom.Tags != null)
                {
                    roomToUpdate.Tags = new List<Tag>();

                    foreach (var tag in updatedRoom.Tags)
                    {
                        var newTag = db.Tags.SingleOrDefault(t => t.Id == tag.Id);
                        roomToUpdate.Tags.Add(newTag);
                    }
                }

                db.SaveChanges();
                return Results.Created($"/rooms/edit/{updatedRoom.Id}", updatedRoom);
            });

            app.MapPost("/rooms/{roomId}/tags", (BoardRoomDbContext db, RoomTagDTO newTag) =>
            {
                Room room = db.Rooms.Include(x => x.Tags).SingleOrDefault(x => x.Id == newTag.RoomId);
                Tag tag = db.Tags.SingleOrDefault(x => x.Id == newTag.TagId);

                if (room == null)
                {
                    return Results.BadRequest();
                }

                try
                {
                    room.Tags.Add(tag);
                    db.SaveChanges();
                    return Results.Ok(newTag);
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
