using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;

public class QUERY1 : MonoBehaviour
{
   public void Query1()
   {
      String conn = "URI=file:" + Application.dataPath + "/Final_Project.db";
      IDbConnection dbconn;
      dbconn= (IDbConnection)new SqliteConnection(conn);
      dbconn.Open();
      IDbCommand dbCommand = dbconn.CreateCommand();
      
      string sqlQuery =
                        "SELECT TEAM_NAME,FIRST_NAME,LAST_NAME,PLAYER.PLAYER_ID" +
                        " FROM PLAY_IN" +
                        " JOIN PLAYER ON PLAYER.Player_ID=PLAY_IN.Player_ID" +
                        " JOIN TEAM ON TEAM.Team_ID=PLAY_IN.Team_ID" +
                        " JOIN PERSON ON PLAYER.SSN=PERSON.SSN" +
                        " WHERE MATCH_ID='m2' AND ENTER_TIME=0" +
                        " ORDER BY TEAM_NAME";
      
      dbCommand.CommandText = sqlQuery;
      IDataReader dataReader = dbCommand.ExecuteReader();
      while (dataReader.Read())
      {
         Debug.Log(dataReader.GetString(0));  
         Debug.Log(dataReader.GetString(1));  
         Debug.Log(dataReader.GetString(2));
         Debug.Log(dataReader.GetString(3));
      }
      dataReader.Close();
      dataReader = null;
      dbCommand.Dispose();
      dbCommand = null;
      dbconn.Dispose();
      dbconn = null;
   }
}
