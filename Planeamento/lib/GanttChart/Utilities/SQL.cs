using GanttChart;
using Planeamento.lib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GanttChart
{
    public class SQL
    {

        SqlConnection connection {  get; set; }

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

        public List<ChargesNotebook> GetChargesNotebook()
        {
            List<ChargesNotebook> listChargesNotebook = new List<ChargesNotebook>();
            Open();
            using (SqlCommand command = new SqlCommand("SELECT Id,Name FROM ChargesNotebook", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChargesNotebook chargesNotebook = new ChargesNotebook();
                    chargesNotebook.id = int.Parse(reader["Id"].ToString());
                    chargesNotebook.Name = reader["Name"].ToString();
                    listChargesNotebook.Add(chargesNotebook);
                }
            }
            Close();
            return listChargesNotebook;

        }

        public void GetRowsByChargesNotebookId(Chart chart)
        {
            Open();
            using (SqlCommand command = new SqlCommand(
                "SELECT [ROW].Id, [ROW].Text, [ROW].IdChargesNotebook,TimeBlock.Id AS TimeBlockId,TimeBlock.Description, TimeBlock.Text AS TimeBlockText, " +
                "TimeBlock.StartTime, TimeBlock.EndTime , TimeBlock.Color " +
                "FROM [Row] " +
                "LEFT JOIN [TimeBlock] ON [TimeBlock].IdRow = [Row].Id " +
                "WHERE [ROW].IsVisible = 1 AND [ROW].IdChargesNotebook = @IdChargesNotebook", connection))
            {
                command.Parameters.AddWithValue("@IdChargesNotebook", chart.Id);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int rowId = int.Parse(reader["Id"].ToString());
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
                    if (reader["TimeBlockId"].ToString() != "")
                    {
                        int idTimeBlock = Convert.ToInt32(reader["TimeBlockId"].ToString());
                        string timeBlockText = reader["TimeBlockText"].ToString();
                        string description = "";
                        if (reader["Description"].ToString() != null) { description = reader["Description"].ToString(); } 
                        string startDateString = reader["StartTime"].ToString();
                        string endDateString = reader["EndTime"].ToString();
                        DateTime startTime = DateTime.Parse("01/01/0001 00:00:00");
                        DateTime endTime = DateTime.Parse("01/01/0001 00:00:00");

                        if (startDateString != null && endDateString != "") { startTime = DateTime.Parse(reader["StartTime"].ToString()); }
                        if (endDateString != null && endDateString != "") { endTime = DateTime.Parse(reader["EndTime"].ToString()); }

                        chart.AddRow(chart, rowId, rowName, idTimeBlock, timeBlockText, description, startTime, endTime, r, g, b);
                    }
                    else
                    {
                        chart.AddRow(chart, rowId, rowName);
                        
                    }

                }
            }
            Close();

        }

        public bool InsertRow(bool IsVisible,string Text,int IdChargesNotebook)
        {
            Open();
            string query = "INSERT INTO [Gant].[dbo].[Row] ([IsVisible], [Text], [IdChargesNotebook]) VALUES (@IsVisible, @Text, @IdChargesNotebook)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IsVisible", IsVisible);
                    cmd.Parameters.AddWithValue("@Text", Text);
                    cmd.Parameters.AddWithValue("@IdChargesNotebook", IdChargesNotebook);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Close();
                        return true;
                    }
                    else
                    {
                        Close();
                        return false;
                    }
                }
            
        }

        public bool UpdateRow(bool IsVisible, string Text, int IdChargesNotebook, int RowId,string description)
        {
            Open();
            string query = $"UPDATE [Gant].[dbo].[Row] SET [IsVisible] = @IsVisible, [Text] = @Text, [IdChargesNotebook] = @IdChargesNotebook , [Description] = @Description WHERE [Id] = {RowId}";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@IsVisible", IsVisible);
                cmd.Parameters.AddWithValue("@Text", Text);
                cmd.Parameters.AddWithValue("@IdChargesNotebook", IdChargesNotebook);
                cmd.Parameters.AddWithValue("@Description", description);

                int rowsAffected = cmd.ExecuteNonQuery();

                Close();
                return rowsAffected > 0;
            }
        }

        public int InsertTimeBlock(string text , string description, DateTime startTime, DateTime endTime,bool hatch, bool clickable, bool isVisible, int idRow, string color)
        {
            Open();

            string query = @"
            INSERT INTO [Gant].[dbo].[TimeBlock] 
            ([Text],[Description], [StartTime], [EndTime], [Hatch], [Clickable], [IsVisible], [IdRow], [Color]) 
            VALUES (@Text,@Description, @StartTime, @EndTime, @Hatch, @Clickable, @IsVisible, @IdRow, @Color);
            SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                // Adiciona parâmetros ao comando
                cmd.Parameters.AddWithValue("@Text", text);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@StartTime", startTime);
                cmd.Parameters.AddWithValue("@EndTime", endTime);
                cmd.Parameters.AddWithValue("@Hatch", hatch);
                cmd.Parameters.AddWithValue("@Clickable", clickable);
                cmd.Parameters.AddWithValue("@IsVisible", isVisible);
                cmd.Parameters.AddWithValue("@IdRow", idRow);
                cmd.Parameters.AddWithValue("@Color", color);

                // Executa o comando de inserção e recupera o ID gerado
                object result = cmd.ExecuteScalar(); // ExecuteScalar retorna a primeira coluna da primeira linha

                Close();

                // Verifica se o resultado não é nulo e retorna o ID como int
                if (result != null)
                {
                    return Convert.ToInt32(result); // Retorna o ID gerado
                }
                else
                {
                    throw new Exception("Erro ao inserir o TimeBlock e recuperar o ID.");
                }
            }

        }

        public bool UpdateTimeBlock(int id, string text, string description, DateTime startTime, DateTime endTime, bool hatch, bool clickable, bool isVisible, int idRow, string color)
        {
            Open();

            string query = @"UPDATE [Gant].[dbo].[TimeBlock]
                            SET [Text] = @Text,
                                [Description] = @Description,
                                [StartTime] = @StartTime,
                                [EndTime] = @EndTime,
                                [Hatch] = @Hatch,
                                [Clickable] = @Clickable,
                                [IsVisible] = @IsVisible,
                                [IdRow] = @IdRow,
                                [Color] = @Color
                            WHERE [Id] = @Id";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Text", text);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@StartTime", startTime);
                cmd.Parameters.AddWithValue("@EndTime", endTime);
                cmd.Parameters.AddWithValue("@Hatch", hatch);
                cmd.Parameters.AddWithValue("@Clickable", clickable);
                cmd.Parameters.AddWithValue("@IsVisible", isVisible);
                cmd.Parameters.AddWithValue("@IdRow", idRow);
                cmd.Parameters.AddWithValue("@Color", color);

                int rowsAffected = cmd.ExecuteNonQuery();

                Close();
                return rowsAffected > 0;
            }
        }

        public bool DeleteTimeBlock(int id)
        {
            Open();
            string deleteQuery = $"DELETE FROM TimeBlock WHERE ID = {id};";
            SqlCommand command = new SqlCommand(deleteQuery, connection);
            try
            {
                command.ExecuteNonQuery();
                Close();
                return true;
            }
            catch
            {
                Close();
                return false;
            }
        }

    }
}
