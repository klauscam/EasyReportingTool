using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backgrid
{
    public class Column
    {
        public string name { get; set; } //the database field name
        public string label { get; set; } //visible name
        public string cell { get; set; } //type: string, number, date, uri, email, time, datetime

        public static string getType(string dbtype) {
            
            switch (dbtype)
            {
                case "string":
                case "String":
                    return "string";
                    break;
                case "Int32": return "number";
                    break;
                case "Int16": return "number";
                    break;
                case "Int64": return "number";
                    break;
                case "DateTime": return "datetime";
                    break;
            }
            return "string";
        }
    }

    public class ResultSet
    {

    }
}
