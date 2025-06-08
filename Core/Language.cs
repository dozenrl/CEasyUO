using System;

namespace Assistant
{
    internal class Language
    {
        public static string CliLocName { get; internal set; }

        private static Ultima.StringList m_Cliloc;
        private static string m_LoadedLang;

        private static void EnsureCliloc()
        {
            var lang = string.IsNullOrWhiteSpace(CliLocName) ? "enu" : CliLocName.ToLower();

            if (m_Cliloc == null || !string.Equals(m_LoadedLang, lang, StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    m_Cliloc = new Ultima.StringList(lang);
                    m_LoadedLang = lang;
                }
                catch
                {
                    m_Cliloc = null;
                }
            }
        }

        internal static string GetString(LocString loc)
        {
            if (loc == null)
                return string.Empty;

            return loc.ToString();
        }

        internal static string Format(LocString loc, params object[] args)
        {
            return string.Format(GetString(loc), args);
        }

        internal static string GetString(int name)
        {
            EnsureCliloc();
            return m_Cliloc?.GetString(name) ?? string.Empty;
        }

        internal static string ClilocFormat(int num, string ext_str)
        {
            EnsureCliloc();
            var entry = m_Cliloc?.GetEntry(num);
            if (entry == null)
                return num.ToString();

            if (string.IsNullOrEmpty(ext_str))
                return entry.Text;

            return entry.SplitFormat(ext_str);
        }

        internal static string GetCliloc(int v)
        {
            return GetString(v);
        }
    }
}