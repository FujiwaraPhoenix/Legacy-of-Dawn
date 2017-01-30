using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public float gravity, velocity, maxdecel;
    public int itemType;
    public Controller cont;

	// Use this for initialization
	void Start () {
        velocity = .05f;
        gravity = -.001f;
        maxdecel = -.5f;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        transform.position += new Vector3(0, velocity, 0);
        if (velocity > maxdecel)
        {
            velocity += gravity;
        }
        if (transform.position.y < 0)
        {
            Destroy(this.gameObject);
        }
        Debug.Log(this.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //Points
            if (itemType == 0)
            {
                float yval = transform.position.y;
                cont.points += (20000 + Mathf.RoundToInt(2000 * Mathf.RoundToInt(yval)));
            }
            //Power
            if (itemType == 1)
            {
                if (cont.power < 4.0f)
                {
                    cont.power += .05f;
                }
                else
                {
                    cont.points += 1000;
                }
            }
            //1Up
            if (itemType == 2)
            {

            }
            Destroy(this.gameObject);
        }
    }
}
