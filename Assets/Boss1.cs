using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Enemy {
    public int remainingLives, countdown, spellTimer, currentStg, rotation, timer2, timer3;
    public EnemyShot bulletA;
    public Rigidbody2D rb;
    public Vector3 movedirection;
    public bool moving;
    public float velocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Nonspell1();
        randomMove();
        timer++;
        timer2++;
	}

    //Nonspell 1
    void Nonspell1()
    {
        if (currentStg == 1)
        {
            if (timer > 15) {
   //             Vector3 aim = new Vector3(0,0,0);
                EnemyShot a = (Instantiate(bulletA, transform.position, Quaternion.Euler(GlobalFxns.ToVect(0 + rotation))) as EnemyShot);
                EnemyShot b = (Instantiate(bulletA, transform.position, Quaternion.Euler(GlobalFxns.ToVect(120 + rotation))) as EnemyShot);
                EnemyShot c = (Instantiate(bulletA, transform.position, Quaternion.Euler(GlobalFxns.ToVect(240 + rotation))) as EnemyShot);
                a.direction = (GlobalFxns.ToVect(0 + rotation));
                b.direction = (GlobalFxns.ToVect(120 + rotation));
                c.direction = (GlobalFxns.ToVect(240 + rotation));
                a.velocity = .05f;
                b.velocity = .05f;
                c.velocity = .05f;
                a.mvtFxn = 1;
                b.mvtFxn = 1;
                c.mvtFxn = 1;
                rotation += 10;
                timer = 0;
                a.acceleration = 0;
                b.acceleration = 0;
                c.acceleration = 0;
                a.minvelocity = .05f;
                b.minvelocity = .05f;
                c.minvelocity = .05f;
                a.maxvelocity = .05f;
                b.maxvelocity = .05f;
                c.maxvelocity = .05f;
                a.ticks = 1;
                b.ticks = 1;
                c.ticks = 1;
            }
        }
    }

    void randomMove()
    {
        int random = Random.Range(0, 50);
        int random2 = Random.Range(-90, 90);
        int random3 = Random.Range(0, 2);
        if (!moving && timer2 > 120 && random > 40)
        {
            if (random3 == 0)
            {
                if (transform.position.x < 0 && transform.position.y > 12 && transform.position.y < 20)
                {
                    velocity = .01f;
                    movedirection = GlobalFxns.ToVect(random2);
                    moving = true;
                    timer2 = 0;
                }
            }
            else
            {
                if (transform.position.x > -12 && transform.position.y > 12 && transform.position.y < 20)
                {
                    velocity = -.01f;
                    movedirection = GlobalFxns.ToVect(random2);
                    moving = true;
                    timer2 = 0;
                }
            }
        }
        else
        {
            if (timer3 < 120)
            {
                if (transform.position.x > -12 && transform.position.x < 2 && transform.position.y > 15 && transform.position.y < 18)
                {
                    transform.position += movedirection * velocity;
                }
                else
                {
                    if ((movedirection.x > 0 && transform.position.x > 2)||(movedirection.x < 0 && transform.position.x < -12)) {
                        movedirection.x *= -1;
                        transform.position += movedirection * velocity;
                    }
                    if ((movedirection.y > 0 && transform.position.y > 18) || (movedirection.y < 0 && transform.position.y < 15))
                    {
                        movedirection.y *= -1;
                        transform.position += movedirection * velocity;
                    }
                }
            }
            else if (timer3 > 180)
            {
                moving = !moving;
                timer3 = 0;
            }
            timer3++;
        }
    }

    void 
}
