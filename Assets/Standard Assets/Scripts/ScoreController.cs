using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {
    public Text scoreText, timeText;
    private int scoreL, scoreR;
    private int aGoal = 1;
    private float startTime, timeDiff, timeBetweenScoreSet = 1f;
    public float matchTime = 60;
	// Use this for initialization
	void Start () {
        scoreL = 0;
        scoreR = 0;
        updateText();
        startTime = Time.time;
        timeDiff = Time.time;
	}
	// Update is called once per frame
	void Update () {

        if (timeDiff < Time.time - timeBetweenScoreSet) {
            timeText.text = "" + (int)(matchTime - (Time.time - startTime));
            timeDiff = Time.time;
        }
	}
    public void AddScoreL()
    {
        scoreL = scoreL + aGoal;
        updateText();
    }
    public void AddScoreR()
    {
        scoreR = scoreR + aGoal;
        updateText();
    }
    public void SubScoreL()
    {
        scoreL = scoreL - aGoal;
        updateText();
    }
    public void SubScoreR()
    {
        scoreR = scoreR - aGoal;
        updateText();
    }
    public void updateText()
    {
        scoreText.text = scoreL + "/" + scoreR;
    }
}