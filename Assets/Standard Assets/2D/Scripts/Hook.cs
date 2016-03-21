using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {
    public GameObject hullGO;
    public Rigidbody2D hull, ball;
    private Rigidbody2D hook;
    public int speedShot = 50, distanceStopRetract = 3;
    private float currentSpeedRetract = 0;
    public float speedConstaint = .5f;
    private bool shootHook = false;//shoots hook toward ball
    private bool hooked = false;//once hits ball
    private Vector2 rbDiff;//reusable diff between objects
    private LineRenderer lineRenderer;
    // Use this for initialization
    void Start () {
        hook = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
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
            ball.position = hook.position;
            if (Vector2.Distance(hull.position, hook.position) > distanceStopRetract)
            {
                rbDiff = hull.position - hook.position;//destination - obj
                rbDiff.Normalize();
                currentSpeedRetract = ((Vector2.Distance(hull.position, hook.position) - distanceStopRetract) * speedConstaint);
                hook.AddForce(rbDiff * currentSpeedRetract);//keep hook at certian distance
            }
        }
        rbDiff = hook.position - hull.position;//destination - obj
        rbDiff.Normalize();
        lineRenderer.SetPosition(0, hull.position);
        lineRenderer.SetPosition(1, hook.position);
        lineRenderer.SetColors(Color.white, Color.white);
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
            }
        } 
    }
    public void ToggleHooked()
    {
        hooked = !hooked;
    }
    public void ToggleShootHook()
    {

        shootHook = !shootHook;
    }
}
