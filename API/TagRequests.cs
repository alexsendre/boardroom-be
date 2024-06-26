﻿using BoardRoom.Models;

namespace BoardRoom.API
{
    public class TagRequests
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/tags", (BoardRoomDbContext db) =>
            {
                return db.Tags.ToList();
            });

            app.MapPost("/tags/new", (Tag newTag, BoardRoomDbContext db) =>
            {
                db.Tags.Add(newTag);
                db.SaveChanges();

                return Results.Created($"/rooms/{newTag.Id}", newTag);
            });

            app.MapGet("/tags/{id}", (BoardRoomDbContext db, int id) =>
            {
                var tag = db.Tags.FirstOrDefault(t => t.Id == id);
                return Results.Ok(tag);
            });
        }
    }
}
