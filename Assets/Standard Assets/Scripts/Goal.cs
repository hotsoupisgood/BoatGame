using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
    private ScoreController scoreController;
    public Rigidbody2D eL, eR, hull, ball, hook;
    private bool locked = false;
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
        if (locked)
        {
            ball.position = hook.position;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "GoalL")
        {
            scoreController.AddScoreL();
        } if(other.gameObject.tag == "GoalR")
        {
            scoreController.AddScoreR();
        }
    }
    public void lockToHook()//a toggle
    {
        locked = !locked;
    }
}
