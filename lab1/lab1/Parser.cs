using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection.PortableExecutable;
using System.Data;
using System.Linq;

namespace lab1
{
    public class Parser
    {
        public Dictionary<string, Dictionary<string, string>> data;
        public Parser()
        {
            data = new Dictionary<string, Dictionary<string, string>>();
        }
        public string[] ParseReader(string Filename)
        {
            if (!File.Exists(Filename))
            {
                throw new Exception("No such file");
            }
            if (Path.GetExtension(Filename) != ".INI" && Path.GetExtension(Filename) != ".ini")
            {
                throw new Exception("incorrect extension");
            }
            return File.ReadAllLines(Filename);
        }
        public void Parse(string[] strings)
        {
            string curheader = "";
            string key = "";
            string value = "";
            bool f = false;
            Dictionary<string, string> section = new Dictionary<string, string>();
            foreach (string s in strings)
            {
                if (Regex.IsMatch(s, @"\[[A-Za-z0-9_]+\]"))
                {
                    if (f)
                    {
                        data.Add(curheader, section);
                    }
                    curheader = s.Replace("[", "").Replace("]", "");
                    section = new Dictionary<string, string>();
                    f = true;
                    continue;
                }

                if (Regex.IsMatch(s, @"^\s$") || Regex.IsMatch(s, @"^\s;.$"))
                {
                    continue;
                }
                var str = s.Split("=;".ToCharArray(), 3, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length > 1)
                {
                    if (Regex.IsMatch(str[0], @"[A-Za-z0-9_]") && Regex.IsMatch(str[1], @"[^\s;=]+"))
                    {
                        key = str[0].Trim();
                        value = str[1].Replace(" ", "");
                        section.Add(key, value);
                    }
                    continue;
                }

            }
            if (f)
            {
                data.Add(curheader, section);
                section.Remove(key);
            }

        }

        public T Get<T>(string sectionName, string key)
        {
            try
            {
                if (data.ContainsKey(sectionName))
                {
                    var res = data[sectionName][key];
                    return (T)Convert.ChangeType(res, typeof(T), System.Globalization.CultureInfo.InvariantCulture);
                }
                throw new Exception($"{sectionName} не найден");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
