using UnityEngine;
using System.Collections;

public class ShipSelector : MonoBehaviour {
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
        
        if (gameObject.name == "Shippy_Selector" && other.gameObject.transform.parent.gameObject.name != "Shippy_idol")
        {
            charSel.addShippy(other);
        }
    }
}
