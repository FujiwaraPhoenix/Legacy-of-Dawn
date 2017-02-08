using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {
    public Controller cont;
    public Vector3 direction;
    public float velocity, acceleration, minvelocity, maxvelocity;
    public int mvtFxn, timer, ticks;
    public bool decelerating;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //move();
        if (mvtFxn == 1)
        {
            linearMove(direction, velocity, acceleration, minvelocity, maxvelocity, ticks);
        }
        timer++;
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
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.transform.position = new Vector3(-6, 2, 0);
            cont.lives--;
            cont.bombs = 3;
            if (cont.power < 2f)
            {
                cont.power = 1f;
            }
            else if (cont.power >= 2f)
            {
                cont.power -= 1f;
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
        if (transform.position.y < 1f || transform.position.y > 20f || transform.position.x < -13 || transform.position.x > 1)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
