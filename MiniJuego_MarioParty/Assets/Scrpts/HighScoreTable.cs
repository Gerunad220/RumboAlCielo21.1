using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    /*private Transform entryContainer;
        private Transform entryTemplate;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreentrycontainer");
        entryTemplate = entryContainer.Find("highscoreentrytemplate");

        entryTemplate.gameObject.SetActive(false);

        for (int i = 0; i < 4; i++)
        {
            float templateHeight= 20f;

            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0,- templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;
            switch (rank)
            {
                default:
                    rankString = rank + "TH"; break;

                    case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;
                

            }
            entryTransform.Find("posText").GetComponent<Text>().text = rankString;
            int score = Random.Range(0, 10);

            entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

            string name = "Mario";
            entryTransform.Find("nameText").GetComponent<Text>().text = name;
        }
    }*/
}
