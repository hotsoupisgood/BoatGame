using UnityEngine;
using System.Collections;

public class ShipMove : MonoBehaviour {
    public Rigidbody2D eL, eR, hull, ball, hook;
    private Hook hkScript;
    public int engineForce = 35, hopForce = -500, hookSpeed = 50;
    private float hopTime;
    public float timeBetweenHop = .5F;
    private string pL = "pushL_", pR = "pushR_", hop = "hop_", tractorBeam = "";
    public GameObject blastL, blastR;
    private bool isControlled = true;
    // Use this for initialization
    void Start()
    {
        hopTime = Time.time;
        hkScript = hook.GetComponent("Hook") as Hook;
        pL = pL + gameObject.transform.parent.gameObject.name;
        pR = pR + gameObject.transform.parent.gameObject.name;
        hop = hop + gameObject.transform.parent.gameObject.name;
    }
    // Update is called once per frame
    void Update()
    {
        if (isControlled)
        {
            if (Input.GetAxis(pR) != 0)//controller
            {//add trigger(controller) force to right engi(reletive of how hard you push

                eR.AddRelativeForce(new Vector2(0, engineForce * Input.GetAxis(pR)));
                blastR.SetActive(true);
            }
            else if (Input.GetButton(pR))//key
            {//add force to right engine with keyboard button
                eR.AddRelativeForce(new Vector2(0, engineForce));
                blastR.SetActive(true);
            }
            else
                blastR.SetActive(false);
            if (Input.GetAxis(pL) != 0)//controller
            {//add trigger force for left engi(reletive to how hard you push
                eL.AddRelativeForce(new Vector2(0, engineForce * Input.GetAxis(pL)));
                blastL.SetActive(true);
            }
            else if (Input.GetButton(pL))//key
            {//add force to left engine with keyboard button
                eL.AddRelativeForce(new Vector2(0, engineForce));
                blastL.SetActive(true);
            }
            else
                blastL.SetActive(false);
            if (Input.GetButton(hop) && (hopTime < Time.time - timeBetweenHop))
            {//hop!
                hull.AddRelativeForce(new Vector2(0, hopForce));
                hopTime = Time.time;
            }
            //if (Input.GetButtonDown(tractorBeam))
            //{//shoot hook
            //    hkScript.ToggleShootHook();
            //}
        }
    }
    public void setControlled (bool set)
    {
        isControlled = set;
    }
}
