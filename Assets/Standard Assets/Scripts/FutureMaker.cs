using UnityEngine;
using System.Collections;

public class FutureMaker : MonoBehaviour {
    private Vector3[] mapPositions;
	// Use this for initialization
	void Start () {
        mapPositions = new Vector3[4];
        mapPositions[0].x = -4.7f; mapPositions[0].y = -4.3f; mapPositions[0].z = 90.0f;
        mapPositions[1].x = -7.1f; mapPositions[1].y = -2.0f; mapPositions[0].z = 180.0f;
        mapPositions[2].x = 4.8f; mapPositions[2].y = 3.8f; mapPositions[0].z = -90.0f;
        mapPositions[3].x = 7.33f; mapPositions[3].y = 1.32f; mapPositions[0].z = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
