using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {
    public int bulletType, counter;
    public Player player;
    public Bullet shot, shot2;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        if (!Controller.Instance.paused)
        {
            if (bulletType == 0)
            {
                move();
            }
            if (bulletType == 1)
            {
                move2();
                counter++;
            }
            Fire1();
        }
    }
    void move()
    {
        transform.position += new Vector3(0, .25f, 0);
        if (transform.position.y > 20f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    void move2()
    {
        Vector3 radius = new Vector3(0, 0, 1);
        transform.RotateAround(player.transform.position, radius, 360 * Time.deltaTime);
    }

    void Fire1()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (bulletType == 1)
            {
                if (counter > 5)
                {
                    Bullet Copy = (Instantiate(shot2, transform.position, Quaternion.identity)) as Bullet;
                    counter = 0;
                }
            }
        }
    }
}
