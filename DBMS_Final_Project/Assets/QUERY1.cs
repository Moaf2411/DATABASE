using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class QUERY1 : MonoBehaviour
{
   [SerializeField] private InputField Match;
   [SerializeField] private Canvas result,buttons;
   [SerializeField] private TextPool tp;
   private string Match_id;

   private float textWidth,canvasWidth;
   public void Query1()
   {
      
      Match_id = Match.text.ToString();
      
      String conn = "URI=file:" + Application.dataPath + "/Final_Project.db";
      IDbConnection dbconn;
      dbconn= (IDbConnection)new SqliteConnection(conn);
      dbconn.Open();
      result.gameObject.SetActive(true);
      canvasWidth = result.GetComponent<RectTransform>().rect.width;
      buttons.gameObject.SetActive(false);
      IDbCommand dbCommand = dbconn.CreateCommand();
      
      string sqlQuery =
                        "SELECT TEAM_NAME,FIRST_NAME,LAST_NAME,PLAYER.PLAYER_ID" +
                        " FROM PLAY_IN" +
                        " JOIN PLAYER ON PLAYER.Player_ID=PLAY_IN.Player_ID" +
                        " JOIN TEAM ON TEAM.Team_ID=PLAY_IN.Team_ID" +
                        " JOIN PERSON ON PLAYER.SSN=PERSON.SSN" +
                        " WHERE MATCH_ID = '" + Match_id + "' AND ENTER_TIME=0" +
                        " ORDER BY TEAM_NAME";
      
      
      dbCommand.CommandText = sqlQuery;
      IDataReader dataReader = dbCommand.ExecuteReader();
      string[] s=new string[4];
      s[0] = "TEAM_NAME";
      s[1] = "FIRST_NAME";
      s[2] = "LAST_NAME";
      s[3] = "PLAYER_ID";
      for (int i = 0; i < 4; i++)
      {
         Text t= tp.GetFromPool();
         t.text = s[i];
         textWidth = t.GetComponent<RectTransform>().rect.width;
         Debug.Log(canvasWidth/textWidth);
         t.transform.position=new Vector3(textWidth + i * (canvasWidth/4) - textWidth , 1000,0);
         t.gameObject.SetActive(true);
      }

      int j = 0;
      int k = 1;
      while (dataReader.Read())
      {
         
         Text t = tp.GetFromPool();
         t.text = dataReader.GetString(0);
         t.transform.position=new Vector3(textWidth + j * (canvasWidth/4) - textWidth ,1000 - k * 100,0);
         t.gameObject.SetActive(true);
         j++;

         t = tp.GetFromPool();
         t.text = dataReader.GetString(1);
         t.transform.position=new Vector3(textWidth + j * (canvasWidth/4) - textWidth, 1000-k*100,0 );
         t.gameObject.SetActive(true);
         j++;
         
         t = tp.GetFromPool();
         t.text = dataReader.GetString(2);
         t.transform.position=new Vector3(textWidth + j * (canvasWidth/4) - textWidth, 1000-k*100,0 );
         t.gameObject.SetActive(true);
         j++;
         
         t = tp.GetFromPool();
         t.text = dataReader.GetString(3);
         t.transform.position=new Vector3(textWidth + j * (canvasWidth/4) - textWidth, 1000-k*100,0 );
         t.gameObject.SetActive(true);
         j++;
         k++;
         j = 0;




      }
      dataReader.Close();
      dataReader = null;
      dbCommand.Dispose();
      dbCommand = null;
      dbconn.Dispose();
      dbconn = null;
   }

   public void ResultGoAway()
   {
      result.gameObject.SetActive(false);
      buttons.gameObject.SetActive(true);
   }
}
