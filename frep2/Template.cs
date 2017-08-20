using frep2.Properties;
using System;
using System.Collections.Generic;
using System.IO;

namespace frep2
{
    internal class Template
    {

        protected string _Content;
        private QueryType _Type;

        internal virtual Report Query(DataBase dataBase)
        {
            Report result = new Report(dataBase) { Template = this._Content };
            IEnumerable<QueryResult> data = dataBase.Query(this._Type);
            foreach (QueryResult r in data) result.AddResult(r);
            return result;
        }

        internal static IEnumerable<Template> LoadTemplates(Settings settings)
        {
            RemoveDirectory(settings.TemplateDirectory);
            List<Template> result = new List<Template>();
            for (int i = 1; i <= 20; i++)
            {
                Template t = _Load(settings, (QueryType)i);
                if (t != null) result.Add(t);
            }
            return result;
        }
#if DEBUG
        static bool _Removed = false;
#endif
        protected static void RemoveDirectory(string templateDirectory)
        {
#if DEBUG
            if (!_Removed && Directory.Exists(templateDirectory)) Directory.Delete(templateDirectory, true);
            _Removed = true;
#endif
        }
        private static Template _Load(Settings settings, QueryType queryType)
        {
            if (!Directory.Exists(settings.TemplateDirectory)) Directory.CreateDirectory(settings.TemplateDirectory);
            switch (queryType)
            {
                case QueryType.Q1:
                    return _LoadQX(settings, "Query_1_Default_Template.dlt", Resources.Query_1_Default_Template, queryType);
                case QueryType.Q2:
                    return _LoadQX(settings, "Query_2_Default_Template.dlt", Resources.Query_2_Default_Template, queryType);
                case QueryType.Q3:
                    return _LoadQX(settings, "Query_3_Default_Template.dlt", Resources.Query_3_Default_Template, queryType);
                case QueryType.Q4:
                    return _LoadQX(settings, "Query_4_Default_Template.dlt", Resources.Query_4_Default_Template, queryType);
                case QueryType.Q5:
                    return _LoadQX(settings, "Query_5_Default_Template.dlt", Resources.Query_5_Default_Template, queryType);
                case QueryType.Q6:
                    return _LoadQX(settings, "Query_6_Default_Template.dlt", Resources.Query_6_Default_Template, queryType);
                case QueryType.Q7:
                    return _LoadQX(settings, "Query_7_Default_Template.dlt", Resources.Query_7_Default_Template, queryType);
                case QueryType.Q8:
                    return _LoadQX(settings, "Query_8_Default_Template.dlt", Resources.Query_8_Default_Template, queryType);
                case QueryType.Q9:
                    return _LoadQX(settings, "Query_9_Default_Template.dlt", Resources.Query_9_Default_Template, queryType);
                case QueryType.Q10:
                    return _LoadQX(settings, "Query_10_Default_Template.dlt", Resources.Query_10_Default_Template, queryType);
                case QueryType.Q11:
                    return _LoadQX(settings, "Query_11_Default_Template.dlt", Resources.Query_11_Default_Template, queryType);
                case QueryType.Q12:
                    return _LoadQX(settings, "Query_12_Default_Template.dlt", Resources.Query_12_Default_Template, queryType);
                case QueryType.Q13:
                    return _LoadQX(settings, "Query_13_Default_Template.dlt", Resources.Query_13_Default_Template, queryType);
                case QueryType.Q14:
                    return _LoadQX(settings, "Query_14_Default_Template.dlt", Resources.Query_14_Default_Template, queryType);
                case QueryType.Q15:
                    return _LoadQX(settings, "Query_15_Default_Template.dlt", Resources.Query_15_Default_Template, queryType);
                case QueryType.Q16:
                    return _LoadQX(settings, "Query_16_Default_Template.dlt", Resources.Query_16_Default_Template, queryType);
                case QueryType.Q17:
                    return _LoadQX(settings, "Query_17_Default_Template.dlt", Resources.Query_17_Default_Template, queryType);
                case QueryType.Q18:
                    return _LoadQX(settings, "Query_18_Default_Template.dlt", Resources.Query_18_Default_Template, queryType);
                case QueryType.Q19:
                    return _LoadQX(settings, "Query_19_Default_Template.dlt", Resources.Query_19_Default_Template, queryType);
                case QueryType.Q20:
                    return _LoadQX(settings, "Query_20_Default_Template.dlt", Resources.Query_20_Default_Template, queryType);
                default: return null;
            }
        }
        private static Template _LoadQX(Settings settings, string filename, string filecontent, QueryType type)
        {
            string fileName = string.Format("{0}/{1}", settings.TemplateDirectory, filename);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, filecontent);
            Template result = new Template()
            {
                _Content = File.ReadAllText(fileName),
                _Type = type
            };
            return result;
        }
    }
}
