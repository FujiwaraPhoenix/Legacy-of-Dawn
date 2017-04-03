using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {
    public float vel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <-9f)
        {
            BGScroll newV = Instantiate(this, new Vector3(-4, 29.2f, this.transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
        transform.position += new Vector3(0, -vel, 0);
    }
}
