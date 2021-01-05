using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class dbHandler : MonoBehaviour
{
    private void Start()
    {
            String conn = "URI=file:" + Application.dataPath + "/Final_Project.db";
            IDbConnection dbconn;
            dbconn= (IDbConnection)new SqliteConnection(conn);
            dbconn.Open();
            IDbCommand dbCommand = dbconn.CreateCommand();
            string sqlQuery ="SELECT * FROM STADIUM_OWNERSHIP";
            dbCommand.CommandText = sqlQuery;
            IDataReader dataReader = dbCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Debug.Log(dataReader.GetString(0));  //STADIUM_ID
                Debug.Log(dataReader.GetString(1));  //TEAM_ID
            }
            dataReader.Close();
            dataReader = null;
            dbCommand.Dispose();
            dbCommand = null;
            dbconn.Dispose();
            dbconn = null;
    }
}
