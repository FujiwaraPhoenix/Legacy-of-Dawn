using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : Enemy {
    public int remainingLives, countdown, spellTimer, currentStg, rotation, timer2, timer3, offset, offset2;
    public EnemyShot coinA, coinB, spirit, water;
    public Rigidbody2D rb;
    public Vector3 movedirection;
    public bool moving, justSpawned;

    // Use this for initialization
    void Start () {
        justSpawned = true;
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
                    timer++;
                    spellChange(2000);
                }
                if (currentStg == 2)
                {
                    Spell1();
                    timer++;
                    spellChange(2000);
                }
                if (currentStg == 3)
                {
                    Nonspell2();
                    timer++;
                    spellChange(2000);
                }
                if (currentStg == 4)
                {
                    Spell2();
                    timer++;
                    timer2++;
                    timer3++;
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
                timer = 0;
                timer2 = 0;
                timer3 = 0;
                returnToPos();
                StartCoroutine(screenWipe());
            }
            else
            {
                StartCoroutine(screenWipe());
                Controller.Instance.bossDead = true;
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

    void Nonspell1()
    {
        if (timer == 60)
        {
            if (timer2 == 0)
            {
                float shotSpd = .05f;
                for (int i = 0; i < 36; i++)
                {
                    EnemyShot coin = Instantiate(coinA, transform.position, Quaternion.identity);
                    coin.direction = GlobalFxns.ToVect(0 + rotation + offset);
                    coin.setParameters(1, shotSpd, 0, shotSpd, shotSpd, 1, false);
                    rotation -= 10;
                    shotSpd += .003f;
                }
                rotation = 0;
                timer2 = 1;
                playSnd(1);
            }
            else if (timer2 == 1)
            {
                float shotSpd = .05f;
                for (int i = 0; i < 36; i++)
                {
                    EnemyShot coin = Instantiate(coinB, transform.position, Quaternion.identity);
                    coin.direction = GlobalFxns.ToVect(180 + rotation + offset);
                    coin.setParameters(1, shotSpd, 0, shotSpd, shotSpd, 1, false);
                    rotation += 10;
                    shotSpd += .003f;
                }
                rotation = 0;
                timer2 = 0;
                playSnd(1);
            }
        }
        if (timer > 90)
        {
            float streamSpd = .05f;
            float tempX = Controller.Instance.player.transform.position.x;
            float tempY = Controller.Instance.player.transform.position.y;
            for (int i = 0; i < 3; i++)
            {
                EnemyShot coin = Instantiate(coinA, transform.position, Quaternion.identity);
                Vector3 rota = (new Vector3(tempX - this.transform.position.x, tempY - this.transform.position.y, 0));
                coin.setParameters(1, streamSpd, 0, streamSpd, streamSpd, 1, false);
                float angle = GlobalFxns.ToAng(rota);
                Vector3 dir = rota;
                coin.direction = dir.normalized;
                streamSpd += .005f;
            }
            timer = 0;
        }
    }

    void Nonspell2()
    {
        if (timer == 60)
        {
            if (timer2 == 0)
            {
                float shotSpd = .05f;
                for (int i = 0; i < 54; i++)
                {
                    EnemyShot coin = Instantiate(coinA, transform.position, Quaternion.identity);
                    coin.direction = GlobalFxns.ToVect(0 + rotation + offset);
                    coin.setParameters(1, shotSpd, 0, shotSpd, shotSpd, 1, false);
                    rotation -= 10;
                    shotSpd += .003f;
                }
                rotation = 0;
                timer2 = 1;
                timer3++;
            }
            else if (timer2 == 1)
            {
                float shotSpd = .05f;
                for (int i = 0; i < 54; i++)
                {
                    EnemyShot coin = Instantiate(coinB, transform.position, Quaternion.identity);
                    coin.direction = GlobalFxns.ToVect(180 + rotation + offset);
                    coin.setParameters(1, shotSpd, 0, shotSpd, shotSpd, 1, false);
                    rotation += 10;
                    shotSpd += .003f;
                }
                rotation = 0;
                timer2 = 0;
                timer3++;
            }
            playSnd(1);
        }
        if (timer > 90)
        {
            if (timer3 > 3)
            {
                float streamSpd = .05f;
                float tempX = Controller.Instance.player.transform.position.x;
                float tempY = Controller.Instance.player.transform.position.y;
                for (int i = 0; i < 3; i++)
                {
                    Vector3 rota = (new Vector3(tempX - this.transform.position.x, tempY - this.transform.position.y, 0));
                    float angle = GlobalFxns.ToAng(rota);
                    makeCircle(20, coinA, angle, streamSpd, 0, streamSpd, streamSpd, 1, false);
                    streamSpd += .005f;
                }
                timer3 = 0;
            }
            timer = 0;
        }
    }

    void Spell1()
    {
        if (timer == 30)
        {
            makeCircle(24, coinA, offset, .075f, 0, .075f, .075f, 1, false);
            makeCircle(24, coinB, offset2, .075f, 0, .075f, .075f, 1, false);
            offset += 12;
            offset2 -= 12;
            timer = 0;
            timer2++;
            playSnd(1);
        }
        if (timer2 == 2)
        {
            float tempX = Controller.Instance.player.transform.position.x;
            float tempY = Controller.Instance.player.transform.position.y;
            Vector3 rota = (new Vector3(tempX - this.transform.position.x, tempY - this.transform.position.y, 0));
            float angle = GlobalFxns.ToAng(rota);
            EnemyShot targeted = Instantiate(spirit, transform.position, Quaternion.identity);
            targeted.setParameters(1, .05f, 0, .05f, .05f, 1, false);
            targeted.transform.eulerAngles = new Vector3(0, 0, angle + 90);
            Vector3 dir = rota;
            targeted.direction = dir.normalized;
            timer2 = 0;
        }
    }

     void Spell2()
    {
        if (timer > 15)
        {
            Vector3 rtSpawn1 = new Vector3(-12, 2.25f, 0);
            Vector3 lfSpawn1 = new Vector3(3.5f, 1.25f, 0);
            Vector3 rtSpawn2 = new Vector3(-12, .25f, 0);
            Vector3 lfSpawn2 = new Vector3(3.5f, -.25f, 0);
            EnemyShot river = Instantiate(water, rtSpawn1, Quaternion.identity);
            river.setParameters(3, .4f, 0, .25f, .25f, 2, false);
            river.amplitude = .5f;
            river.lr = false;
            EnemyShot river2 = Instantiate(water, lfSpawn1, Quaternion.identity);
            river2.setParameters(3, .4f, 0, .25f, .25f, 2, false);
            river2.amplitude = .5f;
            river2.lr = true;
            EnemyShot river3 = Instantiate(water, rtSpawn2, Quaternion.identity);
            river3.setParameters(3, .5f, 0, .25f, .25f, 2, false);
            river3.amplitude = .5f;
            river3.lr = false;
            EnemyShot river4 = Instantiate(water, lfSpawn2, Quaternion.identity);
            river4.setParameters(3, .5f, 0, .25f, .25f, 2, false);
            river4.amplitude = .5f;
            river4.lr = true;
            timer = 0;
        }
        if (timer2 > 20)
        {
            float xPos = Random.Range(-11, 2.5f);
            Vector3 location = new Vector3(xPos, -.5f, 0);
            EnemyShot ghostie = Instantiate(spirit, location, Quaternion.identity);
            ghostie.setParameters(1, .05f, 0, .25f, 25f, 1, false);
            ghostie.direction = new Vector3(0, 1, 0);
            ghostie.transform.eulerAngles = new Vector3(0, 0, 180);
            timer2 = 0;
            playSnd(2);
        }
        if (timer3 > 30)
        {
            makeCircle(5, coinB, offset, .05f, 0, .05f, .05f, 1, false);
            offset += 5;
            timer3 = 0;
            playSnd(1);
        }
    }

    void makeCircle(int number, EnemyShot type, float offset, float vel, float accel, float minv, float maxv, int tickrate, bool decelYN)
    {
        float betAng = 360 / number;
        //Creates number of bullets
        for (int i = 0; i < number + 1; i++)
        {
            EnemyShot circBullet = Instantiate(type, transform.position, Quaternion.identity) as EnemyShot;
            circBullet.mvtFxn = 1;
            circBullet.velocity = vel;
            circBullet.acceleration = accel;
            circBullet.minvelocity = minv;
            circBullet.maxvelocity = maxv;
            circBullet.ticks = tickrate;
            circBullet.direction = GlobalFxns.ToVect(betAng * i + offset);
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

    void playSnd(int type)
    {
        if (type == 1)
        {
            Sound.me.PlaySound(pewpew, 2, 0, 20);
        }
        else if (type == 2)
        {
            Sound.me.PlaySound(kirakira, 2, 20, 25);
        }
        else
        {
            Sound.me.PlaySound(hit, .05f, 25, 34);
        }
    }
}
