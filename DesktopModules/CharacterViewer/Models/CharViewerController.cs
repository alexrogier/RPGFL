using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;


namespace Christoc.Modules.ModuleCharacterViewer.Models
{
    public class CharViewController
    {
        //public void TESTCharPriority()
        //{
        //    DataTable priorityData = new DataTable();
        //    DataColumn col1 = new DataColumn();
        //    col1.DataType = System.Type.GetType("System.Int32");
        //    col1.ColumnName = "Character_PK";
        //    priorityData.Columns.Add(col1);
        //    DataColumn col2 = new DataColumn();
        //    col2.DataType = System.Type.GetType("System.Int32");
        //    col2.ColumnName = "User_FK";
        //    priorityData.Columns.Add(col2);

        //    for (var i = 0; i <= 10; i++)
        //    {
        //        DataRow newRow = priorityData.NewRow();
        //        newRow["Character_PK"] = i;
        //        newRow["User_FK"] = i;
        //        priorityData.Rows.Add(newRow);
        //    }

        //    using (var connection = new SqlConnection(DataProvider.Instance().ConnectionString))
        //    {
        //        using (var command = new SqlCommand("RPGFL_Test", connection))
        //        {
        //            //Setup Parameters
        //            command.CommandType = CommandType.StoredProcedure;
        //            var tableParam = new SqlParameter("@CharPriority", priorityData);
        //            tableParam.TypeName = "dbo.RPGFL_CharacterPriority";
        //            tableParam.SqlDbType = SqlDbType.Structured;
        //            command.Parameters.Add(tableParam);

        //            //Open connection and call
        //            connection.Open();
        //            command.ExecuteReader();
        //        }
        //    }

        //    //CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_Test", priorityData));
        //}

        public IList<Character> GetAllCharacters(int FILTER_guildfk, bool FILTER_allclasses, bool FILTER_healer, bool FILTER_assassin,
                                                    bool FILTER_hunter, bool FILTER_bruiser, bool FILTER_sorcerer, bool FILTER_enchanter,
                                                    bool FILTER_tank)
        {
            IList<Character> masterResults = CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_GetAllCharacters", FILTER_guildfk, FILTER_allclasses, FILTER_healer, FILTER_assassin,
                                                                                            FILTER_hunter, FILTER_bruiser, FILTER_sorcerer, FILTER_enchanter, FILTER_tank));

            return masterResults;
        }

        public IList<Skill> GetAllSkills(int Character_PK)
        {
            IList<Skill> masterResults = CBO.FillCollection<Skill>(DataProvider.Instance().ExecuteReader("RPGFL_GetAllSkills", Character_PK));

            return masterResults;
        }

        public IList<Character> GetUserDraftPriority(int FILTER_userfk)
        {
            IList<Character> masterResults = CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_GetUserDraftPriority", FILTER_userfk));

            return masterResults;
        }

        public void UpdateUserDraftPriority(HttpPostDraftData DraftPriorities)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();

            IList<PriorityData> newData = ser.Deserialize<IList<PriorityData>>(DraftPriorities.DraftPriorities);

            // logger
            //var sw = new System.IO.StreamWriter("C:\\Users\\arogier\\Desktop\\log.txt", true);
            //sw.WriteLine("CONTROLLER:");
            //sw.WriteLine(newData.ToString());
            //sw.WriteLine(DraftPriorities.ToString());
            //sw.Close();

            DataTable priorityData = new DataTable();
            DataColumn col1 = new DataColumn();
            col1.DataType = System.Type.GetType("System.Int32");
            col1.ColumnName = "Character_PK";
            priorityData.Columns.Add(col1);
            DataColumn col2 = new DataColumn();
            col2.DataType = System.Type.GetType("System.Int32");
            col2.ColumnName = "User_FK";
            priorityData.Columns.Add(col2);
            DataColumn col3 = new DataColumn();
            col3.DataType = System.Type.GetType("System.Int32");
            col3.ColumnName = "Priority";
            priorityData.Columns.Add(col3);

            foreach(var i in newData)
            {
                DataRow newRow = priorityData.NewRow();
                newRow["Character_PK"] = i.Character_PK;
                newRow["User_FK"] = DraftPriorities.UserFK;
                newRow["Priority"] = i.Priority;
                priorityData.Rows.Add(newRow);
            }

            using (var connection = new SqlConnection(DataProvider.Instance().ConnectionString))
            {
                using (var command = new SqlCommand("RPGFL_UpdateUserDraftPriority", connection))
                {
                    //Setup Parameters
                    command.CommandType = CommandType.StoredProcedure;
                    var tableParam = new SqlParameter("@CharPriority", priorityData);
                    tableParam.TypeName = "dbo.RPGFL_CharacterPriority";
                    tableParam.SqlDbType = SqlDbType.Structured;
                    command.Parameters.Add(tableParam);

                    //Open connection and call
                    connection.Open();
                    command.ExecuteReader();
                }
            } 
        }

        public IList<Guild> GetAllGuilds()
        {
            IList<Guild> masterResults = CBO.FillCollection<Guild>(DataProvider.Instance().ExecuteReader("RPGFL_GetAllGuilds"));

            return masterResults;
        }
    }
}