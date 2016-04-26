using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;


namespace Family_Traces
{
    public class DBAccessStatic
    {
        public static string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FamilyTraces.accdb";

        public static int UpdateTable(string tableName, string fieldName, string fieldValue, int id)
        {
            string sql = "UPDATE [" + tableName + "] SET [" + fieldName + "] = '" + fieldValue + "' WHERE ID = " + id;

            OleDbConnection dbConn = new OleDbConnection(connString);
            dbConn.Open();
            OleDbCommand dbCommand = new OleDbCommand(sql, dbConn);
            int retVal = dbCommand.ExecuteNonQuery();
            dbConn.Close();

            return retVal;
        }

      
        //----------------------------------------------------------------------------------
        // Individuals
        //----------------------------------------------------------------------------------
        public static void DeleteIndividual(int individualId)
        {

            OleDbConnection dbConn = new OleDbConnection(connString);
            dbConn.Open();
            string sql = "UPDATE [Family] SET [HusbandId] = -1 WHERE [HusbandId] = " + individualId.ToString();
            OleDbCommand dbCommand = new OleDbCommand(sql, dbConn);
            dbCommand.ExecuteNonQuery();

            dbCommand.CommandText = "DELETE FROM [FamilyChildren] WHERE [ChildId] = " + individualId.ToString();
            dbCommand.ExecuteNonQuery();

            dbCommand.CommandText = "DELETE FROM [Individual] WHERE [ID] = " + individualId.ToString();
            dbCommand.ExecuteNonQuery();
            dbConn.Close();
        }

        public static DataSet GetAllIndividuals()
        {
            string sql = "SELECT [ID], [Surname], [Firstname], [BornDate], [BornPlace], [DiedDate], [DiedPlace], [ParentFamilyId], [Gender] FROM [Individual] ORDER BY [Surname], [Firstname]";

            OleDbConnection dbConn = new OleDbConnection(connString);
            dbConn.Open();
            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);
            dbConn.Close();

            return ds;
        }

        public static DataSet GetIndividual(int individualId)
        {
            string sql = "SELECT [ID], [Surname], [Firstname], [BornDate], [BornPlace], [DiedDate], [DiedPlace], [ParentFamilyId], [Gender] FROM [Individual] WHERE [ID] = " + individualId.ToString();

            OleDbConnection dbConn = new OleDbConnection(connString);
            dbConn.Open();
            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);
            dbConn.Close();

            return ds;
        }
        
        public static int InsertIndividual(string surname, string firstname, string bornDate, string bornPlace, string diedDate, string diedPlace, int parentFamilyId, string gender)
        {
            string sql = "INSERT INTO [Individual] ([Surname], [Firstname], [BornDate], [BornPlace], [DiedDate], [DiedPlace], [ParentFamilyId], [Gender]) VALUES ('" + surname.Trim() + "', '" + firstname.Trim() + "', '" + bornDate.Trim() + "', '" + bornPlace.Trim() + "', '" + diedDate.Trim() + "', '" + diedPlace.Trim() + "', " + parentFamilyId.ToString() + ", '" + gender.Trim() + "')";

            OleDbConnection dbConn = new OleDbConnection(connString);
            dbConn.Open();
            OleDbCommand dbCommand = new OleDbCommand(sql, dbConn);
            dbCommand.ExecuteNonQuery();

            dbCommand.CommandText = "SELECT MAX(ID) FROM [Individual]";
            int individualId = (int)dbCommand.ExecuteScalar();
            dbConn.Close();

            return individualId;
        }

        public static int UpdateIndividualSurname(int individualId, string surname)
        {
            return DBAccessStatic.UpdateTable("Individual", "Surname", surname, individualId);
        }

        public static int UpdateIndividualFirstname(int individualId, string firstname)
        {
            return DBAccessStatic.UpdateTable("Individual", "Firstname", firstname, individualId);
        }

        public static int UpdateIndividualBornDate(int individualId, string bornDate)
        {
            return DBAccessStatic.UpdateTable("Individual", "BornDate", bornDate, individualId);
        }

        public static int UpdateIndividualBornPlace(int individualId, string bornPlace)
        {
            return DBAccessStatic.UpdateTable("Individual", "BornPlace", bornPlace, individualId);
        }

        public static int UpdateIndividualDiedDate(int individualId, string diedDate)
        {
            return DBAccessStatic.UpdateTable("Individual", "DiedDate", diedDate, individualId);
        }

        public static int UpdateIndividualDiedPlace(int individualId, string diedPlace)
        {
            return DBAccessStatic.UpdateTable("Individual", "DiedPlace", diedPlace, individualId);
        }

        public static int UpdateIndividualPArentFamilyId(int individualId, int parentFamilyId)
        {
            return DBAccessStatic.UpdateTable("Individual", "ParentFamilyId", parentFamilyId.ToString(), individualId);
        }

        public static int UpdateIndividualGender(int individualId, string gender)
        {
            return DBAccessStatic.UpdateTable("Individual", "Gender", gender, individualId);
        }


        //----------------------------------------------------------------------------------
        // Families
        //----------------------------------------------------------------------------------
        public static DataSet GetFamily(int familyId)
        {
            string sql = "SELECT [ID], [HusbandId], [WifeId], [MarriageDate], [MarriagePlace] FROM [Family] WHERE [ID] = " + familyId.ToString();

            OleDbConnection dbConn = new OleDbConnection(connString);
            dbConn.Open();
            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);
            dbConn.Close();

            return ds;
        }

        public static DataSet GetFamilyForHusband(int husbandId)
        {
            string sql = "SELECT [ID], [HusbandId], [WifeId], [MarriageDate], [MarriagePlace] FROM [Family] WHERE [HusbandID] = " + husbandId.ToString();

            OleDbConnection dbConn = new OleDbConnection(connString);
            dbConn.Open();
            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);
            dbConn.Close();

            return ds;
        }

        public static DataSet GetFamilyForWife(int wifeId)
        {
            string sql = "SELECT [ID], [HusbandId], [WifeId], [MarriageDate], [MarriagePlace] FROM [Family] WHERE [WifeID] = " + wifeId.ToString();

            OleDbConnection dbConn = new OleDbConnection(connString);
            dbConn.Open();
            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);
            dbConn.Close();

            return ds;
        }

        
        public static int InsertFamily(int husbandId, int wifeId, string marriageDate, string marriagePlace)
        {
            string sql = "INSERT INTO [Family] ([HusbandId], [WifeId], [MarriageDate], [MarriagePlace]) VALUES (" + husbandId.ToString() + ", " + wifeId.ToString() + ", '" + marriageDate.Trim() + "', '" + marriagePlace.Trim() + "')";

            OleDbConnection dbConn = new OleDbConnection(connString);
            dbConn.Open();
            OleDbCommand dbCommand = new OleDbCommand(sql, dbConn);
            dbCommand.ExecuteNonQuery();

            dbCommand.CommandText = "SELECT MAX(ID) FROM [Family]";
            int familyId = (int)dbCommand.ExecuteScalar();
            dbConn.Close();

            return familyId;
        }

        public static int UpdateFamilyHusbandId(int familyId, int husbandId)
        {
            return DBAccessStatic.UpdateTable("Family", "HusbandId", husbandId.ToString(), familyId);
        }

        public static int UpdateFamilyWifeId(int familyId, int wifeId)
        {
            return DBAccessStatic.UpdateTable("Family", "WifeId", wifeId.ToString(), familyId);
        }

        public static int UpdateFamilyMarriageDate(int familyId, string marriageDate)
        {
            return DBAccessStatic.UpdateTable("Family", "MarriageDate", marriageDate, familyId);
        }

        public static int UpdateFamilyMarriagePlace(int familyId, string marriagePlace)
        {
            return DBAccessStatic.UpdateTable("Family", "MarriagePlace", marriagePlace, familyId);
        }

        //----------------------------------------------------------------------------------
        // Children
        //----------------------------------------------------------------------------------
        public static DataSet DeleteFamilyChild(int childId)
        {
            string sql = "DELETE FROM [FamilyChildren] WHERE [ChildId] = " + childId.ToString();

            OleDbConnection dbConn = new OleDbConnection(connString);
            dbConn.Open();
            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);
            dbConn.Close();

            return ds;
        }

        public static DataSet GetFamilyChildren(int familyId)
        {
            string sql = "SELECT [ChildId], [Surname], [Firstname], [BornDate], [BornPlace], [DiedDate], [DiedPlace], [Gender] FROM [Individual] INNER JOIN [FamilyChildren] ON [Individual].[ID] = [FamilyChildren].[ChildId] WHERE [FamilyChildren].[FamilyId] = " + familyId.ToString();

            OleDbConnection dbConn = new OleDbConnection(connString);
            dbConn.Open();
            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);
            dbConn.Close();

            return ds;
        }

        public static int InsertFamilyChild(int familyId, int childId)
        {
            string sql = "INSERT INTO [FamilyChildren] ([FamilyId], [ChildId]) VALUES (" + familyId.ToString() + ", " + childId.ToString() + ")";

            OleDbConnection dbConn = new OleDbConnection(connString);
            dbConn.Open();
            OleDbCommand dbCommand = new OleDbCommand(sql, dbConn);
            dbCommand.ExecuteNonQuery();

            dbCommand.CommandText = "SELECT MAX(ID) FROM [FamilyChildren]";
            int individualId = (int)dbCommand.ExecuteScalar();
            dbConn.Close();

            return individualId;
        }


    }
}
