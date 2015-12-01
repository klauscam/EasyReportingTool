using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace EasyReportingTool
{
    public class QueryResult
    {
        public static string GenerateQuery(string guid, out string dataout, out string columnsout)
        {
            Query q = null;
            using (DataClasses1DataContext dc = new DataClasses1DataContext())
            {
                var query = (from c in dc.Queries
                             where c.GUID == guid
                             select c).SingleOrDefault();
                q = query;
            }


            string connectionString =
           "Data Source=" + q.server + ";Initial Catalog=" + q.catalog + ";Persist Security Info=True;User ID="+q.username+";Password="+q.password;

            string queryString = q.sql;

            List<string> result = new List<string>();
            List<Backgrid.Column> columns = new List<Backgrid.Column>();

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        for (var x = 0; x < reader.FieldCount; x++)
                        {
                            columns.Add(new Backgrid.Column() { name = reader.GetName(x), label = reader.GetName(x), cell = Backgrid.Column.getType(reader.GetFieldType(x).Name.ToString()) });
                        }

                          while (reader.Read())
                        {

                            string row = "{";
                            for (var x = 0; x < reader.FieldCount; x++)
                            {
                                if (columns[x].cell == "number")
                                {
                                    if (Convert.IsDBNull(reader[x]) == false)
                                    {
                                        row = row + "\"" + columns[x].name + "\"" + ":" + reader[x] + "";
                                    }
                                    else row = row + "\"" + columns[x].name + "\"" + ":" + "null" + "";
                                }
                                else if ((columns[x].cell == "date") || (columns[x].cell == "datetime"))
                                {
                                    if (Convert.IsDBNull(reader[x]) == false)
                                    {

                                        row = row + "\"" + columns[x].name + "\"" + ":\"" + ((DateTime)reader[x]).ToString("yyyy-MM-dd") + "\"";
                                    }
                                    else row = row + "\"" + columns[x].name + "\"" + ":\"" + "" + "\"";
                                }
                                else
                                {
                                    if (Convert.IsDBNull(reader[x]) == false)
                                    {
                                        //row = row + "\"" + columns[x].name + "\"" + ":\"" + reader[x] + "\"";
                                        row = row + "\"" + columns[x].name + "\"" + ":\"" + Convert.ToString(reader[x]).Replace("\"", "\\\"") + "\"";
                                    }
                                    else
                                    {
                                        row = row + "\"" + columns[x].name + "\"" + ":\"" + (reader[x]) + "\"";

                                    }
                                }
                                if (x != reader.FieldCount - 1)

                                    row = row + ",";
                            }
                            row = row + "}";
                            result.Add(row);
                        }

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    dataout = "";
                    columnsout = "";
                    return "Trouble";
                }



                //output
                string resOut = "[";
                foreach (var row in result)
                    resOut = resOut + row + ",";
                resOut = resOut.Remove(resOut.Length - 1);
                resOut = resOut + "]";

                dataout = resOut;
                columnsout = JSON.ToJSON(columns);

                return "OK";
            }
        }
    }
}
