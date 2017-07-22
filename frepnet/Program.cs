using System;

namespace frepnet
{
	class Program
	{
		static void Main(string[] args)
		{
			//Settings settings = Settings.Parse(args);
			Settings settings = Settings.DummyParse();
			DataBase db = new DataBase(settings);
			Renderer renderer = new Renderer(settings);
			renderer.DataBase = db;
			renderer.Export();
		}
	}
}
