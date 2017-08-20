using System;
using DotLiquid;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace frep2
{
    public class ReferenceMap
    {

        private class Reference
        {
            public string Label;
            public string Mark;
            public string Category;
            
            internal static Reference Parse(string line)
            {
                string[] splitted = line.Split(":@".ToCharArray(), StringSplitOptions.None);
                if (splitted.Length == 3)
                {
                    return new Reference()
                    {
                        Label = splitted[0].Trim(),
                        Mark = splitted[1].Trim(),
                        Category = splitted[2].Trim()
                    };
                }
                return null;
            }
        }

        private Dictionary<string, List<Reference>> _Map = new Dictionary<string, List<Reference>>();

        internal static ReferenceMap CreateEmpty() { return new ReferenceMap(); }
        internal static ReferenceMap LoadFrom(string fileName)
        {
            ReferenceMap result = ReferenceMap.CreateEmpty();

            if (File.Exists(fileName))
            {
                string[] content = File.ReadAllLines(fileName);
                foreach(string line in content)
                {
                    Reference r = Reference.Parse(line);
                    if (r != null)
                    {
                        if (result._Map.ContainsKey(r.Label)) result._Map[r.Label].Add(r);
                        else result._Map.Add(r.Label, new List<Reference> { r });
                    }
                }
            }
            return result;
        }
        internal void Fill(string category, Hash h)
        {
            category = category.Trim().ToLowerInvariant();
            category = Regex.Replace(category, "[^a-z0-9]", "");

            if (this._Map.ContainsKey(category))
            {
                foreach(Reference r in this._Map[category])
                {
                    h.Add(string.Format("fundCategory@{0}", r.Mark), r.Category);
                }
            }
        }
    }
}