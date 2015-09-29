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
        public bool CreateCombatLogForSkirmish(IList<Combat_Log> combatLog)
                {
                    #region COLUMN DEFINITION
                    DataTable energyData = new DataTable();
                    DataColumn col1 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        ColumnName = "Skirmish_FK"
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
                        ColumnName = "Skill_FK"
                    };
                    energyData.Columns.Add(col4);
                    DataColumn col5 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        ColumnName = "Action_Order"
                    };
                    energyData.Columns.Add(col5);
                    DataColumn col6 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        ColumnName = "Attack_Final_Result"
                    };
                    energyData.Columns.Add(col6);
                    DataColumn col7 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.String"),
                        ColumnName = "Attack_Values"
                    };
                    energyData.Columns.Add(col7);
                    DataColumn col8 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        ColumnName = "Damage_Final_Result"
                    };
                    energyData.Columns.Add(col8);
                    DataColumn col9 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.String"),
                        ColumnName = "Damage_Values"
                    };
                    energyData.Columns.Add(col9);
                    DataColumn col10 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.String"),
                        ColumnName = "Damage_Types"
                    };
                    energyData.Columns.Add(col10);
                    DataColumn col11 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        ColumnName = "Conditions"
                    };
                    energyData.Columns.Add(col11);
                    DataColumn col12 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Boolean"),
                        ColumnName = "bAttackSuccessful"
                    };
                    energyData.Columns.Add(col12);
                    DataColumn col13 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Boolean"),
                        ColumnName = "bInterrupt"
                    };
                    energyData.Columns.Add(col13);
                    #endregion

                    foreach (var i in combatLog)
                    {
                        DataRow newRow = energyData.NewRow();
                        newRow["Skirmish_FK"] = i.Skirmish_FK;
                        newRow["Assailant_Character_FK"] = i.Assailant_Character_FK;
                        newRow["Target_Character_FK"] = i.Target_Character_FK;
                        newRow["Skill_FK"] = i.Skill_FK;
                        newRow["Action_Order"] = i.Action_Order;
                        newRow["Attack_Final_Result"] = i.Attack_Final_Result;
                        newRow["Attack_Values"] = i.Attack_Values;
                        newRow["Damage_Final_Result"] = i.Damage_Final_Result;
                        newRow["Damage_Values"] = i.Damage_Values;
                        newRow["Damage_Types"] = i.Damage_Types;
                        newRow["Conditions"] = i.Conditions;
                        newRow["bAttackSuccessful"] = i.bAttackSuccessful;
                        newRow["bInterrupt"] = i.bInterrupt;
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
        public bool CreateCharacterTrackLogForSkirmish(IList<Character_Track_Log> accoladeLog)
                {
                    #region COLUMN DEFINITION
                    DataTable accoladeData = new DataTable();
                    DataColumn col1 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        ColumnName = "Character_FK"
                    };
                    accoladeData.Columns.Add(col1);
                    DataColumn col2 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        ColumnName = "Damage_Dealt"
                    };
                    accoladeData.Columns.Add(col2);
                    DataColumn col3 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        ColumnName = "Damage_Taken"
                    };
                    accoladeData.Columns.Add(col3);
                    DataColumn col4 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        ColumnName = "Opponent_Knock_Outs"
                    };
                    accoladeData.Columns.Add(col4);
                    DataColumn col5 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        ColumnName = "Self_Knock_Outs"
                    };
                    accoladeData.Columns.Add(col5);
                    DataColumn col6 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.String"),
                        ColumnName = "Assist_Knock_Outs"
                    };
                    accoladeData.Columns.Add(col6);
                    DataColumn col7 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        ColumnName = "Attacks_Dodged"
                    };
                    accoladeData.Columns.Add(col7);
                    DataColumn col8 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.String"),
                        ColumnName = "Critical_Successes"
                    };
                    accoladeData.Columns.Add(col8);
                    DataColumn col9 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.String"),
                        ColumnName = "Critical_Fails"
                    };
                    accoladeData.Columns.Add(col9);
                    DataColumn col10 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        ColumnName = "Skirmishes_Participated"
                    };
                    accoladeData.Columns.Add(col10);
                    DataColumn col11 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Boolean"),
                        ColumnName = "Health_Regained"
                    };
                    accoladeData.Columns.Add(col11);
                    DataColumn col12 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Boolean"),
                        ColumnName = "Skirmishes_Survived"
                    };
                    accoladeData.Columns.Add(col12);
                    DataColumn col13 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Boolean"),
                        ColumnName = "Afflictions_Inflicted"
                    };
                    accoladeData.Columns.Add(col13);
                    DataColumn col14 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Boolean"),
                        ColumnName = "Initiative_Acted_First"
                    };
                    accoladeData.Columns.Add(col14);
                    DataColumn col15 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Boolean"),
                        ColumnName = "Guild_Win_Bonus"
                    };
                    accoladeData.Columns.Add(col15);
                    DataColumn col16 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Boolean"),
                        ColumnName = "Blessing_Bestow"
                    };
                    accoladeData.Columns.Add(col16);
                    DataColumn col17 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Boolean"),
                        ColumnName = "Blessing_Shield_Absorb"
                    };
                    accoladeData.Columns.Add(col17);
                    DataColumn col18 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Boolean"),
                        ColumnName = "Blessing_Bonus_Damage"
                    };
                    accoladeData.Columns.Add(col18);
                    DataColumn col19 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Boolean"),
                        ColumnName = "Blessing_StatBuff"
                    };
                    accoladeData.Columns.Add(col19);
                    DataColumn col20 = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Boolean"),
                        ColumnName = "Series_FK"
                    };
                    accoladeData.Columns.Add(col20);
                    #endregion

                    foreach (var i in accoladeLog)
                    {
                        DataRow newRow = accoladeData.NewRow();
                        newRow["Character_FK"] = i.Character_FK;
                        newRow["Damage_Dealt"] = i.Damage_Dealt;
                        newRow["Damage_Taken"] = i.Damage_Taken;
                        newRow["Opponent_Knock_Outs"] = i.Opponent_Knock_Outs;
                        newRow["Self_Knock_Outs"] = i.Self_Knock_Outs;
                        newRow["Assist_Knock_Outs"] = i.Assist_Knock_Outs;
                        newRow["Attacks_Dodged"] = i.Attacks_Dodged;
                        newRow["Critical_Successes"] = i.Critical_Successes;
                        newRow["Critical_Fails"] = i.Critical_Fails;
                        newRow["Skirmishes_Participated"] = i.Skirmishes_Participated;
                        newRow["Health_Regained"] = i.Health_Regained;
                        newRow["Skirmishes_Survived"] = i.Skirmishes_Participated;
                        newRow["Afflictions_Inflicted"] = i.Afflictions_Inflicted;
                        newRow["Initiative_Acted_First"] = i.Initiative_Acted_First;
                        newRow["Guild_Win_Bonus"] = i.Guild_Win_Bonus;
                        newRow["Blessing_Bestow"] = i.Blessing_Bestow;
                        newRow["Blessing_Shield_Absorb"] = i.Blessing_Shield_Absorb;
                        newRow["Blessing_Bonus_Damage"] = i.Blessing_Bonus_Damage;
                        newRow["Blessing_StatBuff"] = i.Blessing_Stat_Buff;
                        newRow["Series_FK"] = i.Series_FK;
                        accoladeData.Rows.Add(newRow);
                    }

                    using (var connection = new SqlConnection(DataProvider.Instance().ConnectionString))
                    {
                        using (var command = new SqlCommand("RPGFL_CreateCharacterTrackLogForSkirmish", connection))
                        {
                            //Setup Parameters
                            command.CommandType = CommandType.StoredProcedure;
                            var tableParam = new SqlParameter("@AccoladeLog", accoladeData);
                            tableParam.TypeName = "dbo.RPGFL_AccoladeLog";
                            tableParam.SqlDbType = SqlDbType.Structured;
                            command.Parameters.Add(tableParam);

                            //Open connection and call
                            connection.Open();
                            command.ExecuteReader();
                        }
                    }

                    return true;
                }
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
        public IList<Guild> GetAllGuilds()
        {
            return CBO.FillCollection<Guild>(DataProvider.Instance().ExecuteReader("RPGFL_GetAllGuilds")); 

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
        public bool UpdateSkirmish(int Skirmish_PK, int Guild1Points, int Guild2Points)
        {
            DataProvider.Instance().ExecuteReader("RPGFL_UpdateSkirmish", Skirmish_PK, Guild1Points, Guild2Points);
            return true;
        }
        public bool UpdateUserAccolades(int Skirmish_PK)
        {
            DataProvider.Instance().ExecuteReader("RPGFL_UpdateUserAccolades", Skirmish_PK);
            return true;
        }
        public bool UpdateUserSkirmishExperience(int Skirmish_PK)
        {
            DataProvider.Instance().ExecuteReader("RPGFL_UpdateUserSkirmishExperience", Skirmish_PK);
            return true;
        }
        public IList<Character> GetAllCharacterDataInSkirmish(int Skirmish_PK)
        {
            return CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_GetAllCharacterDataInSkirmish", Skirmish_PK));
        }
    }
}