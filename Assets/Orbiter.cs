using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : Bullet {
    public bool on;
    public SpriteRenderer spriteRenderer;
    public Sprite a;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        onoff();
        move2();
        counter++;
        Fire1();
	}

    void onoff()
    {
        if (!on) {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
    }

    void Fire1()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (bulletType == 1)
            {
                if (counter > 5)
                {
                    if (on)
                    {
                        Bullet Copy = (Instantiate(shot2, transform.position, Quaternion.identity)) as Bullet;
                        counter = 0;
                    }
                }
            }
        }
    }

    void move2()
    {
        Vector3 radius = new Vector3(0, 0, 1);
        transform.RotateAround(player.transform.position, radius, 360 * Time.deltaTime);
    }
}
