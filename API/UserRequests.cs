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
        }
    }
}
