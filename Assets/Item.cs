using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public float gravity, velocityX, velocityY, maxdecel, PoCGrav;
    public int itemType;
    public bool PoCProc;
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
        if (!Controller.Instance.paused)
        {
            if (Controller.Instance.player.transform.position.y >= 15f)
            {
                PoCProc = true;
            }
            if (PoCProc)
            {
                PoC();
            }
            else
            {
                Move();
            }
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
        if (coll.gameObject.tag == "Player")
        {
            //Points
            if (itemType == 0)
            {
                float yval = transform.position.y;
                Controller.Instance.points += (20000 + Mathf.RoundToInt(2000 * Mathf.RoundToInt(yval)));
            }
            //Power
            if (itemType == 1)
            {
                if (Controller.Instance.power < 4.0f)
                {
                    Controller.Instance.power += .05f;
                }
                else
                {
                    Controller.Instance.points += 1000;
                }
            }
            //1Up
            if (itemType == 2)
            {
                Controller.Instance.lives++;
            }
            //Bomb
            if (itemType == 3)
            {
                Controller.Instance.bombs++;
            }

            //Big Power
            if (itemType == 4)
            {
                if (Controller.Instance.power < 4.0f)
                {
                    Controller.Instance.power += 1;
                    if (Controller.Instance.power > 4.0f)
                    {
                        Controller.Instance.power = 4;
                    }
                }
                else
                {
                    Controller.Instance.points += 10000;
                }
            }

            Destroy(this.gameObject);
        }
    }

    void PoC()
    {
            Vector3 direction = new Vector3(Controller.Instance.player.transform.position.x - this.transform.position.x, Controller.Instance.player.transform.position.y - this.transform.position.y,0);
            direction = direction.normalized;
            transform.position += direction * PoCGrav;
    }
}
