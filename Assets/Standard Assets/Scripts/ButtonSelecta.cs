using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelecta : MonoBehaviour , IPointerEnterHandler, ISelectHandler{
    public string mA = "menuActivate", vert = "vertical", hor = "horizontal";
    private bool highlighted = false;
    public Button button;
    public void OnPointerEnter(PointerEventData eventData)
    {
        highlighted = true;
        //do your stuff when highlighted
    }//fuckfuck fuck i dont know what to do why is there not a gethighlight fucking function.
    public void OnSelect(BaseEventData eventData)
    {
        //do your stuff when selected
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (highlighted)
        {
            if (Input.GetAxis(vert) < 0)
            {
                //button.FindSelectableOnDown;
                highlighted = false;
            }

            if (Input.GetAxis(vert) > 0)
            {
                highlighted = false;
            }
        }
    }
}
