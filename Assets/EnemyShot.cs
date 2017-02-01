using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {
    public Controller cont;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		move();
	}

    void move()
    {
        transform.position += new Vector3(0, -.25f, 0);
        if (transform.position.y < 1f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.transform.position = new Vector3(-6, 2, 0);
            cont.lives--;
            cont.bombs = 3;
            if (cont.power < 2f)
            {
                cont.power = 1f;
            }
            else if (cont.power >= 2f)
            {
                cont.power -= 1f;
            }
            Destroy(this.gameObject);
        }
    }
}
