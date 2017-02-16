using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp, timer, timerA;
    public bool upY;
    public BoxCollider2D hitbox;
    public Item power, point, bigPower;
    public Vector3 direction;
    public EnemyShot bullet, bulletGroupA;
    public float velocity, acceleration, minvelocity, maxvelocity, playerX, playerY, deltaAngle;
    public float shotVel, shotAccel, shotMinV, shotMaxV;
    public int mvtFxn, shotTimer, ticks, itemDrop, moveTimer, shotType, shotDelay, noForCirc, offsetVal, shotTicks, offsetInc, ptInRotation;
    public bool decelerating, shotDecel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
            makeCircle(noForCirc, offsetVal, shotVel, shotAccel, shotMinV, shotMaxV, shotTicks, shotDecel);
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
        if (hp < 1)
        {
            createItem();
            Destroy(this.gameObject);
        }
        shotTimer++;
        SD();
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
        transform.position += (dir * velocity);
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
            float tempX = Controller.Instance.player.transform.position.x;
            float tempY = Controller.Instance.player.transform.position.y;
            Vector3 rota = (new Vector3(tempX - this.transform.position.x, tempY - this.transform.position.y, 0));
            EnemyShot aimed = Instantiate(bullet, transform.position, Quaternion.identity);
            bullet.mvtFxn = 2;
            shotTimer = 0;
            aimed.playerX = tempX;
            aimed.playerY = tempY;
            Vector3 dir = rota;
            aimed.direction = dir.normalized;
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
        }
    }

    void makeCircle(int number, float offset, float vel, float accel, float minv, float maxv, int tickrate, bool decelYN)
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
            }
            shotTimer = 0;
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
                    makeCircle(8, offsetVal, .05f, 0, .05f, .05f, 1, false);
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
            }
        }
        else if (ptInRotation == 2)
        {
            if (shotTimer > 45)
            {
                if (timerA < 3)
                {
                    makeCircle(8, offsetVal, .05f, 0, .05f, .05f, 1, false);
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
}
