namespace HotelReservation
{
    public static class PriceCalcolator
    {
        public static decimal Calculator(decimal pricePerDay, int day, Seasons seasons, Discount discount)
        {
            int multiplier = (int)seasons;
            decimal price = (pricePerDay * day) * multiplier;
            decimal priceDiscount = (decimal)discount / 100;
            return price -= price * priceDiscount;
        }

        public static decimal Calculator(decimal pricePerDay, int day, Seasons seasons)
        {
            int multiplier = (int)seasons;
            decimal price = (pricePerDay * day) * multiplier;
            return price;
        }
    }
}
