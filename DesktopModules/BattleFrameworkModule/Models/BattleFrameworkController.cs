using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.BattleFrameworkModule.Models
{
    public class BattleFrameworkController
    {
        public IList<Accolades> GetAccolades()
        {
            return CBO.FillCollection<Accolades>(DataProvider.Instance().ExecuteReader("RPGFL_GetAccolades")); 
        }
        public IList<Character> GetSkirmishCharacters(int Skirmish_PK)
        {
            return CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_GetSkirmishCharacters", Skirmish_PK)); 
        }
        public IList<Skirmish> GetCurrentSkirmishes()
        {
            return CBO.FillCollection<Skirmish>(DataProvider.Instance().ExecuteReader("RPGFL_GetCurrentSkirmishes")); 
        }
        public IList<Initiative_Track> GetInitiativeTrackFromSkirmish(int Skirmish_PK)
        {
            return CBO.FillCollection<Initiative_Track>(DataProvider.Instance().ExecuteReader("RPGFL_GetInitiativeTrackFromSkirmish", Skirmish_PK));

        }
        public IList<Skirmish> GetSkirmishData(int Skirmish_PK)
        {
            return CBO.FillCollection<Skirmish>(DataProvider.Instance().ExecuteReader("RPGFL_GetSkirmishData", Skirmish_PK));
        }
        public IList<Skill> GetSkillDataFromSkirmishCharacters(int Skirmish_PK)
        {
            return CBO.FillCollection<Skill>(DataProvider.Instance().ExecuteReader("RPGFL_GetSkillDataFromSkirmishCharacters", Skirmish_PK));
        }
        public IList<Combat_Log> GetCombatLogData(int Skirmish_PK)
        {
            return CBO.FillCollection<Combat_Log>(DataProvider.Instance().ExecuteReader("RPGFL_GetCombatLogData", Skirmish_PK));
        }
        public IList<Votes> GetVoteDataFromSkirmish(int Skirmish_PK)
        {
            return CBO.FillCollection<Votes>(DataProvider.Instance().ExecuteReader("RPGFL_GetVoteDataFromSkirmish", Skirmish_PK));
        }
        public bool CreateSkirmishCharacterDraft(int Skirmish_PK)
        {
            DataProvider.Instance().ExecuteReader("RPGFL_CreateSkirmishCharacterDraft", Skirmish_PK);
            return true;
        }
        public bool UpdateCharacterEnergy(List<Energy_Consumption> EnergyValues)
        {
            DataTable energyData = new DataTable();
            DataColumn col1 = new DataColumn();
            col1.DataType = System.Type.GetType("System.Int32");
            col1.ColumnName = "Campaign_FK";
            energyData.Columns.Add(col1);
            DataColumn col2 = new DataColumn();
            col2.DataType = System.Type.GetType("System.Int32");
            col2.ColumnName = "Character_FK";
            energyData.Columns.Add(col2);
            DataColumn col3 = new DataColumn();
            col3.DataType = System.Type.GetType("System.Int32");
            col3.ColumnName = "Consume_Energy";
            energyData.Columns.Add(col3);

            foreach (var i in EnergyValues)
            {
                DataRow newRow = energyData.NewRow();
                newRow["Campaign_FK"] = i.Campaign_FK;
                newRow["Character_FK"] = i.Character_FK;
                newRow["Consume_Energy"] = i.Consume_Energy;
                energyData.Rows.Add(newRow);
            }

            using (var connection = new SqlConnection(DataProvider.Instance().ConnectionString))
            {
                using (var command = new SqlCommand("RPGFL_UpdateCharacterEnergy", connection))
                {
                    //Setup Parameters
                    command.CommandType = CommandType.StoredProcedure;
                    var tableParam = new SqlParameter("@NewEnergy", energyData);
                    tableParam.TypeName = "dbo.RPGFL_EnergyConsumption";
                    tableParam.SqlDbType = SqlDbType.Structured;
                    command.Parameters.Add(tableParam);

                    //Open connection and call
                    connection.Open();
                    command.ExecuteReader();
                }
            }
            return true;
        }
        public bool CreateCombatLogForSkirmish(List<Combat_Log> combatLog)
        {
            #region COLUMN DEFINITION
            DataTable energyData = new DataTable();
            DataColumn col1 = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "Skirmish_PK"
            };
            energyData.Columns.Add(col1);
            DataColumn col2 = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "Assailant_Character_FK"
            };
            energyData.Columns.Add(col2);
            DataColumn col3 = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "Target_Character_FK"
            };
            energyData.Columns.Add(col3);
            DataColumn col4 = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "Action_Order"
            };
            energyData.Columns.Add(col4);
            DataColumn col5 = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "Attack_Final_Result"
            };
            energyData.Columns.Add(col5);
            DataColumn col6 = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "Attack_Values"
            };
            energyData.Columns.Add(col6);
            DataColumn col7 = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "Damage_Final_Result"
            };
            energyData.Columns.Add(col7);
            DataColumn col8 = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "Damage_Values"
            };
            energyData.Columns.Add(col8);
            DataColumn col9 = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "Conditions"
            };
            energyData.Columns.Add(col9);
            DataColumn col10 = new DataColumn
            {
                DataType = System.Type.GetType("System.Boolean"),
                ColumnName = "bAttackSuccessful"
            };
            energyData.Columns.Add(col10);
            #endregion

            foreach (var i in combatLog)
            {
                DataRow newRow = energyData.NewRow();
                newRow["Skirmish_PK"] = i.Skirmish_FK;
                newRow["Assailant_Character_FK"] = i.Assasilant_Character_FK;
                newRow["Target_Character_FK"] = i.Target_Character_FK;
                newRow["Skill_FK"] = i.Skill_FK;
                newRow["Action_Order"] = i.Action_Order;
                newRow["Attack_Final_Result"] = i.Attack_Final_Result;
                newRow["Attack_Values"] = i.Attack_Values;
                newRow["Damage_Final_Result"] = i.Damage_Final_Result;
                newRow["Damage_Values"] = i.Damage_Values;
                newRow["Conditions"] = i.Conditions;
                newRow["bAttackSuccessful"] = i.bAttackSuccessful;
                energyData.Rows.Add(newRow);
            }

            using (var connection = new SqlConnection(DataProvider.Instance().ConnectionString))
            {
                using (var command = new SqlCommand("RPGFL_CreateCombatLogForSkirmish", connection))
                {
                    //Setup Parameters
                    command.CommandType = CommandType.StoredProcedure;
                    var tableParam = new SqlParameter("@CombatLog", energyData);
                    tableParam.TypeName = "dbo.RPGFL_CombatLog";
                    tableParam.SqlDbType = SqlDbType.Structured;
                    command.Parameters.Add(tableParam);

                    //Open connection and call
                    connection.Open();
                    command.ExecuteReader();
                }
            }

            return true;
        }
    }
}