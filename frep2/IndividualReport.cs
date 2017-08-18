using System.IO;
using System.Collections.Generic;
using System;
using System.Threading;

namespace frep2
{
    internal class IndividualReport : Report
    {
        public IndividualReport(DataBase database) : base(database) { }
        public override void Save(Settings settings)
        {
            if (this._Template != null)
            {
                DotLiquid.Template.NamingConvention = new DotLiquid.NamingConventions.CSharpNamingConvention();
                //DotLiquid.Template template = DotLiquid.Template.Parse(this._Template);

                int count = 0;
                object locker = new object();
                foreach (string fid in this._DataBase.Data.Keys)
                {
                    lock (locker) count++;
                    ThreadPool.QueueUserWorkItem(new WaitCallback((object o) =>
                    {
                        this._Render(settings, fid);
                        lock (locker) count--;
                    }));
                }
                while (count > 0) Thread.Sleep(1000);
            }
        }
        private void _Render(Settings settings, string fid)
        {
            DotLiquid.Template template = DotLiquid.Template.Parse(this._Template);
            string subdir = fid.Substring(0, fid.Length - 3);
            string fn = string.Format("{0}.html", fid);
            fn = this.EscapeFileName(fn);
            Dictionary<string, object> env = new Dictionary<string, object>();
            env.Add("currentFund", this._DataBase.Data[fid]);
            env.Add("date", DateTime.Now);
            env.Add("datestamp", DateTime.Now);
            env.Add("timestamp", string.Format("{0:hh.mm tt }", DateTime.Now));
            string content = template.Render(DotLiquid.Hash.FromDictionary(env));
            string dir = settings.ExportDirectory;
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            dir += "/funds";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            dir += "/" + subdir;
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            File.WriteAllText(string.Format("{0}/{1}", dir, fn), content);
        }
    }
}