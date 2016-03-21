using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Canvas quitMenu, mainMenu, newGameMenu;
    public Button startText, exitText;
    public bool introMenuOn = false;
    public string mA = "menuActivate", vert = "vertical";
    //public GameObject 
    void Start()
    {
        //mainMenu.enabled = introMenuOn;
        quitMenu.enabled = false;
        newGameMenu.enabled = false;
        //mainMenu.gameObject.SetActive(mainMenu.enabled);
    }
    void Update()
    {
       /* if (true)
        {
            if (Input.GetAxis(vert) < 0)
            {
                myEventSystem.
            }

            if (Input.GetAxis(vert) > 0)
            {

            }

        }*/
    }

    public void ExitPress() //this function will be used on our Exit button

    {
        quitMenu.enabled = true; //enable the Quit menu when we click the Exit button
        mainMenu.gameObject.SetActive(false);
    }

    public void NoPress() //this function will be used for our "NO" button in our Quit Menu

    {
        quitMenu.enabled = false; //we'll disable the quit menu, meaning it won't be visible anymore
        mainMenu.gameObject.SetActive(true);

    }

    public void StartLevel() //this function will be used on our Play button

    {
        mainMenu.gameObject.SetActive(false);
        newGameMenu.enabled = true;
        quitMenu.enabled = false;
    }
    public void StartLevel1() //this function will be used on our Play button

    {
        SceneManager.LoadScene("FuckedWaterScene");
    }

    public void StartLevel2() //this function will be used on our Play button

    {
        SceneManager.LoadScene("ArenaScene1");
    }

    public void ExitGame() //This function will be used on our "Yes" button in our Quit menu

    {
            Application.Quit(); //this will quit our game. Note this will only work after building the game
    }

}