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

            app.MapGet("/checkout/types/{id}", (BoardRoomDbContext db, int id) =>
            {
                var paymentType = db.PaymentTypes.FirstOrDefault(x => x.Id == id);
                if (paymentType == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(paymentType);
            });
        }
    }
}
