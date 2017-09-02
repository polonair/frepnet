using System;
using System.Collections.Generic;
using System.Threading;

namespace frep2
{
    internal class Renderer
    {
        private DataBase _DataBase;
        private Settings _Settings;
        private List<Template> _Templates;

        public Renderer(DataBase database, Settings settings)
        {
            this._DataBase = database;
            this._Settings = settings;
            this._Templates = new List<Template> { new IndividualTemplate(this._Settings) };
            this._Templates.AddRange(Template.LoadTemplates(this._Settings));
        }
        internal void Export()
        {
            int count = 0;
            object locker = new object();
            foreach (Template template in this._Templates)
            {
                lock (locker) count++;
                ThreadPool.QueueUserWorkItem(new WaitCallback((object o) =>
                {
                    template.Query(this._DataBase).Save(this._Settings);
                    lock (locker) count--;
                }));
            }
            while (count > 0) Thread.Sleep(1000);
        }
    }
}
