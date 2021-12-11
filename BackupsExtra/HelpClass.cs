namespace Lab5
{
    public static class HelpClass
    {
        // Help methods
        public static string MySubString(string source, int start, int end)
        {
            string result = "";
            for (int i = start; i < end; i++)
            {
                result += source[i];
            }
            return result;
        }
    }
}
