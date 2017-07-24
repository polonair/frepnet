using System;
using System.Collections.Generic;
using System.IO;

namespace frep2
{
    internal class Settings
    {
        private class Parser
        {
            private string _Arguments = null;
            private Dictionary<string, string> _Parsed = new Dictionary<string, string>();

            public Parser(string[] args)
            {
                if (args.Length < 1) Settings.PrintHelp();
                this._Arguments = Environment.CommandLine.Substring(Environment.CommandLine.IndexOf(args[0]));
            }
            internal void Parse(ref string standard, ref string date, ref string template, ref string export, ref string separator, ref bool help, ref int shift)
            {
                string[] args = this._Arguments.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < args.Length; i++)
                {
                    string key;
                    string val;
                    if (args[i].Contains("="))
                    {
                        string[] pair = args[i].Split("=".ToCharArray(), StringSplitOptions.None);
                        key = pair[0];
                        val = pair[1];
                    }
                    else
                    {
                        key = args[i];
                        val = args[i + 1];
                        i++;
                    }
                    if (!this._Parsed.ContainsKey(key)) this._Parsed.Add(key, val);
                }

                if (this._Parsed.ContainsKey("--standard-info")) standard = this._Parsed["--standard-info"];
                if (this._Parsed.ContainsKey("-s")) standard = this._Parsed["-s"];
                if (this._Parsed.ContainsKey("--date-wise-dir")) date = this._Parsed["--date-wise-dir"];
                if (this._Parsed.ContainsKey("-d")) date = this._Parsed["-d"];
                if (this._Parsed.ContainsKey("--template-dir")) template = this._Parsed["--template-dir"];
                if (this._Parsed.ContainsKey("-t")) template = this._Parsed["-t"];
                if (this._Parsed.ContainsKey("--export-dir")) export = this._Parsed["--export-dir"];
                if (this._Parsed.ContainsKey("-x")) export = this._Parsed["-x"];
                if (this._Parsed.ContainsKey("--csv-separator")) separator = this._Parsed["--csv-separator"];
                if (this._Parsed.ContainsKey("-c")) separator = this._Parsed["-c"];
                if (this._Parsed.ContainsKey("--shift"))
                {
                    if (!int.TryParse(this._Parsed["--shift"], out shift))
                    {
                        shift = 0;
                        Console.WriteLine("Warning: Specified shift value '{0}' cannot parsed to int, assume shift = 0", this._Parsed["--shift"]);
                    }
                }
                if (this._Parsed.ContainsKey("--help")) help = true;
                if (this._Parsed.ContainsKey("-h")) help = true;
            }
        }

        private string _Standard;
        private string _DateWiseDirectory;
        private string _TemplateDirectory;
        private string _ExportDirectory;
        private string _CurrentDirectory;
        private string _Separator;
        private string _Date;
        private int _Shift;

        public string Standard { get { return Path.Combine(this._CurrentDirectory, this._Standard); } }
        public string DateWiseDirectory { get { return Path.Combine(this._CurrentDirectory, this._DateWiseDirectory); } }
        public string ExportDirectory { get { return Path.Combine(Path.Combine(this._CurrentDirectory, this._ExportDirectory), this._Date); } }
        public string TemplateDirectory { get { return Path.Combine(this._CurrentDirectory, this._TemplateDirectory); } }
        public string Separator { get { return this._Separator; } }
        public int Shift { get { return this._Shift; } }

        private Settings()
        {
            this._CurrentDirectory = Environment.CurrentDirectory;
            this._Date = string.Format("{0:dd-MM-yy}", DateTime.Now);
        }
        internal static Settings DummyParse()
        {
            Settings result = new Settings();
            result._Standard = "standard.csv";
            result._DateWiseDirectory = "./import/";
            result._TemplateDirectory = "./templates/";
            result._ExportDirectory = string.Format("./export/", DateTime.Now);
            result._Separator = "|";
            result._Shift = 8;//24.07.17
            return result;
        }
        internal static Settings Parse(string[] args)
        {
            Settings result = new Settings();
            result._Standard = "";
            result._DateWiseDirectory = "";
            result._TemplateDirectory = "./templates/";
            result._ExportDirectory = string.Format("./export/", DateTime.Now);
            result._Separator = "|";
            result._Shift = 0;
            bool help = false;

            Parser parser = new Parser(args);

            parser.Parse(ref result._Standard, ref result._DateWiseDirectory, ref result._TemplateDirectory, ref result._ExportDirectory, ref result._Separator, ref help, ref result._Shift);

            if (help) Settings.PrintHelp();

            return result;
        }
        private static void PrintHelp()
        {
            Console.WriteLine(
@"
Fund Reporter 2.0.2 (by fixnim specially for srinivas555)

Usage: frep.exe --standard-info=STANDARD_INFO_FILE | -s STANDARD_INFO_FILE 
                --date-wise-dir=DATE_INFO_DIR | -d DATE_INFO_DIR 
                [--template-dir=TEMPLATE_DIR | -t TEMPLATE_DIR] 
                [--export-dir=EXPORT_DIR | -x EXPORT_DIR]
                [--csv-separator=SEPARATOR | -c SEPARATOR]

    STANDARD_INFO_FILE - csv-file with standard fund information;
    DATE_INFO_DIR      - directory with date-wise csv-files;
    TEMPLATE_DIR       - directory with templates (optional, default value './template/');
    EXPORT_DIR         - directory where to export reports (optional, default value './export/');
    SEPARATOR          - symbol used to separate values in csv (optional, default value '|').

Examples:    
    frep.exe -s Standard.csv -d ./import
    frep.exe -s Standard.csv -d ./import -c ;
    frep.exe --standard-info=Standard.csv --date-wise-dir=./import --csv-separator=;
    frep.exe -s Standard.csv -d ./import -t ./templates -x ./export -c |

Note:
    Do not use directory names with spaces.
");
            Environment.Exit(0);
        }
    }
}