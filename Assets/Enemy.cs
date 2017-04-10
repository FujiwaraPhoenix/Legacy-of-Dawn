using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp, timer, timerA, timerB, timerC;
    public bool upY, indirect;
    public BoxCollider2D hitbox;
    public CircleCollider2D altHitbox;
    public Item power, point, bigPower, bomb, life;
    public Vector3 direction;
    public EnemyShot bullet, bullet2, bulletGroupA;
    public float velocity, acceleration, minvelocity, maxvelocity, playerX, playerY, deltaAngle, amplitude, mvtScale;
    public float shotVel, shotAccel, shotMinV, shotMaxV, variance;
    public int mvtFxn, shotTimer, ticks, itemDrop, moveTimer, shotType, shotDelay, noForCirc, offsetVal, shotTicks, offsetInc, ptInRotation;
    public bool decelerating, shotDecel, lr;
    public AudioClip pewpew, hit, kirakira;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Controller.Instance.paused)
        {
            if (mvtFxn == 1)
            {
                linearMove(direction, shotVel, shotAccel, shotMinV, shotMaxV, shotTicks);
            }
            if (mvtFxn == 2)
            {
                curveMove(deltaAngle);
                moveTimer--;
            }
            if (mvtFxn == 3)
            {
                sinMove(lr, velocity, acceleration, minvelocity, maxvelocity, ticks, amplitude);
                timerC++;
            }
            if (shotType == 1)
            {
                AimShot();
            }
            if (shotType == 2)
            {
                AimShotgun();
            }
            if (shotType == 3)
            {
                makeCircle(noForCirc, offsetVal, shotVel, shotAccel, shotMinV, shotMaxV, shotTicks, shotDecel, 1);
                offsetVal += offsetInc;
            }
            if (shotType == 4)
            {
                midboss1();
            }
            if (shotType == 5)
            {
                shootDown();
            }
            if (shotType == 7)
            {
                if (shotTimer > shotDelay)
                {
                    if (timerA < 3)
                    {
                        makeCircle(noForCirc, offsetVal, shotVel, shotAccel, shotMinV, shotMaxV, shotTicks, shotDecel, 1);
                        offsetVal += offsetInc;
                        timerA++;
                    }
                    else
                    {
                        velocity -= .2f;
                        makeCircle(noForCirc, offsetVal, shotVel, shotAccel, shotMinV, shotMaxV, shotTicks, shotDecel, 1);
                        offsetVal += offsetInc;
                        shotTimer = shotDelay + 1;
                        velocity += .2f;
                        AimShotgun();
                        timerA = 0;
                    }
                }
            }
            if (shotType == 8)
            {
                midboss2();
            }
            if (shotType == 9)
            {
                somethingVariance();
            }
            if (shotType == 10)
            {
                specialCirc();
                offsetVal += offsetInc;
            }
            if (hp < 1)
            {
                createItem();
                if (shotType == 6)
                {
                    suicideFire();
                }
                Destroy(this.gameObject);
            }
            shotTimer++;
            SD();
        }
    }

    void setHP(int val)
    {
        hp = val;
    }

    public void SD()
    {
        if (Controller.Instance.clearScreen)
        {
            Destroy(this.gameObject);
        }
        if (Controller.Instance.bombing)
        {
            hp -= 5;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "shot")
        {
            playSnd(0);
            Destroy(coll.gameObject);
            hp = hp - Controller.Instance.dmg;
        }
        if (coll.gameObject.tag == "PlayerHitbox")
        {
            if (!Controller.Instance.invuln)
            {
                Controller.Instance.player.transform.position = new Vector3(-4, 2, 0);
                Controller.Instance.lives--;
                Controller.Instance.bombs = 3;
                if (Controller.Instance.power < 2f)
                {
                    Controller.Instance.power = 1f;
                }
                else if (Controller.Instance.power >= 2f)
                {
                    Controller.Instance.power -= 1f;
                }
                Sound.me.PlaySound(Sound.me.pichuun, 1, 48, 49);
                Controller.Instance.invuln = true;
            }
        }

    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "invulnShot")
        {
            if (Controller.Instance.laserActive)
            {
                hp = hp - Controller.Instance.dmg2;
            }
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

    public void setParameters(int fxnNo, float vel, float accel, float minv, float maxv, int tickrate, bool decelYN, int newHP)
    {
        mvtFxn = fxnNo;
        velocity = vel;
        acceleration = accel;
        minvelocity = minv;
        maxvelocity = maxv;
        ticks = tickrate;
        decelerating = decelYN;
        hp = newHP;
    }

    public void setShotParameters(int fxnNo, float vel, float accel, float minv, float maxv, int tickrate, bool decelYN)
    {
        shotType = fxnNo;
        shotVel = vel;
        shotAccel = accel;
        shotMinV = minv;
        shotMaxV = maxv;
        shotTicks = tickrate;
        shotDecel = decelYN;
    }

    void linearMove(Vector3 dir, float vel, float accel, float minvel, float maxvel, int tickrate)
    {
        if (timer > tickrate)
        {
            timer = 0;
            if (decelerating)
            {
                if (vel > minvel)
                {
                    if (vel + accel < minvel)
                    {
                        velocity = minvel;
                    }
                    else
                    {
                        velocity += accel;
                    }
                }
            }
            else
            {
                if (vel < maxvel)
                {
                    if (vel + accel > maxvel)
                    {
                        velocity = maxvel;
                    }
                    else
                    {
                        velocity += accel;
                    }
                }
            }
        }
        transform.position += (dir * velocity * Time.deltaTime * 60);
        if (transform.position.y < -5f || transform.position.y > 22f || transform.position.x < -13 || transform.position.x > 5f)
        {
            Object.Destroy(this.gameObject);
        }
    }
    void createItem()
    {
        if (itemDrop == 1)
        {
            Instantiate(point, transform.position, Quaternion.identity);
        }
        if (itemDrop == 2)
        {
            Instantiate(power, transform.position, Quaternion.identity);
        }
        if (itemDrop == 3)
        {
            Instantiate(bigPower, transform.position, Quaternion.identity);
        }
        if (itemDrop == 4)
        {
            Instantiate(life, transform.position, Quaternion.identity);
        }
        if (itemDrop == 5)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
        }
    }

    void curveMove(float angleInc)
    {
        if (moveTimer > 0)
        {
            float currentAng = GlobalFxns.ToAng(direction);
            linearMove(direction, velocity, acceleration, minvelocity, maxvelocity, ticks);
            direction = GlobalFxns.ToVect(currentAng + angleInc);
        }
        else
        {
            mvtFxn = 1;
        }
    }

    void AimShot()
    {
        if (shotTimer > shotDelay)
        {
            float deviation = Random.Range(-variance, variance);
            float tempX = Controller.Instance.player.transform.position.x;
            float tempY = Controller.Instance.player.transform.position.y;
            Vector3 rota = (new Vector3(tempX - this.transform.position.x, tempY - this.transform.position.y, 0));
            EnemyShot aimed = Instantiate(bullet, transform.position, Quaternion.identity);
            bullet.mvtFxn = 2;
            shotTimer = 0;
            aimed.playerX = tempX;
            aimed.playerY = tempY;
            Vector3 dir = rota;
            if (indirect)
            {
                float ang = GlobalFxns.ToAng(dir.normalized);
                aimed.direction = GlobalFxns.ToVect(ang + deviation);
            }
            else
            {
                aimed.direction = dir.normalized;
            }
            playSnd(1);
        }
    }

    void AimShotgun()
    {
        if (shotTimer > shotDelay)
        {
            float tempX = Controller.Instance.player.transform.position.x;
            float tempY = Controller.Instance.player.transform.position.y;
            Vector3 rota = (new Vector3(tempX - this.transform.position.x, tempY - this.transform.position.y, 0));
            float angle = GlobalFxns.ToAng(rota);
            EnemyShot aimed1 = Instantiate(bulletGroupA, transform.position, Quaternion.identity);
            aimed1.mvtFxn = 2;
            shotTimer = 0;
            aimed1.playerX = tempX;
            aimed1.playerY = tempY;
            Vector3 dir = rota;
            aimed1.direction = dir.normalized;
            aimed1.transform.eulerAngles = new Vector3(0, 0, angle + 90);
            playSnd(1);
        }
    }

    public void makeCircle(int number, float offset, float vel, float accel, float minv, float maxv, int tickrate, bool decelYN, int sndVer)
    {
        float betAng = 360 / number;
        //Creates number of bullets
        if (shotTimer > shotDelay)
        {
            for (int i = 0; i < number + 1; i++)
            {
                EnemyShot circBullet = Instantiate(bullet, transform.position, Quaternion.identity) as EnemyShot;
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
                circBullet.transform.eulerAngles = new Vector3(0, 0, betAng * i + offset + 90);
            }
            shotTimer = 0;
            if (sndVer == 1)
            {
                playSnd(1);
            }
            if (sndVer == 2)
            {
                playSnd(2);
            }
        }
    }

    void midboss1()
    {
        if (ptInRotation == 1)
        {
            if (shotTimer > 45)
            {
                if (timerA < 3)
                {
                    makeCircle(8, offsetVal, .05f, 0, .05f, .05f, 1, false, 1);
                    timerA++;
                    offsetVal += offsetInc;
                    shotTimer = 0;
                }
                else
                {
                    offsetVal = 0;
                    timerA = 0;
                    ptInRotation++;
                }
                playSnd(1);
            }
        }
        else if (ptInRotation == 2)
        {
            if (shotTimer > 45)
            {
                if (timerA < 3)
                {
                    makeCircle(8, offsetVal, .05f, 0, .05f, .05f, 1, false, 1);
                    timerA++;
                    offsetVal -= offsetInc;
                    shotTimer = 0;
                }
                else
                {
                    offsetVal = 0;
                    timerA = 0;
                    ptInRotation++;
                }
                playSnd(1);
            }
        }
        else if (ptInRotation == 3)
        {
            if (shotTimer > 30)
            {
                if (timerA < 5)
                {
                    AimShot();
                    timerA++;
                }
                else
                {
                    timerA = 0;
                    ptInRotation = 1;
                }
                playSnd(1);
            }
        }
    }

    void shootDown()
    {
        if (shotTimer > shotDelay)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            bullet.direction = new Vector3(0, -1, 0);
            bullet.mvtFxn = 1;
            shotTimer = 0;
        }
    }

    void sinMove(bool left, float vel, float accel, float minvel, float maxvel, int tickrate, float amp)
    {
        if (timer > tickrate)
        {
            timer = 0;
            if (decelerating)
            {
                if (vel > minvel)
                {
                    if (vel + accel < minvel)
                    {
                        velocity = minvel;
                    }
                    else
                    {
                        velocity += accel;
                    }
                }
            }
            else
            {
                if (vel < maxvel)
                {
                    if (vel + accel > maxvel)
                    {
                        velocity = maxvel;
                    }
                    else
                    {
                        velocity += accel;
                    }
                }
            }
        }
        if (timerC > tickrate)
        {
            if (left)
            {
                transform.position += new Vector3(-1 * vel, Mathf.Sin(timerB * mvtScale) * amp);
                timerB++;
            }
            else
            {
                transform.position += new Vector3(vel, Mathf.Sin(timerB * mvtScale) * amp);
                timerB++;
            }
            timerC = 0;
        }
        if (transform.position.y < -5f || transform.position.y > 22f || transform.position.x < -18 || transform.position.x > 7f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    void suicideFire()
    {
        float tempX = Controller.Instance.player.transform.position.x;
        float tempY = Controller.Instance.player.transform.position.y;
        Vector3 rota = (new Vector3(tempX - this.transform.position.x, tempY - this.transform.position.y, 0));
        float angle = GlobalFxns.ToAng(rota);
        float spdUp = .05f;
        for (int i = 0; i < 5; i++){
            makeCircle(5, angle, spdUp, 0, spdUp, spdUp, 1, false, 0);
            spdUp += .03f;
            shotTimer++;
        }
        playSnd(1);
    }

    void midboss2()
    {
        float tempVel = velocity;
        if (shotTimer > 30)
        {
            for (int i = 0; i < 7; i++)
            {
                EnemyShot thing = Instantiate (bullet, transform.position,Quaternion.identity);
                thing.setParameters(1, tempVel, 0, tempVel, tempVel, 1, false);
                EnemyShot thing2 = Instantiate(bullet, transform.position, Quaternion.identity);
                thing2.setParameters(1, tempVel, 0, tempVel, tempVel, 1, false);
                thing.direction = GlobalFxns.ToVect(-90 + offsetVal);
                thing2.direction = GlobalFxns.ToVect(-90 + -offsetVal);
                tempVel += .025f;
                
            }
            offsetVal += offsetInc;
            shotTimer = 0;
            timerA++;
            playSnd(1);
        }
        if (timerA > 2)
        {
            float tempX = Controller.Instance.player.transform.position.x;
            float tempY = Controller.Instance.player.transform.position.y;
            Vector3 rota = (new Vector3(tempX - this.transform.position.x, tempY - this.transform.position.y, 0));
            float angle = GlobalFxns.ToAng(rota);
            float tempVel2 = .05f;
            for (int i = 0; i < 3; i++)
            {
                EnemyShot aimed = Instantiate(bullet, transform.position, Quaternion.identity);
                aimed.playerX = tempX;
                aimed.playerY = tempY;
                Vector3 dir = rota;
                aimed.direction = dir.normalized;
                aimed.setParameters(2, tempVel2, 0, tempVel2, tempVel2, 1, false);
                tempVel2 += .025f;
            }
            timerA = 0;
            playSnd(1);
        }
    }

    void somethingVariance()
    {
        makeCircle(5, deltaAngle, .05f, 0, .05f, .05f, 1, false, 2);
        deltaAngle += Mathf.Sin(timerA) * 6 + 10;
        timerA++;
    }

    void specialCirc()
    {
        if (shotTimer > shotDelay)
        {
            if (timerA < (180 / offsetInc))
            {
                EnemyShot circBullet1 = Instantiate(bullet2, transform.position, Quaternion.identity) as EnemyShot;
                circBullet1.mvtFxn = 6;
                circBullet1.velocity = shotVel;
                circBullet1.acceleration = shotAccel;
                circBullet1.minvelocity = shotMinV;
                circBullet1.maxvelocity = shotMaxV;
                circBullet1.ticks = shotTicks;
                circBullet1.direction = GlobalFxns.ToVect(0 + offsetVal);
                circBullet1.transform.eulerAngles = new Vector3(0, 0, offsetVal - 90);
                circBullet1.transform.localScale += new Vector3(0, 20, 0);
                circBullet1.delay = 60;

                EnemyShot circBullet2 = Instantiate(bullet2, transform.position, Quaternion.identity) as EnemyShot;
                circBullet2.mvtFxn = 6;
                circBullet2.velocity = shotVel;
                circBullet2.acceleration = shotAccel;
                circBullet2.minvelocity = shotMinV;
                circBullet2.maxvelocity = shotMaxV;
                circBullet2.ticks = shotTicks;
                circBullet2.direction = GlobalFxns.ToVect(180 + offsetVal);
                circBullet2.transform.eulerAngles = new Vector3(0, 0, offsetVal + 90);
                circBullet2.transform.localScale += new Vector3(0, 20, 0);
                circBullet2.delay = 60;

                shotTimer = 0;
                timerA++;
                playSnd(1);
            }
        }
    }

    void playSnd(int type)
    {
        if (type == 1)
        {
            Sound.me.PlaySound(pewpew, .05f, 0, 20);
        }
        else if (type == 2)
        {
            Sound.me.PlaySound(kirakira, .05f, 20, 25);
        }
        else
        {
            Sound.me.PlaySound(hit, .05f, 25, 34);
        }
    }
}
