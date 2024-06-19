using BoardRoom.Models;

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

            app.MapGet("/checkout/types/{typeId}", (BoardRoomDbContext db, int typeId) =>
            {
                var paymentType = db.PaymentTypes.SingleOrDefault(p => p.Id == typeId);
                if (paymentType != null)
                {
                    return Results.Ok(paymentType);
                }
                else
                {
                    return Results.NotFound();
                }
            });
        }
    }
}
