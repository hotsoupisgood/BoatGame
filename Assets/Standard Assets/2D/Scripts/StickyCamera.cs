using UnityEngine;
using System.Collections;

public class StickyCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.localScale = transform.lossyScale;
	}
}
