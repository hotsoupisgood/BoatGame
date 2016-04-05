using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public bool introMenuOn = true;
    public string mA = "menuActivate";
    public GameObject mainMenu;
    public float timeBetweenPress = .5F;
    void Start () {
        mainMenu.SetActive(introMenuOn);
    }
	
	// Update is called once pezr frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Butdown");
            introMenuOn = !introMenuOn;
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        mainMenu.SetActive(introMenuOn);
    }
}
