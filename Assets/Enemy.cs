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
            Debug.Log("Ayy");
            Destroy(coll.gameObject);
            hp = hp - cont.dmg;
        }
        Debug.Log("Colliding!");
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
