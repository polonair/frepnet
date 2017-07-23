using System;
using System.Collections.Generic;

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
            this._Templates = (List<Template>)Template.LoadTemplates(this._Settings);
        }
        internal void Export()
        {
            foreach (Template template in this._Templates)
            {
                template.Query(this._DataBase).Save(this._Settings);
            }
        }
    }
}