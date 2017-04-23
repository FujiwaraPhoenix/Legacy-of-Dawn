using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiar : MonoBehaviour {
    public bool leftright;
    public Rigidbody2D rig;
    public Collider2D colli;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -5f || transform.position.y > 22f || transform.position.x < -18 || transform.position.x > 7f)
        {
            Object.Destroy(this.gameObject);
        }
        if (Controller.Instance.bossDead)
        {
            Object.Destroy(this.gameObject);
        }
        if (leftright)
        {
            transform.position += new Vector3(.05f, 0, 0);
        }
        else
        {
            transform.position += new Vector3(-.05f, 0, 0);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemyShot" || collision.tag == "shot")
        {
            Destroy(collision.gameObject);
        }
    }
}
