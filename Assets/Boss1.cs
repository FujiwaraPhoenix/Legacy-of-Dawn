using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Enemy {
    public int remainingLives, countdown, spellTimer, currentStg, rotation, timer2, timer3, offset;
    public EnemyShot bulletA, phoenix, bulletB;
    public Rigidbody2D rb;
    public Vector3 movedirection;
    public bool moving, justSpawned, chrgAnim;
    public Animator anim;
    public AudioClip shoot1, charging;

	// Use this for initialization
	void Start () {
        justSpawned = true;
        anim = GetComponent<Animator>();
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
                    randomMove();
                    timer++;
                    timer2++;
                    spellChange(1500);
                }
                if (currentStg == 2)
                {
                    Spell1();
                    timer++;
                    spellChange(1500);
                }
                if (currentStg == 3)
                {
                    Nonspell2();
                    randomMove();
                    timer++;
                    timer2++;
                    spellChange(1500);
                }
                if (currentStg == 4)
                {
                    Spell2();
                    timer++;
                    timer2++;
                    spellChange(1500);
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

    //Nonspell 1
    void Nonspell1()
    {
        if (currentStg == 1)
        {
            if (timer > 15) {
                playSnd(1);
                EnemyShot a = (Instantiate(bulletA, transform.position, Quaternion.Euler(GlobalFxns.ToVect(0 + rotation))) as EnemyShot);
                EnemyShot b = (Instantiate(bulletA, transform.position, Quaternion.Euler(GlobalFxns.ToVect(120 + rotation))) as EnemyShot);
                EnemyShot c = (Instantiate(bulletA, transform.position, Quaternion.Euler(GlobalFxns.ToVect(240 + rotation))) as EnemyShot);
                a.direction = (GlobalFxns.ToVect(0 + rotation));
                b.direction = (GlobalFxns.ToVect(120 + rotation));
                c.direction = (GlobalFxns.ToVect(240 + rotation));
                a.transform.eulerAngles = new Vector3(0, 0, GlobalFxns.ToAng(a.direction) + 90);
                b.transform.eulerAngles = new Vector3(0, 0, GlobalFxns.ToAng(b.direction) + 90);
                c.transform.eulerAngles = new Vector3(0, 0, GlobalFxns.ToAng(c.direction) + 90);
                a.setParameters(1, .05f, 0, .05f, .05f, 1, false);
                b.setParameters(1, .05f, 0, .05f, .05f, 1, false);
                c.setParameters(1, .05f, 0, .05f, .05f, 1, false);
                rotation += 10;
                timer = 0;
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
                if (transform.position.x > -12 && transform.position.x < 0 && transform.position.y > 15 && transform.position.y < 18)
                {
                    transform.position += movedirection * velocity;
                }
                else
                {
                    if ((movedirection.x > 0 && transform.position.x > 0)||(movedirection.x < 0 && transform.position.x < -12)) {
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

    void Spell1()
    {
        if (timer > 100 && !chrgAnim)
        {
            anim.Play("Mokou");
            playSnd(3);
            chrgAnim = !chrgAnim;
        }
        if (timer > 120)
        {
            float tempX = Controller.Instance.player.transform.position.x;
            float tempY = Controller.Instance.player.transform.position.y;
            Vector3 rota = (new Vector3(tempX - this.transform.position.x, tempY - this.transform.position.y, 0));
            float angle = GlobalFxns.ToAng(rota);
            EnemyShot ph = Instantiate(phoenix, transform.position, Quaternion.identity) as EnemyShot;
            ph.mvtFxn = 2;
            ph.velocity = .05f;
            ph.minvelocity = .05f;
            ph.maxvelocity = .05f;
            ph.ticks = 20;
            ph.playerX = tempX;
            ph.playerY = tempY;
            ph.transform.eulerAngles = new Vector3(0, 0, angle + 90);
            Vector3 dir = rota;
            ph.direction = dir.normalized;
            timer = 0;
            makeCircle(10, offset, .05f, 0, .05f, .05f, 20, false, 1);
            offset += 5;
            playSnd(1);
            chrgAnim = !chrgAnim;
        }
    }

    new void makeCircle(int number, float offset, float vel, float accel, float minv, float maxv, int tickrate, bool decelYN, int sndVer)
    {
        float betAng = 360 / number;
        //Creates number of bullets
        for (int i = 0; i < number + 1; i++)
        {
            EnemyShot circBullet = Instantiate(bulletA, transform.position, Quaternion.identity) as EnemyShot;
            circBullet.mvtFxn = 2;
            circBullet.velocity = vel;
            circBullet.acceleration = accel;
            circBullet.minvelocity = minv;
            circBullet.maxvelocity = maxv;
            circBullet.ticks = tickrate;
            circBullet.direction = GlobalFxns.ToVect(betAng * i + offset);
            circBullet.transform.eulerAngles = new Vector3(0, 0, betAng * i + offset + 90);
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

    void Nonspell2()
    {
        if (timer > 60)
        {
            makeCircle(36, offset, .05f, 0, 0, 0, 20, false, 1);
            timer = 0;
            offset += 5;
            playSnd(1);
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
        Controller.Instance.bossMaxHP = newHP;
        Controller.Instance.bossHP = this.hp;
    }

    void Spell2()
    {
        if (timer > 100 && !chrgAnim)
        {
            anim.Play("Mokou");
            chrgAnim = !chrgAnim;
            playSnd(3);
        }
        if (timer > 120)
        {
            for (int i = 0; i < 5 + 1; i++)
            {
                float tempX = Controller.Instance.player.transform.position.x;
                float tempY = Controller.Instance.player.transform.position.y;
                Vector3 start = new Vector3(-4 + .8f * i, 16.5f + .4f * i, 0);
                EnemyShot stream = Instantiate(bulletA, start, Quaternion.identity) as EnemyShot;
                Vector3 rota = (new Vector3(tempX - stream.transform.position.x, tempY - stream.transform.position.y, 0));
                //float angle = GlobalFxns.ToAng(rota);
                Vector3 dir = rota;
                stream.direction = dir.normalized;
                stream.setParameters(1, .05f, 0, .05f, .05f, 1, false);
            }
            for (int i = 0; i < 4 + 1; i++)
            {
                float tempX = Controller.Instance.player.transform.position.x;
                float tempY = Controller.Instance.player.transform.position.y;
                Vector3 start = new Vector3(-4.5f - .8f * i, 16.9f + .4f * i, 0);
                EnemyShot stream = Instantiate(bulletA, start, Quaternion.identity) as EnemyShot;
                Vector3 rota = (new Vector3(tempX - stream.transform.position.x, tempY - stream.transform.position.y, 0));
                //float angle = GlobalFxns.ToAng(rota);
                Vector3 dir = rota;
                stream.direction = dir.normalized;
                stream.setParameters(1, .05f, 0, .05f, .05f, 1, false);
            }
            timer = 0;
            chrgAnim = !chrgAnim;
            playSnd(4);
        }
        if (timer2 > 15)
        {
            float random = Random.Range(-11f, 3f);
            Vector3 startLoc = new Vector3 (random, 19, 0);
            EnemyShot rain = Instantiate(bulletB, startLoc, Quaternion.identity);
            rain.setParameters(1, .2f, -.0001f, .01f, 0, 1, false);
            rain.direction = new Vector3(0, -.1f, 0);
            timer2 = 0;
            playSnd(2);
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

    void playSnd(int type)
    {
        if (type == 1)
        {
            Sound.me.PlaySound(pewpew, 2, 0, 20);
        }
        else if (type == 2)
        {
            Sound.me.PlaySound(shoot1, 2, 20, 25);
        }
        else if (type == 3)
        {
            Sound.me.PlaySound(charging, 2, 20, 25);
        }
        else
        {
            Sound.me.PlaySound(hit, .05f, 25, 34);
        }
    }
}
