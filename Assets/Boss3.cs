using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : Enemy {
    public int remainingLives, countdown, spellTimer, currentStg, rotation, rotationA, rotationB, rotationC, rotationD, timer2, timer3, offset, offset2;
    public EnemyShot shotA, shotB, rain;
    public Rigidbody2D rb;
    public Vector3 movedirection;
    public bool moving, justSpawned, pauseBeforeNext;

    // Use this for initialization
    void Start () {
        justSpawned = true;
        timer3 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Controller.Instance.paused)
        {
            if (!justSpawned)
            {
                if (currentStg == 1)
                {
                    Nonspell1();
                    spellChange(2000);
                    timer++;
                }
            }
            else
            {
                MovetoPos();
            }
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        if (Controller.Instance.bombing)
        {
            hp -= 5;
        }
    }

    void spellChange(int newHP)
    {
        if (hp < 0)
        {
            if (remainingLives > 1)
            {
                remainingLives--;
                currentStg++;
                hp = newHP;
                offset = 0;
                offset2 = 0;
                rotation = 0;
                rotationA = 0;
                rotationB = 0;
                rotationC = 0;
                rotationD = 0;
                timer = 0;
                timer2 = 0;
                timer3 = 0;
                returnToPos();
                StartCoroutine(screenWipe());
            }
            else
            {
                StartCoroutine(screenWipe());
                Destroy(this.gameObject);
            }
        }
    }

    void returnToPos()
    {
        transform.position = new Vector3(-4, 16.9f, 0);
    }

    void MovetoPos()
    {
        if (transform.position.y > 16.9)
        {
            transform.position += new Vector3(0, -.1f, 0);
        }
        else
        {
            justSpawned = false;
        }
    }

    public IEnumerator screenWipe()
    {
        Controller.Instance.clearScreen = true;
        yield return new WaitForSeconds(1);
        Controller.Instance.clearScreen = false;
    }

    void makeCircle(int number, EnemyShot type, float offset, float vel, float accel, float minv, float maxv, int tickrate, bool decelYN, int moveFx, float incr)
    {
        float betAng = 360 / number;
        //Creates number of bullets
        for (int i = 0; i < number + 1; i++)
        {
            EnemyShot circBullet = Instantiate(type, transform.position, Quaternion.identity) as EnemyShot;
            circBullet.mvtFxn = moveFx;
            circBullet.velocity = vel;
            circBullet.acceleration = accel;
            circBullet.minvelocity = minv;
            circBullet.maxvelocity = maxv;
            circBullet.ticks = tickrate;
            circBullet.direction = GlobalFxns.ToVect(betAng * i + offset);
            circBullet.increment = incr;
            if (decelYN)
            {
                circBullet.decelerating = true;
            }
            else
            {
                circBullet.decelerating = false;
            }
        }
    }

    void Nonspell1()
    {
        if (!pauseBeforeNext)
        {
            shotVel = .2f;
            if (timer == 20)
            {
                if (lr)
                {
                    offset += 2;
                }
                else
                {
                    offset -= 2;
                }
                for (int i = 0; i < 60; i++)
                {
                    EnemyShot lol = Instantiate(shotA, transform.position, Quaternion.identity);
                    lol.direction = GlobalFxns.ToVect(0 + rotation + offset);
                    lol.setParameters(4, shotVel, 0, shotVel, shotVel, 1, false);
                    rotation += 10;
                }
            }
            if (timer == 25)
            {
                if (lr)
                {
                    offset += 2;
                }
                else
                {
                    offset -= 2;
                }
                for (int i = 0; i < 60; i++)
                {
                    EnemyShot lolk = Instantiate(shotA, transform.position, Quaternion.identity);
                    lolk.direction = GlobalFxns.ToVect(0 + rotationA + offset);
                    lolk.setParameters(4, shotVel, 0, shotVel, shotVel, 1, false);
                    rotationA += 10;
                }
            }
            if (timer == 30)
            {
                if (lr)
                {
                    offset += 2;
                }
                else
                {
                    offset -= 2;
                }
                for (int i = 0; i < 60; i++)
                {
                    EnemyShot lolok = Instantiate(shotA, transform.position, Quaternion.identity);
                    lolok.direction = GlobalFxns.ToVect(0 + rotationB + offset);
                    lolok.setParameters(4, shotVel, 0, shotVel, shotVel, 1, false);
                    rotationB += 10;
                }

            }
            if (timer == 35)
            {
                if (lr)
                {
                    offset += 2;
                }
                else
                {
                    offset -= 2;
                }
                for (int i = 0; i < 60; i++)
                {
                    EnemyShot lolok = Instantiate(shotA, transform.position, Quaternion.identity);
                    lolok.direction = GlobalFxns.ToVect(0 + rotationC + offset);
                    lolok.setParameters(4, shotVel, 0, shotVel, shotVel, 1, false);
                    rotationC += 10;
                }
            }

            if (timer == 40)
            {
                if (lr)
                {
                    offset += 2;
                }
                else
                {
                    offset -= 2;
                }
                for (int i = 0; i < 60; i++)
                {
                    EnemyShot lolok = Instantiate(shotA, transform.position, Quaternion.identity);
                    lolok.direction = GlobalFxns.ToVect(0 + rotationD + offset);
                    lolok.setParameters(4, shotVel, 0, shotVel, shotVel, 1, false);
                    rotationD += 10;
                }
                pauseBeforeNext = true;
            }
        }
        else
        {
            if (timer2 > 30)
            {
                timer = 0;
                timer2 = 0;
                lr = !lr;
                pauseBeforeNext = false;
            }
            else
            {
                timer2++;
            }
        }
    }

    void Spell1()
    {

    }

//if (!pauseBeforeNext)
//        {
//            if (timer > 20)
//            {
//                shotVel = .1f;
//                shotMinV = .1f;
//                shotMaxV = .1f;
//                ticks = 1;
//                offset += 2;
//                makeCircle(20, shotA, offset, shotVel, 0, shotMinV, shotMaxV, ticks, false, 4, .5f);
//                if (timer3 > 2)
//                {
//                    pauseBeforeNext = true;
//                    timer = 0;
//                    timer3 = 0;
//                }

//timer3++;
//            }
//            timer++;
//        }
//        else
//        {
//            if (timer2 > 20)
//            {
//                pauseBeforeNext = false;
//                timer2 = 0;
//            }
//            else
//            {
//                timer2++;
//            }
//        }
}
