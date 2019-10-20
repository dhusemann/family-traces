using System;
using System.Data;
using System.Data.OleDb;

namespace Family_Traces
{
    public class DBAccess : IDisposable
    {
        public static string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FamilyTraces.accdb";

        private OleDbCommand dbCommand;
        private OleDbConnection dbConn;

        public void Open()
        {
            dbConn = new OleDbConnection(DBAccess.connString);
            dbConn.Open();
        }

        public void Close()
        {
            dbConn.Close();
        }

        public int UpdateTable(string tableName, string fieldName, string fieldValue, int id)
        {
            string sql = "UPDATE [" + tableName + "] SET [" + fieldName + "] = '" + fieldValue + "' WHERE ID = " + id;

            OleDbCommand dbCommand = new OleDbCommand(sql, dbConn);
            int retVal = dbCommand.ExecuteNonQuery();

            return retVal;
        }


        //----------------------------------------------------------------------------------
        // Individuals
        //----------------------------------------------------------------------------------
        public DataSet GetAllIndividuals()
        {
            string sql = "SELECT [ID], [Surname], [Firstname], [BornDate], [BornPlace], [DiedDate], [DiedPlace], [ParentFamilyId], [Gender] FROM [Individual]";

            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);

            return ds;
        }

        public DataSet GetIndividual(int individualId)
        {
            string sql = "SELECT [ID], [Surname], [Firstname], [BornDate], [BornPlace], [DiedDate], [DiedPlace], [ParentFamilyId], [Gender] FROM [Individual] WHERE [ID] = " + individualId.ToString();

            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);

            return ds;
        }

        public int InsertIndividual(string surname, string firstname, string bornDate, string bornPlace, string diedDate, string diedPlace, int parentFamilyId, string gender)
        {
            string sql = "INSERT INTO [Individual] ([Surname], [Firstname], [BornDate], [BornPlace], [DiedDate], [DiedPlace], [ParentFamilyId], [Gender]) VALUES ('" + surname.Trim() + "', '" + firstname.Trim() + "', '" + bornDate.Trim() + "', '" + bornPlace.Trim() + "', '" + diedDate.Trim() + "', '" + diedPlace.Trim() + "', " + parentFamilyId.ToString() + ", '" + gender.Trim() + "')";

            dbCommand = new OleDbCommand(sql, dbConn);
            dbCommand.ExecuteNonQuery();

            dbCommand.CommandText = "SELECT MAX(ID) FROM [Individual]";
            int individualId = (int)dbCommand.ExecuteScalar();

            return individualId;
        }

        public int UpdateIndividualSurname(int individualId, string surname)
        {
            return UpdateTable("Individual", "Surname", surname, individualId);
        }

        public int UpdateIndividualFirstname(int individualId, string firstname)
        {
            return UpdateTable("Individual", "Firstname", firstname, individualId);
        }

        public int UpdateIndividualBornDate(int individualId, string bornDate)
        {
            return UpdateTable("Individual", "BornDate", bornDate, individualId);
        }

        public int UpdateIndividualBornPlace(int individualId, string bornPlace)
        {
            return UpdateTable("Individual", "BornPlace", bornPlace, individualId);
        }

        public int UpdateIndividualDiedDate(int individualId, string diedDate)
        {
            return UpdateTable("Individual", "DiedDate", diedDate, individualId);
        }

        public int UpdateIndividualDiedPlace(int individualId, string diedPlace)
        {
            return UpdateTable("Individual", "DiedPlace", diedPlace, individualId);
        }

        public int UpdateIndividualPArentFamilyId(int individualId, int parentFamilyId)
        {
            return UpdateTable("Individual", "ParentFamilyId", parentFamilyId.ToString(), individualId);
        }

        public int UpdateIndividualGender(int individualId, string gender)
        {
            return UpdateTable("Individual", "Gender", gender, individualId);
        }


        //----------------------------------------------------------------------------------
        // Families
        //----------------------------------------------------------------------------------
        public DataSet GetAllFamilies()
        {
            string sql = "SELECT [ID], [HusbandId], [WifeId], [MarriageDate], [MarriagePlace] FROM [Family]";

            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);

            return ds;
        }

        public DataSet GetFamily(int familyId)
        {
            string sql = "SELECT [ID], [HusbandId], [WifeId], [MarriageDate], [MarriagePlace] FROM [Family] WHERE [ID] = " + familyId.ToString();

            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);

            return ds;
        }

        public DataSet GetFamilyByPerson(int individualId)
        {
            string sql = "SELECT [ID], [HusbandId], [WifeId], [MarriageDate], [MarriagePlace] FROM [Family] WHERE [HusbandID] = " + individualId.ToString() + " OR [WifeID] = " + individualId.ToString();

            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);

            return ds;
        }


        public DataSet GetFamilyForHusband(int husbandId)
        {
            string sql = "SELECT [ID], [HusbandId], [WifeId], [MarriageDate], [MarriagePlace] FROM [Family] WHERE [HusbandID] = " + husbandId.ToString();

            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);

            return ds;
        }

        public DataSet GetFamilyForWife(int wifeId)
        {
            string sql = "SELECT [ID], [HusbandId], [WifeId], [MarriageDate], [MarriagePlace] FROM [Family] WHERE [WifeID] = " + wifeId.ToString();

            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);

            return ds;
        }


        public int InsertFamily(int husbandId, int wifeId, string marriageDate, string marriagePlace)
        {
            string sql = "INSERT INTO [Family] ([HusbandId], [WifeId], [MarriageDate], [MarriagePlace]) VALUES (" + husbandId.ToString() + ", " + wifeId.ToString() + ", '" + marriageDate.Trim() + "', '" + marriagePlace.Trim() + "')";

            dbCommand = new OleDbCommand(sql, dbConn);
            dbCommand.ExecuteNonQuery();

            dbCommand.CommandText = "SELECT MAX(ID) FROM [Family]";
            int familyId = (int)dbCommand.ExecuteScalar();

            return familyId;
        }

        public int UpdateFamilyHusbandId(int familyId, int husbandId)
        {
            return UpdateTable("Family", "HusbandId", husbandId.ToString(), familyId);
        }

        public int UpdateFamilyWifeId(int familyId, int wifeId)
        {
            return UpdateTable("Family", "WifeId", wifeId.ToString(), familyId);
        }

        public int UpdateFamilyMarriageDate(int familyId, string marriageDate)
        {
            return UpdateTable("Family", "MarriageDate", marriageDate, familyId);
        }

        public int UpdateFamilyMarriagePlace(int familyId, string marriagePlace)
        {
            return UpdateTable("Family", "MarriagePlace", marriagePlace, familyId);
        }

        //----------------------------------------------------------------------------------
        // Children
        //----------------------------------------------------------------------------------
        public DataSet GetFamilyChildren(int familyId)
        {
            string sql = "SELECT [ChildId], [Surname], [Firstname], [BornDate], [BornPlace], [DiedDate], [DiedPlace], [Gender] FROM [Individual] INNER JOIN [FamilyChildren] ON [Individual].[ID] = [FamilyChildren].[ChildId] WHERE [FamilyChildren].[FamilyId] = " + familyId.ToString();

            OleDbDataAdapter dbData = new OleDbDataAdapter(sql, dbConn);
            DataSet ds = new DataSet();
            dbData.Fill(ds);

            return ds;
        }

        public int InsertFamilyChild(int familyId, int childId)
        {
            string sql = "INSERT INTO [FamilyChildren] ([FamilyId], [ChildId]) VALUES (" + familyId.ToString() + ", " + childId.ToString() + ")";

            dbCommand = new OleDbCommand(sql, dbConn);
            dbCommand.ExecuteNonQuery();

            dbCommand.CommandText = "SELECT MAX(ID) FROM [FamilyChildren]";
            int individualId = (int)dbCommand.ExecuteScalar();

            return individualId;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
