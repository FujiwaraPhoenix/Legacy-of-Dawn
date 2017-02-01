using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int hp, timer;
    public bool upY;
    public BoxCollider2D hitbox;
    public Controller cont;

    // Use this for initialization
    void Start () {
        setHP(50);
        upY = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (hp < 1)
        {
            Destroy(this.gameObject);
        }
        if (upY)
        {
            hover(0, 0.005f);
        }
        else
        {
            hover(0, -0.005f);
        }
    }

    void setHP(int val)
    {
        hp = 50;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "shot")
        {
            Destroy(coll.gameObject);
            hp = hp - cont.dmg;
        }
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
        }
        if (coll.gameObject.tag == "invulnShot")
        {
            hp = hp - cont.dmg;
        }
    }

    void hover(float x, float y)
    {
        if (upY)
        {
            Vector3 pos = transform.position;
            pos.x += x;
            pos.y += y;
            transform.position = pos;
            timer++;
            if (timer == 60)
            {
                upY = !upY;
            }
        }
        else
        {
            Vector3 pos = transform.position;
            pos.x += x;
            pos.y += y;
            transform.position = pos;
            timer--;
            if (timer == -1)
            {
                upY = !upY;
            }
        }
    }
}
