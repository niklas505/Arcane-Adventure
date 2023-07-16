using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreDisplay;
    [SerializeField]
    private TextMeshProUGUI highscoreDisplay;
    private int shoots;
    private int hits;
    private int stagesCleared;
    private float score;
    private float highscore;

    
    void OnEnable()
    {
        calculateScore();
        calculateHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score: " + score;
        highscoreDisplay.text = "Highscore: " + highscore;
    }

    private void calculateScore() {
        shoots = PlayerPrefs.GetInt("shoots");
        hits = PlayerPrefs.GetInt("hits");
        stagesCleared = PlayerPrefs.GetInt("stagesCleared");
        score = (float) stagesCleared * ((float) hits / (float) shoots);
    }

    private void calculateHighscore() {
        highscore = PlayerPrefs.GetFloat("highscore", 0);
        if (score > highscore) {
            highscore = score;
            PlayerPrefs.SetFloat("highscore", highscore);
        } 
    }
}
