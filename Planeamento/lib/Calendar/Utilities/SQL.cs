using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    internal class SQL
    {
        SqlConnection connection { get; set; }

        public SQL()
        {
            connection = new SqlConnection("Server=xxx;Database=xxx;User Id=xxx;Password=xxx;");
        }

        private void Open()
        {
            connection.Open();
        }

        private void Close()
        {
            connection.Close();
        }

        public List<TimeBlock> GetCalendarByHatchTrue()
        {
            // Query SQL que você deseja executar
            string query = @"SELECT [Id], [Text], [Year], [Day], [Hatch], [Clickable], [IsVisible], [IdMonth], [Color], [Description]
                         FROM [dbo].[Calendar] WHERE [Hatch] = 1";
            List<TimeBlock> timeBlocks = new List<TimeBlock>();
            Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Executar o comando e obter os dados usando um SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Verificar se existem linhas retornadas
                    if (reader.HasRows)
                    {
                        // Iterar sobre os resultados e exibir cada registro
                        while (reader.Read())
                        {
                            // Ler os dados de cada coluna, por exemplo:
                            int id = reader.GetInt32(0);
                            string text = reader.GetString(1);
                            int year = reader.GetInt32(2);
                            int day = reader.GetInt32(3);
                            bool hatch = reader.GetBoolean(4);
                            bool clickable = reader.GetBoolean(5);
                            bool isVisible = reader.GetBoolean(6);
                            int idMonth = reader.GetInt32(7);
                            string color = reader.GetString(8);
                            string description = reader.GetString(9);

                            // Exibir os dados (ou faça o que precisar com eles)
                            timeBlocks.Add(new TimeBlock(id, text, new DateTime(year, idMonth, day), description, hatch));
                        }
                    }
                }
            }
            Close();
            return timeBlocks;
        }
        public void GetRowsByChargesNotebookId(CalendarChart calendarChart)
        {
            Open();
            using (SqlCommand command = new SqlCommand(
                "SELECT [Month].Id, [Month].Text,Calendar.Id AS CalendarId,Calendar.Description, Calendar.Text AS CalendarText, " +
                "Calendar.Year, Calendar.Day , Calendar.Color, Calendar.Hatch " +
                "FROM [Month] " +
                "LEFT JOIN [Calendar] ON [Calendar].IdMonth = [Month].Id " +
                $"WHERE [Calendar].Year = {calendarChart.Id} " +
                "Order by Calendar.IdMonth,Calendar.Day ASC ;", connection))
            {
                //command.Parameters.AddWithValue("@IdChargesNotebook", calendarChart.Id);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int rowMonth = int.Parse(reader["Id"].ToString());
                    string rowName = reader["Text"].ToString();
                    string colorValue = reader["Color"]?.ToString();
                    int r = 255;
                    int g = 255;
                    int b = 0;

                    if (colorValue != null && colorValue != "")
                    {
                        string[] spltiColor = colorValue.Split(',');

                        r = int.Parse(spltiColor[0]);
                        g = int.Parse(spltiColor[1]);
                        b = int.Parse(spltiColor[2]);
                    }
                    if (reader["CalendarId"].ToString() != "")
                    {
                        int idCalendar = Convert.ToInt32(reader["CalendarId"].ToString());
                        string timeBlockText = reader["CalendarText"].ToString();
                        string description = "";
                        if (reader["Description"].ToString() != null) { description = reader["Description"].ToString(); }
                        int year = int.Parse(reader["Year"].ToString());
                        int day = int.Parse(reader["Day"].ToString());
                        bool hatch = bool.Parse(reader["Hatch"].ToString());

                        calendarChart.AddRow(calendarChart, rowMonth, rowName, idCalendar, timeBlockText, description, year, day, r, g, b, hatch);
                    }
                    else
                    {
                        calendarChart.AddRow(calendarChart, rowMonth, rowName);
                    }

                }
            }
            Close();

        }

        public bool UpdateTimeBlock(int id, string text, string description, DateTime date, bool hatch, bool clickable, bool isVisible, string color)
        {
            Open();

            string query = @"UPDATE [dbo].[Calendar]
                         SET [Text] = @Text,
                             [Year] = @Year,
                             [Day] = @Day,
                             [Hatch] = @Hatch,
                             [Clickable] = @Clickable,
                             [IsVisible] = @IsVisible,
                             [IdMonth] = @IdMonth,
                             [Color] = @Color,
                             [Description] = @Description
                         WHERE [Id] = @Id";

                // Cria o comando SQL
                SqlCommand cmd = new SqlCommand(query, connection);

                // Adiciona os parâmetros para evitar injeção de SQL
                cmd.Parameters.Add("@Text", SqlDbType.VarChar, 10).Value = text;
                cmd.Parameters.Add("@Year", SqlDbType.Int).Value = date.Year;
                cmd.Parameters.Add("@Day", SqlDbType.Int).Value = date.Day;
                cmd.Parameters.Add("@Hatch", SqlDbType.Bit).Value = hatch;
                cmd.Parameters.Add("@Clickable", SqlDbType.Bit).Value = clickable;
                cmd.Parameters.Add("@IsVisible", SqlDbType.Bit).Value = isVisible;
                cmd.Parameters.Add("@IdMonth", SqlDbType.Int).Value = date.Month;
                cmd.Parameters.Add("@Color", SqlDbType.VarChar, 50).Value = color;
                cmd.Parameters.Add("@Description", SqlDbType.Text).Value = description;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id; // Supondo que o Id é o critério de busca

                int rowsAffected = cmd.ExecuteNonQuery();
            
            Close();

            return rowsAffected > 0;

        }

        public void InsertBuildNewCalendarByYear(int year)
        {

            Open();

                // Preparando o comando de inserção
                string insertQuery = @"
                INSERT INTO [Gant].[dbo].[Calendar] 
                ([Text], [Year], [Day], [Hatch], [Clickable], [IsVisible], [IdMonth], [Color], [Description])
                VALUES 
                (@Text, @Year, @Day, @Hatch, @Clickable, @IsVisible, @IdMonth, @Color, @Description)";

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                // Adicionando parâmetros
                command.Parameters.Add(new SqlParameter("@Text", ""));
                command.Parameters.Add(new SqlParameter("@Year", year));
                command.Parameters.Add(new SqlParameter("@Hatch", false)); // valor NULL
                command.Parameters.Add(new SqlParameter("@Clickable", 1));
                command.Parameters.Add(new SqlParameter("@IsVisible", 1));
                command.Parameters.Add(new SqlParameter("@Color", "255,255,255"));

                for (int month = 1; month <= 12; month++)
                {
                    command.Parameters.Add(new SqlParameter("@IdMonth", month));
                    // Loop para inserir os 31 dias de Janeiro
                    for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                    {
                        command.Parameters.Add(new SqlParameter("@Day", day));
                        command.Parameters.Add(new SqlParameter("@Description", $""));

                        // Executando a inserção
                        command.ExecuteNonQuery();

                        // Remove os parâmetros específicos do loop para a próxima iteração
                        command.Parameters.RemoveAt("@Day");
                        command.Parameters.RemoveAt("@Description");
                    }
                    command.Parameters.RemoveAt("@IdMonth");
                }
            }

            Close();
        }


        public List<int> GetYear()
        {
            string query = "SELECT [Year] FROM Calendar GROUP BY [Year] ORDER BY [Year] ASC";

            List<int> years = new List<int>();
           
            Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int year = reader.GetInt32(0);
                        years.Add(year);
                    }
                }
            }
            Close();

            return years;

        }

            
    }
}
