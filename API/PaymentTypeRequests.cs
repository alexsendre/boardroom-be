namespace BoardRoom.API
{
    public class PaymentTypeRequests
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/checkout/types", (BoardRoomDbContext db) =>
            {
                return db.PaymentTypes.ToList();
            });
        }
    }
}
