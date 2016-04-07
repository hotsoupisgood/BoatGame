using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BigData : MonoBehaviour {
    public BoxCollider2D left, right;
    private string[,] playerData = null;
    private int numCharacters = 4, charAtributes = 2;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        if (playerData == null)
        {
            playerData = new string[numCharacters, charAtributes];
            for (int i = 0; i < numCharacters; i++)
            {
                for (int p = 0; p < charAtributes; p++)
                {
                    playerData[i, p] = null;
                }
            }
        }
    }
	// top left is 0 bot left is 1
    //top right is 2, bot right is 3
	// Update is called once per frame
	void Update () {
    }
    public void addShippy(Collider2D other)
    {
        
        for (int i = 0; i < numCharacters; i++)
        {
            if (other.gameObject.transform.parent.gameObject.name == playerData[i, 0])
            {
                playerData[i, 1] = "Shippy"; 
                other.gameObject.transform.parent.gameObject.SetActive(false);
                break;
            }
        }
        checkDoneChars();
    }
    public void addToLeftTeam (Collider2D other)
    {
        
        if (other.gameObject.transform.parent.gameObject.name == "P1")
        {
            setL(other);
        }
        if (other.gameObject.transform.parent.gameObject.name == "P2")
        {
            setL(other);
        }
        if (other.gameObject.transform.parent.gameObject.name == "P3")
        {
            setL(other);
        }
        if (other.gameObject.transform.parent.gameObject.name == "P4")
        {
            setL(other);
        }
    }
    public void addToRightTeam(Collider2D other)
    {
        if (other.gameObject.transform.parent.gameObject.name == "P1")
        {
            setR(other);
        }
        if (other.gameObject.transform.parent.gameObject.name == "P2")
        {
            setR(other);
        }
        if (other.gameObject.transform.parent.gameObject.name == "P3")
        {
            setR(other);
        }
        if (other.gameObject.transform.parent.gameObject.name == "P4")
        {
            setR(other);
        }
    }
    private void setL(Collider2D other)
    {
        for (int i = 0; i < 2; i++)//need some thinking done to check if only  2 players
            if (playerData[i, 0] == null)
            {
                playerData[i, 0] = other.gameObject.transform.parent.gameObject.name;
                other.gameObject.transform.parent.gameObject.SetActive(false);
                checkDoneTeams();
                break;
            }
    }
    private void setR(Collider2D other)
    {
        for (int i = 2; i < numCharacters; i++)//need some thinking done to check if only  2 players
            if (playerData[i, 0] == null)
            {
                playerData[i, 0] = other.gameObject.transform.parent.gameObject.name;
                other.gameObject.transform.parent.gameObject.SetActive(false);
                checkDoneTeams();
                break;
            }
    }
    private void checkDoneTeams ()
    {
        bool moveOn = true;
        for (int i = 0; i < numCharacters; i++)
        {
            if (playerData[i, 0] == null)
            {
               moveOn = false;
            }
        }
        if (moveOn)
        {
            SceneManager.LoadScene("ShipSelect");
        }//dothings
    }
    private void checkDoneChars ()
    {
        bool moveOn = true;
        for (int i = 0; i < numCharacters; i++)
        {
            for (int p = 0; p < charAtributes; p++)
            {
                if (playerData[i, p] == null)
                {
                    moveOn = false;
                }
            }
        }
        if (moveOn) {
            SceneManager.LoadScene("Future");
        }//dothings
    }
    public void onQuit()
    {
        playerData = null;
    }
    public string[,] getPlayerData ()
    {
        return playerData;
    }public int getNumCharacters()
    {
        return numCharacters;
    }
}
