using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
    private ScoreController scoreController;
    // Use this for initialization
    void Start () {
        GameObject scoreControllerObject = GameObject.FindWithTag("ScoreManager");
        if (scoreControllerObject != null)
        {
            scoreController = scoreControllerObject.GetComponent<ScoreController>();
        }
        if (scoreController == null)
        {
            Debug.Log("Cannot find 'ScoreController' script");
        }
    }
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball" && gameObject.name == "Goal_L")
        {
            scoreController.AddScoreL();
        } if(other.gameObject.tag == "Ball" && gameObject.name == "Goal_R")
        {
            scoreController.AddScoreR();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball" && gameObject.name == "Goal_L")
        {
            scoreController.SubScoreL();
        }
        if (other.gameObject.tag == "Ball" && gameObject.name == "Goal_R")
        {
            scoreController.SubScoreR();
        }
    }

}
