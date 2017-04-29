using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigil : MonoBehaviour {
    Vector3 rotate, rotate2;

	// Use this for initialization
	void Start () {
        rotate2 = new Vector3(0, 0, -.5f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotate2);
	}
}
