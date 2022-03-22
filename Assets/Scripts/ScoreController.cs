using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text score;
    public Text highScore;
    private float scorePlayer;
    private float Highscore;
    // Start is called before the first frame update
    void Start()
    {
        Highscore = PlayerPrefs.GetFloat("highscore");
        scorePlayer = PlayerPrefs.GetFloat("score");
        if (scorePlayer >= Highscore)
        {
            Highscore = scorePlayer;
            PlayerPrefs.SetFloat("highscore", Highscore);
        }
        score.text = "Score:" + scorePlayer.ToString();
        highScore.text = "High score:" + Highscore.ToString();

    }


}
