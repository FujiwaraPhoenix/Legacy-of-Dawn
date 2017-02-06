using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : Bullet {
    public bool on;
    public Controller cont;
    public SpriteRenderer spriteRenderer;
    public Sprite a;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        onoff();
        cont.laserProcTimer++;
        Fire();
        cont.laserActive = on;
    }

    void onoff()
    {
        if (!on)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
    }

    void Fire()
    {
        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift))
        {
            if (bulletType == 0)
            {
                on = true;
            }
        }
        else
        {
            on = false;
        }
    }
}
