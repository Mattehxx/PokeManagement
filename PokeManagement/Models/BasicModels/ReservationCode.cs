namespace PokeManagement.Models.BasicModels
{
    public static class ReservationCode
    {
        private static int count;
        public static int New()
        {
            if (count > 100)
            {
                count = 0;
                return count++;
            }
            return count++;
        }
    }
}
