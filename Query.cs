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

                            StringBuilder row = new StringBuilder("{");
                            for (var x = 0; x < reader.FieldCount; x++)
                            {
                                if (columns[x].cell == "number")
                                {
                                    if (Convert.IsDBNull(reader[x]) == false)
                                    {
                                        row.Append("\"" + columns[x].name + "\"" + ":" + reader[x] + "");
                                    }
                                    else row.Append("\"" + columns[x].name + "\"" + ":" + "null" + "");
                                }
                                else if ((columns[x].cell == "date") || (columns[x].cell == "datetime"))
                                {
                                    if (Convert.IsDBNull(reader[x]) == false)
                                    {

                                        row.Append("\"" + columns[x].name + "\"" + ":\"" + ((DateTime)reader[x]).ToString("yyyy-MM-dd") + "\"");
                                    }
                                    else row.Append("\"" + columns[x].name + "\"" + ":\"" + "" + "\"");
                                }
                                else
                                {
                                    if (Convert.IsDBNull(reader[x]) == false)
                                    {
                                        //row = row + "\"" + columns[x].name + "\"" + ":\"" + reader[x] + "\"";
                                        row.Append("\"" + columns[x].name + "\"" + ":\"" + Convert.ToString(reader[x]).Replace("\"", "\\\"") + "\"");
                                    }
                                    else
                                    {
                                        row.Append("\"" + columns[x].name + "\"" + ":\"" + (reader[x]) + "\"");

                                    }
                                }
                                if (x != reader.FieldCount - 1)

                                    row.Append( ",");
                            }
                            row.Append("}");
                            result.Add(row.ToString());
                        }

                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    dataout = "";
                    columnsout = "";
                    return "Trouble";
                }



                //output
                StringBuilder resOut = new StringBuilder("[");
                for (int i = 0; i < result.Count; i++)
                {
                    if (i == result.Count - 1)
                    {
                        resOut.Append(result[i]);
                    }
                    else
                    resOut.Append(result[i] + ",");
                }
                
                resOut.Append("]");

                dataout = resOut.ToString();
                columnsout = JSON.ToJSON(columns);
                return "OK";
            }
        }
    }
}
