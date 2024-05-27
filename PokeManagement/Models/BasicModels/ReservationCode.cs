namespace PokeManagement.Models.BasicModels
{
    public static class ReservationCode
    {
        private static int count;
        private static int countChar;
        private static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string New()
        {
            if (count >= 100)
            {
                count = 0;
                countChar++;
                if (chars.ElementAt(countChar).ToString() == "Z")
                {
                    countChar = 0;
                }
            }
            string countString = count++.ToString().Length < 2 ? $"0{count}" : count.ToString();
            return $"{chars.ElementAt(countChar).ToString() + countString}";
        }
    }
}
