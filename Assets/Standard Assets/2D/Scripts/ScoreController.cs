using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {
    public Text scoreText;
    private int scoreL, scoreR;
    private int aGoal = 1;
    public int numPlayer = 2;
	// Use this for initialization
	void Start () {
        scoreL = 0;
        scoreR = 0;
        updateText();
	}
	// Update is called once per frame
	void Update () {
	    
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
    public void updateText()
    {
        scoreText.text = scoreL + "/" + scoreR;
    }
}