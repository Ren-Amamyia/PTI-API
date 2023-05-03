namespace PTI_API.Extensions {
    public static class StringExtension {
        public static string ReplaceAll(this string s, string[] oldStrings, string newString) {
            foreach (string oldString in oldStrings) {
                s = s.Replace(oldString, newString);
            }

            return s;
        }
        
        public static string ReplaceAll(this string s, string[] oldStrings, string[] newStrings) {
            if (oldStrings.Length != newStrings.Length)
                throw new ArgumentOutOfRangeException(nameof(newStrings), "Array lengths must be equal!");
            for (int i = 0; i < oldStrings.Length; i++) {
                s = s.Replace(oldStrings[i], newStrings[i]);
            }

            return s;
        }

        public static string ApplyFunc(this string s, Func<string> func) {
            func.Invoke();

            return s;
        }
    }   
}