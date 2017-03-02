using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {
    public Vector3 direction;
    public float velocity, acceleration, minvelocity, maxvelocity, playerX, playerY, amplitude, dirAsFloat, increment;
    public int mvtFxn, timer, timer2, timer3, ticks;
    public bool decelerating, lr;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (!Controller.Instance.paused)
        {
            //move();
            if (mvtFxn == 1)
            {
                linearMove(direction, velocity, acceleration, minvelocity, maxvelocity, ticks);
            }
            if (mvtFxn == 2)
            {
                AimAtPlayer();
                linearMove(direction, velocity, acceleration, minvelocity, maxvelocity, ticks);
            }
            if (mvtFxn == 3)
            {
                sinMove(lr, velocity, acceleration, minvelocity, maxvelocity, ticks, amplitude);
                timer3++;
            }
            if (mvtFxn == 4)
            {
                curveMove(increment);
            }
            timer++;
            SD();
        }
    }

    void move()
    {
        transform.position += new Vector3(0, -.25f, 0);
        if (transform.position.y < 1f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "PlayerHitbox")
        {
            if (!Controller.Instance.invuln)
            {
                Controller.Instance.player.transform.position= new Vector3(-4, 2, 0);
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
            Destroy(this.gameObject);
        }
    }

    void linearMove(Vector3 dir, float vel, float accel, float minvel, float maxvel, int tickrate){
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
        if (transform.position.y < -5f || transform.position.y > 22f || transform.position.x < -18 || transform.position.x > 7f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    public void AimAtPlayer()
    {
        Vector3 direction = new Vector3(playerX- this.transform.position.x, playerY - this.transform.position.y, 0);
        direction = direction.normalized;
    }

    public void setParameters(int fxnNo, float vel, float accel, float minv, float maxv, int tickrate, bool decelYN)
    {
        mvtFxn = fxnNo;
        velocity = vel;
        acceleration = accel;
        minvelocity = minv;
        maxvelocity = maxv;
        ticks = tickrate;
        decelerating = decelYN;
    }

    public void SD()
    {
        if (Controller.Instance.clearScreen || Controller.Instance.bombing)
        {
            Destroy(this.gameObject);
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
        if (timer3 > tickrate)
        {
            if (left)
            {
                transform.position += new Vector3(-1 * vel, Mathf.Sin(timer2) * amp);
                timer2++;
            }
            else
            {
                transform.position += new Vector3(vel, Mathf.Sin(timer2) * amp);
                timer2++;
            }
            timer3 = 0;
        }
        if (transform.position.y < -5f || transform.position.y > 22f || transform.position.x < -18 || transform.position.x > 7f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    void curveMove(float inc)
    {
        dirAsFloat = GlobalFxns.ToAng(direction);
        linearMove(direction, velocity, acceleration, minvelocity,maxvelocity,ticks);
        direction = GlobalFxns.ToVect(dirAsFloat + inc);
    }
}
