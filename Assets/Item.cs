using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public float gravity, velocityX, velocityY, maxdecel, PoCGrav;
    public int itemType;
    public Controller cont;

	// Use this for initialization
	void Start () {
        velocityY = .05f;
        gravity = -.001f;
        maxdecel = -.5f;
        PoCGrav = .5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (cont.player.transform.position.y >= 15f)
        {
            PoC();
        }
        else
        {
            Move();
        }
	}

    void Move()
    {
        transform.position += new Vector3(0, velocityY, 0);
        if (velocityY > maxdecel)
        {
            velocityY += gravity;
        }
        if (transform.position.y < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "PlayerHitbox")
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
                cont.lives++;
            }
            //Bomb
            if (itemType == 2)
            {
                cont.bombs++;
            }
            Destroy(this.gameObject);
        }
    }

    void PoC()
    {
            Vector3 direction = new Vector3(cont.player.transform.position.x - this.transform.position.x, cont.player.transform.position.y - this.transform.position.y,0);
            direction = direction.normalized;
            transform.position += direction * PoCGrav;
    }
}
