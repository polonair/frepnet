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
            Report result = new Report(dataBase);
            result.Template = this._Content;
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
        static bool _Removed = false;
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
                case QueryType.Q1: return _LoadQ1(settings);
                case QueryType.Q2: return _LoadQ2(settings);
                case QueryType.Q3: return _LoadQ3(settings);
                case QueryType.Q4: return _LoadQ4(settings);
                case QueryType.Q5: return _LoadQ5(settings);
                case QueryType.Q6: return _LoadQ6(settings);
                case QueryType.Q7: return _LoadQ7(settings);
                case QueryType.Q8: return _LoadQ8(settings);
                case QueryType.Q9: return _LoadQ9(settings);
                case QueryType.Q10: return _LoadQ10(settings);
                case QueryType.Q11: return _LoadQ11(settings);
                case QueryType.Q12: return _LoadQ12(settings);
                case QueryType.Q13: return _LoadQ13(settings);
                case QueryType.Q14: return _LoadQ14(settings);
                case QueryType.Q15: return _LoadQ15(settings);
                case QueryType.Q16: return _LoadQ16(settings);
                case QueryType.Q17: return _LoadQ17(settings);
                case QueryType.Q18: return _LoadQ18(settings);
                case QueryType.Q19: return _LoadQ19(settings);
                case QueryType.Q20: return _LoadQ20(settings);
                default: return null;
            }
        }
        private static Template _LoadQ1(Settings settings)
        {
            string fileName = string.Format("{0}/Query_1_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_1_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q1;
            return result;
        }
        private static Template _LoadQ2(Settings settings)
        {
            string fileName = string.Format("{0}/Query_2_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_2_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q2;
            return result;
        }
        private static Template _LoadQ3(Settings settings)
        {
            string fileName = string.Format("{0}/Query_3_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_3_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q3;
            return result;
        }
        //--
        private static Template _LoadQ4(Settings settings)
        {
            string fileName = string.Format("{0}/Query_4_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_4_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q4;
            return result;
        }
        private static Template _LoadQ5(Settings settings)
        {
            string fileName = string.Format("{0}/Query_5_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_5_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q5;
            return result;
        }
        private static Template _LoadQ6(Settings settings)
        {
            string fileName = string.Format("{0}/Query_6_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_6_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q6;
            return result;
        }
        private static Template _LoadQ7(Settings settings)
        {
            string fileName = string.Format("{0}/Query_7_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_7_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q7;
            return result;
        }
        private static Template _LoadQ8(Settings settings)
        {
            string fileName = string.Format("{0}/Query_8_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_8_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q8;
            return result;
        }
        private static Template _LoadQ9(Settings settings)
        {
            string fileName = string.Format("{0}/Query_9_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_9_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q9;
            return result;
        }
        private static Template _LoadQ10(Settings settings)
        {
            string fileName = string.Format("{0}/Query_10_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_10_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q10;
            return result;
        }
        private static Template _LoadQ11(Settings settings)
        {
            string fileName = string.Format("{0}/Query_11_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_11_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q11;
            return result;
        }
        private static Template _LoadQ12(Settings settings)
        {
            string fileName = string.Format("{0}/Query_12_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_12_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q12;
            return result;
        }
        private static Template _LoadQ13(Settings settings)
        {
            string fileName = string.Format("{0}/Query_13_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_13_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q13;
            return result;
        }
        private static Template _LoadQ14(Settings settings)
        {
            string fileName = string.Format("{0}/Query_14_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_14_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q14;
            return result;
        }
        private static Template _LoadQ15(Settings settings)
        {
            string fileName = string.Format("{0}/Query_15_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_15_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q15;
            return result;
        }
        private static Template _LoadQ16(Settings settings)
        {
            string fileName = string.Format("{0}/Query_16_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_16_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q16;
            return result;
        }
        private static Template _LoadQ17(Settings settings)
        {
            string fileName = string.Format("{0}/Query_17_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_17_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q17;
            return result;
        }
        private static Template _LoadQ18(Settings settings)
        {
            string fileName = string.Format("{0}/Query_18_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_18_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q18;
            return result;
        }
        private static Template _LoadQ19(Settings settings)
        {
            string fileName = string.Format("{0}/Query_19_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_19_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q19;
            return result;
        }
        private static Template _LoadQ20(Settings settings)
        {
            string fileName = string.Format("{0}/Query_20_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, frep2.Properties.Resources.Query_20_Default_Template);
            Template result = new Template();
            result._Content = File.ReadAllText(fileName);
            result._Type = QueryType.Q20;
            return result;
        }
    }
}