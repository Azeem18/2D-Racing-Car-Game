using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{
    public TextMesh ScoreTest;
    public TextMesh highScoreText;
    public TextMesh lastScoreText;

    public int score = 0;
    public int highScore;
    public int lastScore;

    void Start()
    {
        StartCoroutine(ScoreIncrease());
        highScore = PlayerPrefs.GetInt("high_score",0);//Initialy when game starts, highscore value will be the values stored or for first time default value 0 will be stored
        lastScore = PlayerPrefs.GetInt("last_score",0);
        highScoreText.text = "HighScore: " + highScore.ToString();
        lastScoreText.text = "LastScore: " + lastScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
      //Updating game score
      ScoreTest.text = score.ToString();  
      //Updating high score 
      if(score>highScore){
        highScore=score;
        PlayerPrefs.SetInt("high_score",highScore);//For permanently storing high score of player
      }
      //Updating last score
      if(score>0)
        {
          lastScore = score;
          PlayerPrefs.SetInt("last_score",lastScore);
        }
      
    }

    IEnumerator ScoreIncrease(){
       while(true){
        yield return new WaitForSeconds(0.8f);
        score+=1;
       }
    }
}
