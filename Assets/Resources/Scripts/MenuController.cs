using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //public Button start, exit;
    //public GameObject 
    void Start()
    {
    }
    void Update()
    {
    }
    public void StartLevel1() //this function will be used on our Play button

    {
        SceneManager.LoadScene("TeamSelect");
    }

    public void ExitGame() //This function will be used on our "Yes" button in our Quit menu

    {
            Application.Quit(); //this will quit our game. Note this will only work after building the game
    }

}