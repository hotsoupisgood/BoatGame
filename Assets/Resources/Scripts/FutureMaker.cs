using UnityEngine;
using System.Collections;

public class FutureMaker : MonoBehaviour {
    private Vector3[] spawnPoints;
    private GameObject[] players;
    private BigData bDicks;
    private string[,] playerData;
    private int numPlayers = 4, sD = 2;
	// Use this for initialization
	void Start () {
        spawnPoints = new Vector3[4];
        spawnPoints[0].x = -4.7f; spawnPoints[0].y = -4.3f; spawnPoints[0].z = 90.0f;
        spawnPoints[1].x = -6.8f; spawnPoints[1].y = -1.0f; spawnPoints[0].z = 180.0f;
        spawnPoints[2].x = 4.8f; spawnPoints[2].y = 3.8f; spawnPoints[0].z = -90.0f;
        spawnPoints[3].x = 6.5f; spawnPoints[3].y = 1.32f; spawnPoints[0].z = 0.0f;

        players = new GameObject[numPlayers];

        GameObject tempBigDick = GameObject.FindWithTag("DATA");
        if (tempBigDick != null)
        {
            bDicks = tempBigDick.GetComponent<BigData>();
            playerData = bDicks.getPlayerData();
            numPlayers = bDicks.getNumCharacters();
            for (int x = 0; x < numPlayers; x++)
            {
                for (int y = sD-1; y >= 0; y--)
                {//fuckinnnnn does shit, 
                    if (y == 1)
                    {
                        players[x] = (GameObject)Instantiate(Resources.Load("Prefabs/" + playerData[x, y]), new Vector3(spawnPoints[x].x, spawnPoints[x].y, 0), new Quaternion());

                        players[x].transform.localScale = new Vector3(.5f, .5f, 1.0f);

                        players[x].name = playerData[x, 0];

                        players[x].transform.Rotate(new Vector3(0, 0, spawnPoints[x].z));
                    }
                }
            }
        }
        if (bDicks == null)
        {
            Debug.Log("Cannot find 'DATA' script");
        }
       
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
