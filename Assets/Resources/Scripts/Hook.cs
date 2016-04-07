using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {
    public GameObject hullGO;
    public Rigidbody2D hull, ball;
    private Rigidbody2D hook;
    public int speedShot = 50, distanceStopRetract = 3, hookedMass, normMass;
    private float currentSpeedRetract = 0;
    public float speedConstaint = .5f;
    private bool shootHook = false;//shoots hook toward ball
    private bool hooked = false;//once hits ball
    private Vector2 rbDiff;//reusable diff between objects
    private LineRenderer lineRenderer;
    private Vector2 hullCenterPos;
    private FixedJoint2D ballToHookJoint;
    // Use this for initialization
    void Start () {
        hook = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        ballToHookJoint = gameObject.AddComponent<FixedJoint2D>();
        ballToHookJoint.connectedBody = hull;
        ballToHookJoint.autoConfigureConnectedAnchor = false;
        ballToHookJoint.enableCollision = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if (shootHook)//shoot to ball
        {
            rbDiff = ball.position - hook.position;
            rbDiff.Normalize();
            hook.AddForce(rbDiff * speedShot);
        }
        if (hooked)//retract to hull
        {
            //ball.position = hook.position;
            if (Vector2.Distance(hull.position, hook.position) > distanceStopRetract)
            {
                rbDiff = hull.position - hook.position;//destination - obj
                rbDiff.Normalize();
                currentSpeedRetract = ((Vector2.Distance(hull.position, hook.position) - distanceStopRetract) * speedConstaint);
                hook.AddForce(rbDiff * currentSpeedRetract);//keep hook at certian distance
            }
        }
        hullCenterPos.x = hull.position.x + Mathf.Cos(hull.transform.eulerAngles.z * Mathf.Deg2Rad);
        hullCenterPos.y = hull.position.y + Mathf.Sin(hull.transform.eulerAngles.z * Mathf.Deg2Rad);
        lineRenderer.SetPosition(0, hullCenterPos);
        lineRenderer.SetPosition(1, hook.position);
        //lineRenderer.SetColors(Color.white, Color.white);//notfuckingworking!!!!!!
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Ball" && shootHook)
        {
            if (!hooked)
            {
                shootHook = false;
                hooked = true;
                ball = other.rigidbody;
                ballToHookJoint.connectedBody = ball;
                setJointEnabled(true);
            }
        } 
    }
    public void ToggleHooked()
    {
        hooked = !hooked;
    }
    public void ToggleShootHook()
    {

        if (hooked)
        {//unhook if hooked
            hooked = false;
            setJointEnabled(true);
            ballToHookJoint.connectedBody = hull;
            hook.mass = 0;
            //setJointEnabled(false);
        }
        else
        {
            shootHook = !shootHook;
            ballToHookJoint.enabled = false;
            hook.mass = .2f;
        }
    }
   private void setJointEnabled(bool isEnabled)
    {
        ballToHookJoint.enabled = isEnabled;

    }
}
