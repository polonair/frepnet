using System;
using System.Collections.Generic;
using System.Text;

namespace frepnet
{
	class Renderer
	{
		private Settings _Settings;
		private DataBase _DataBase;
		private List<Template> _Templates;

		public DataBase DataBase { get { return this._DataBase; } set { this._DataBase = value; } }

		public Renderer(Settings settings)
		{
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
