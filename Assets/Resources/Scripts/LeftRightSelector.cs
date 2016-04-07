using UnityEngine;
using System.Collections;

public class LeftRightSelector : MonoBehaviour {
    private BigData charSel;
	// Use this for initialization
	void Start () {
        GameObject charSelector = GameObject.FindWithTag("DATA");
        if (charSelector != null)
        {
            charSel = charSelector.GetComponent<BigData>();
        }
        if (charSel == null)
        {
            Debug.Log("Cannot find 'DATA' script");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name == "LeftCheck")
        {
            charSel.addToLeftTeam(other);
        }
        if (gameObject.name == "RightCheck")
        {
            charSel.addToRightTeam(other);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.name == "LeftCheck")
        {
            
        }
        if (gameObject.name == "RightCheck")
        {
            
        }
    }
}
