using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}
    void move()
    {
        transform.position += new Vector3(0, .25f, 0);
        if (transform.position.y > 19.5f)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
