using System.IO;

namespace frep2
{
    internal class IndividualTemplate : Template
    {
        public IndividualTemplate(Settings settings)
        {
            RemoveDirectory(settings.TemplateDirectory);
            if (!Directory.Exists(settings.TemplateDirectory)) Directory.CreateDirectory(settings.TemplateDirectory);
            string fileName = string.Format("{0}/Individual_Query_Default_Template.dlt", settings.TemplateDirectory);
            if (!File.Exists(fileName)) File.WriteAllText(fileName, TemplateFile.Individual_Query_Default_Template);
            this._Content = File.ReadAllText(fileName);
        }
        internal override Report Query(DataBase dataBase)
        {
            IndividualReport report = new IndividualReport(dataBase);
            report.Template = this._Content;
            return report;
        }
    }
}