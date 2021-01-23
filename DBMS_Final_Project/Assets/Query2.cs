using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class Query2 : MonoBehaviour
{
    [SerializeField] private InputField Team_ID, Team_name;
    [SerializeField] private Canvas buttons, results;
    [SerializeField] private TextPool tp;
    private string t_id, t_name;

    public void QUERY2()                                              //STORING DATA IN DATABASE
    {
        t_id = Team_ID.text;
        t_name = Team_name.text;
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/Final_Project.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open();
        results.gameObject.SetActive(true);
        buttons.gameObject.SetActive(false);
        IDbCommand dbCommand= dbconn.CreateCommand();

        string sqlQuery = "INSERT INTO PLAY_IN VALUES (" 
                          + "'" + Team_ID.text + "'" 
                          + ",'" 
                          + Team_name.text + "')";
        dbCommand.CommandText = sqlQuery;
        try
        {
            dbCommand.ExecuteReader();
        }
        catch (Exception exe)
        {
            Debug.Log(exe);
        }
        
        
        





    }
    
    public void ResultGoAway()
    {
        results.gameObject.SetActive(false);
        buttons.gameObject.SetActive(true);
    }





}
