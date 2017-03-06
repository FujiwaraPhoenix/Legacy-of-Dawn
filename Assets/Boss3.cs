﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : Enemy {
    public int remainingLives, countdown, spellTimer, currentStg, rotation, rotationA, rotationB, rotationC, rotationD, timer2, timer3, offset, offset2;
    public EnemyShot shotA, shotB, rain;
    public Familiar fam;
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
                if (currentStg == 2)
                {
                    Spell1();
                    spellChange(2000);
                    timer++;
                }
                if (currentStg == 3)
                {
                    Nonspell2();
                    spellChange(2000);
                }
                if (currentStg == 4)
                {
                    Spell2();
                    timer++;
                    spellChange(2000);
                }
                if (currentStg == 5)
                {
                    Spell3();
                    timer++;
                    spellChange(2000);
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
            shotVel = .1f;
            if (timer == 20)
            {
                if (lr)
                {
                    offset += 1;
                }
                else
                {
                    offset -= 1;
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
                    offset += 1;
                }
                else
                {
                    offset -= 1;
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
                    offset += 1;
                }
                else
                {
                    offset -= 1;
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
                    offset += 1;
                }
                else
                {
                    offset -= 1;
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
                    offset += 1;
                }
                else
                {
                    offset -= 1;
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
        if (timer > 1)
        {
            EnemyShot pew = Instantiate(shotA, transform.position, Quaternion.identity);
            pew.direction = GlobalFxns.ToVect(offset - 90);
            pew.setParameters(1, .075f, 0, .075f, .075f, 1, false);
            pew.transform.eulerAngles = new Vector3(0, 0, offset - 90);
            EnemyShot pewpew = Instantiate(shotB, transform.position, Quaternion.identity);
            pewpew.direction = GlobalFxns.ToVect(offset2 - 90);
            pewpew.setParameters(1, .05f, 0, .05f, .05f, 1, false);
            pewpew.transform.eulerAngles = new Vector3(0, 0, offset2 - 90);
            offset += 22;
            offset2 -= 7;
            timer = 0;
        }
    }

    void Nonspell2()
    {
        if (!pauseBeforeNext)
        {
            if (timer > 20)
            {
                shotVel = .1f;
                shotMinV = .1f;
                shotMaxV = .1f;
                ticks = 1;
                offset += 2;
                makeCircle(20, shotA, offset, shotVel, 0, shotMinV, shotMaxV, ticks, false, 4, .5f);
                if (timer3 > 2)
                {
                    pauseBeforeNext = true;
                    timer = 0;
                    timer3 = 0;
                }

                timer3++;
            }
            timer++;
        }
        else
        {
            if (timer2 > 20)
            {
                pauseBeforeNext = false;
                timer2 = 0;
            }
            else
            {
                timer2++;
            }
        }
    }

    void Spell2()
    {
        if (Controller.Instance.globalAng == 0)
        {
            Controller.Instance.globalAng = -90;
        }
        if (timer > 30)
        {
            for (int i = 0; i < 1; i++)
            {
                float topSpawn = Random.Range(-12, 3.5f);
                float randVel = Random.Range(.025f, .075f);
                EnemyShot topShot = Instantiate(shotB, new Vector3(topSpawn, 20, 0), Quaternion.identity);
                topShot.setParameters(5, randVel, 0, randVel, randVel, 1, false);
                topShot.tempInc = 1;
                topShot.direction = GlobalFxns.ToVect(Controller.Instance.globalAng);
                topShot.dirAsFloat = Controller.Instance.globalAng;
            }
            for (int i = 0; i < 1; i++)
            {
                float sideSpawnA = Random.Range(10, 19.5f);
                float randVel = Random.Range(.025f, .075f);
                EnemyShot leftShot = Instantiate(shotB, new Vector3(-12, sideSpawnA, 0), Quaternion.identity);
                leftShot.setParameters(5, randVel, 0, randVel, randVel, 1, false);
                leftShot.tempInc = 1;
                leftShot.direction = GlobalFxns.ToVect(Controller.Instance.globalAng);
                leftShot.dirAsFloat = Controller.Instance.globalAng;
            }
            for (int i = 0; i < 1; i++)
            {
                float sideSpawnB = Random.Range(10, 19.5f);
                float randVel = Random.Range(.025f, .075f);
                EnemyShot rightShot = Instantiate(shotB, new Vector3(3.5f, sideSpawnB, 0), Quaternion.identity);
                rightShot.setParameters(5, randVel, 0, randVel, randVel, 1, false);
                rightShot.tempInc = 1;
                rightShot.direction = GlobalFxns.ToVect(Controller.Instance.globalAng);
                rightShot.dirAsFloat = Controller.Instance.globalAng;
            }
            timer2++;
            timer = 0;
        }
        if (timer2 == 5)
        {
            //For timer3: 0 is default (-90), 1 is left (-135), 2 is right (-45).
            int windDir = Random.Range(0, 3);
            timer3 = windDir;
            timer2 = 0;
        }
        if (timer3 == 0)
        {
            Controller.Instance.globalAng = -90;
        }
        else if (timer3 == 1)
        {
            Controller.Instance.globalAng = -45;
        }
        else if (timer3 == 2)
        {
            Controller.Instance.globalAng = -135;
        }
    }

    void Spell3()
    {
        if (timer > 1)
        {
            float topSpawn = Random.Range(-12, 3.5f);
            float randVel = Random.Range(.025f, .075f);
            float randDir = Random.Range(-115f, -65f);
            EnemyShot topShot = Instantiate(rain, new Vector3(topSpawn, 20, 0), Quaternion.identity);
            topShot.transform.localScale *= .75f;
            topShot.setParameters(1, randVel, 0, randVel, randVel, 1, false);
            topShot.direction = GlobalFxns.ToVect(randDir);
            topShot.transform.eulerAngles = new Vector3(0, 0, randDir + 90);
            timer2--;
            timer = 0;
        }
        if (timer2 < 0)
        {
            //lr true: move left. Else, right.
            if (lr) {
                Familiar umbrella = Instantiate(fam, new Vector3(5.75f,10.5f, 0), Quaternion.identity);
                umbrella.leftright = false;
            }
            else
            {
                Familiar umbrella = Instantiate(fam, new Vector3(-14, 10.5f, 0), Quaternion.identity);
                umbrella.leftright = true;
            }
            lr = !lr;
            timer2 = 60;
        }
    }
}
