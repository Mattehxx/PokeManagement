namespace PokeManagement.Models.BasicModels
{
    public static class ReservationCode
    {
        private static int count;
        private static int countChar;
        private static char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public static string New()
        {
            if (count >= 100)
            {
                count = 0;
                countChar++;
                if (chars[countChar] == 'Z')
                {
                    countChar = 0;
                }
                return $"{chars[countChar] + count++}";
            }
            return $"{chars[countChar] + count++}";
        }
    }
}
