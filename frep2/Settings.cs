﻿using System;
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
            internal void Parse(
                ref string standard, 
                ref string date, 
                ref string template, 
                ref string export, 
                ref string separator, 
                ref bool help, 
                ref int shift,
                QueryRestrictions restrictors)
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
                foreach(string key in this._Parsed.Keys)
                {
                    if (key.StartsWith("-q") && key.Length > 2)
                    {
                        int q = 0;
                        if (int.TryParse(key.Substring(2), out q) && (q>=1 && q<=20))
                        {
                            QueryRestrictor r = QueryRestrictor.Parse(this._Parsed[key]);
                            if (r != null) restrictors.Add((QueryType)q, r);
                        }
                    }
                }
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
        private QueryRestrictions _Restrictions = new QueryRestrictions();

        public string Standard { get { return Path.Combine(this._CurrentDirectory, this._Standard); } }
        public string DateWiseDirectory { get { return Path.Combine(this._CurrentDirectory, this._DateWiseDirectory); } }
        public string ExportDirectory { get { return Path.Combine(Path.Combine(this._CurrentDirectory, this._ExportDirectory), this._Date); } }
        public string TemplateDirectory { get { return Path.Combine(this._CurrentDirectory, this._TemplateDirectory); } }
        public string Separator { get { return this._Separator; } }
        public int Shift { get { return this._Shift; } }
        public QueryRestrictions Restrictions { get { return this._Restrictions; } }

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

            //result.Restrictions.Add(QueryType.Q1, QueryRestrictor.Parse("v1,t1,n1"));
            result._Shift = 34;//19.08.17
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

            parser.Parse(ref result._Standard, ref result._DateWiseDirectory, ref result._TemplateDirectory, ref result._ExportDirectory, ref result._Separator, ref help, ref result._Shift, result._Restrictions);

            if (help) Settings.PrintHelp();

            return result;
        }
        private static void PrintHelp()
        {
            Console.WriteLine(
@"
Fund Reporter 2.0.7 (by fixnim specially for srinivas555)

Usage: frep.exe --standard-info=STANDARD_INFO_FILE | -s STANDARD_INFO_FILE 
                --date-wise-dir=DATE_INFO_DIR | -d DATE_INFO_DIR 
                [--template-dir=TEMPLATE_DIR | -t TEMPLATE_DIR] 
                [--export-dir=EXPORT_DIR | -x EXPORT_DIR]
                [--csv-separator=SEPARATOR | -c SEPARATOR]
                [-q(1..20)=QUERY_RESTRICTION ]

    STANDARD_INFO_FILE - csv-file with standard fund information;
    DATE_INFO_DIR      - directory with date-wise csv-files;
    TEMPLATE_DIR       - directory with templates (optional, default value './template/');
    EXPORT_DIR         - directory where to export reports (optional, default value './export/');
    SEPARATOR          - symbol used to separate values in csv (optional, default value '|');
    QUERY_RESTRICTION  - restrictions for query.

Restriction format:
    [[v|t|n]VALUE][,[t|v|n]VALUE][,[n|t|v]VALUE], for example: v200,t54,n20 means that if
    fund vrr <= 200 and tbs <= 54 and today nav <= 20 then it will be ignored for query.

Examples:
    frep.exe -s Standard.csv -d ./import
    frep.exe -s Standard.csv -d ./import -c ;
    frep.exe --standard-info=Standard.csv --date-wise-dir=./import --csv-separator=;
    frep.exe -s Standard.csv -d ./import -t ./templates -x ./export -c |
    frep.exe -s Standard.csv -d ./import -q1 v100,t5 -q2 v5,t2,n1

Note:
    - do not use directories with spaces in its' names;
    - do not use spaces in QUERY_RESTRICTION.
");
            Environment.Exit(0);
        }
    }
}