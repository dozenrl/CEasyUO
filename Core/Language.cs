using System;

namespace Assistant
{
    internal class Language
    {
        public static string CliLocName { get; internal set; }

        private static Ultima.StringList m_Cliloc;

        private static void EnsureTable()
        {
            if (m_Cliloc != null)
                return;

            string lang = (CliLocName ?? "enu").ToLower();

            try
            {
                m_Cliloc = new Ultima.StringList(lang);
            }
            catch
            {
                if (!lang.Equals("enu", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        m_Cliloc = new Ultima.StringList("enu");
                        CliLocName = "enu";
                    }
                    catch
                    {
                        m_Cliloc = null;
                    }
                }
            }

            if (CliLocName == null)
                CliLocName = lang;
        }

        internal static string GetString(LocString loc)
        {
            // LocString definitions are not available in this repository. If
            // numeric values are used they will be resolved against the
            // cliloc table otherwise ToString() is returned.
            int num;
            if (int.TryParse(loc.ToString(), out num))
                return GetString(num) ?? loc.ToString();

            return loc.ToString();
        }

        internal static string Format(LocString loc, object[] args)
        {
            string str = GetString(loc);
            return (str != null) ? string.Format(str, args) : string.Empty;
        }

        internal static string GetString(int name)
        {
            EnsureTable();
            return m_Cliloc?.GetString(name);
        }

        internal static string ClilocFormat(int num, string ext_str)
        {
            EnsureTable();

            var entry = m_Cliloc?.GetEntry(num);
            if (entry == null)
                return string.Empty;

            if (string.IsNullOrEmpty(ext_str))
                return entry.Text;

            return entry.SplitFormat(ext_str);
        }

        internal static string GetCliloc(int v)
        {
            EnsureTable();
            return m_Cliloc?.GetString(v);
        }
    }
}
