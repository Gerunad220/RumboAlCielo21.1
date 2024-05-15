using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo
{
    public string name;
    public int score;

    public PlayerInfo(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

}
public class Leaderboard : MonoBehaviour
{
    public InputField userName;
    public InputField score;
    public InputField display;

    List<PlayerInfo> collectedStats;


    // Start is called before the first frame update
    void Start()
    {
        collectedStats = new List<PlayerInfo> ();
        LoadLeaderBoard();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitButton()
    {
        PlayerInfo stats = new PlayerInfo(userName.text, int.Parse(score.text));
        collectedStats.Add (stats);

        userName.text = "";
        score.text = "";

        SortStats();
    }

    void SortStats()
    {
        for (int i = collectedStats.Count - 1; i > 0; i--)
        {
            if (collectedStats[i].score > collectedStats[i - 1].score)
            {
                PlayerInfo tempInfo = collectedStats[i - 1];

                collectedStats[i - 1] = collectedStats[i];
                collectedStats[i] = tempInfo;
            }
        }

        UpdatePlayerPrefsString();
    }

    void UpdatePlayerPrefsString()
    {
        string stats = "";

        for (int i = 0; i < collectedStats.Count; i++)
        {
            stats += collectedStats[i].name + ",";
            stats += collectedStats[i].score + ",";
        }

        PlayerPrefs.SetString("LeaderBoards", stats);

        UpdateLeaderBoardVisual();

    }

    void UpdateLeaderBoardVisual()
    {
        display.text = "";

        for (int i = 0; i <= collectedStats.Count - 1; i ++)

        {
            display.text += collectedStats[i].name + " : " + collectedStats[i].score + "\n";
        }
    }

    void LoadLeaderBoard()
    {
        string stats = PlayerPrefs.GetString("LeaderBoards", "");
        string[] stats2 = stats.Split(',');

        for (int i = 0; i < stats2.Length - 2; i += 2)
        {
            PlayerInfo loadedInfo = new PlayerInfo(stats2[i], int.Parse(stats2[i + 1]));
            collectedStats.Add(loadedInfo);
            UpdateLeaderBoardVisual();
        }
    }

    public void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
        display.text = "";
    }
}

