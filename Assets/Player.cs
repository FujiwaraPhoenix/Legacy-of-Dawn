using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Bullet shot, shot2;
    public Controller cont;
    public Orbiter a, b;
    public LaserShot c;

    public SpriteRenderer spriteRenderer;
    public Sprite focus;
    public Sprite unfocus;
    public int charX;
    public int charY;
    public int counter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        Fire();
        counter++;
	}


    void Movement()
    {
        if (Input.GetKey(KeyCode.LeftShift)){
            spriteRenderer.sprite = focus;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (transform.position.y + .0625f < 19 - (charY / 2)) {
                    transform.position += new Vector3(0, .0625f, 0);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, 19 - (charY / 2), 0);
                }
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (transform.position.y - .0625f > 1 + (charY / 2))
                {
                    transform.position += new Vector3(0, -.0625f, 0);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, 1 + (charY / 2), 0);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (transform.position.x - .0625f > -12 - (charX / 2))
                    {
                        transform.position += new Vector3(-.0625f, 0, 0);
                    }
                else
                {
                    transform.position = new Vector3(-12 + (charX / 2), transform.position.y, 0);
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (transform.position.x + .0625f < (charX / 2))
                {
                    transform.position += new Vector3(.0625f, 0, 0);
                }
                else
                {
                    transform.position = new Vector3(charX / 2, transform.position.y, 0);
                }
            }
        }
        else
        {
            spriteRenderer.sprite = unfocus;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (transform.position.y + .125f < 19 - (charY / 2))
                {
                    transform.position += new Vector3(0, .125f, 0);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, 19 - (charY / 2), 0);
                }
                }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (transform.position.y - .125f > 1 + (charY / 2))
                {
                    transform.position += new Vector3(0, -0.125f, 0);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, 1 + (charY / 2), 0);
                }
                }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (transform.position.x - .125f > -12 - (charX / 2))
                {
                    transform.position += new Vector3(-0.125f, 0, 0);
                }
                else
                {
                    transform.position = new Vector3(-12 + (charX / 2), transform.position.y, 0);
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (transform.position.x + .125f < (charX / 2))
                {
                    transform.position += new Vector3(0.125f, 0, 0);
                }
                else
                {
                    transform.position = new Vector3(charX / 2, transform.position.y, 0);
                }
            }
        }
    }

    void Fire()
    {
        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift))
        {
            if (cont.power < 2f)
            {
                counter = 0;
                a.on = false;
                b.on = false;
                c.on = true;
                if (cont.laserProcTimer > 10)
                {
                    cont.dmg2 = 1;
                    cont.laserProcTimer = 0;
                }
                else
                {
                    cont.dmg2 = 0;
                    cont.laserProcTimer++;
                }
            }
            else if (cont.power < 3f)
            {
                counter = 0;
                a.on = false;
                b.on = false;
                c.on = true;
                if (cont.laserProcTimer > 10)
                {
                    cont.dmg2 = 2;
                    cont.laserProcTimer = 0;
                }
                else
                {
                    cont.dmg2 = 0;
                    cont.laserProcTimer++;
                }
            }
            else if (cont.power < 4f)
            {
                
                counter = 0;
                a.on = false;
                b.on = false;
                c.on = true;
                if (cont.laserProcTimer > 10)
                {
                    cont.dmg2 = 3;
                    cont.laserProcTimer = 0;
                }
                else
                {
                    cont.dmg2 = 0;
                    cont.laserProcTimer++;
                }
            }
            else if (cont.power < 5f)
            {
                
                counter = 0;
                a.on = false;
                b.on = false;
                c.on = true;
                if (cont.laserProcTimer > 10)
                {
                    cont.dmg2 = 4;
                    cont.laserProcTimer = 0;
                }
                else
                {
                    cont.dmg2 = 0;
                    cont.laserProcTimer++;
                }
            }
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            if (counter > 5)
            {
                if (cont.power < 2f)
                {
                    Vector3 offset1 = new Vector3(.25f, 0, 0);
                    Vector3 offset2 = new Vector3(-.25f, 0, 0);
                    Bullet Copy = (Instantiate(shot, transform.position + offset1, transform.rotation)) as Bullet;
                    Bullet Copy2 = (Instantiate(shot, transform.position + offset2, transform.rotation)) as Bullet;
                    counter = 0;
                    a.on = false;
                    b.on = false;
                }
                else if (cont.power < 3f)
                {
                    Vector3 offset1 = new Vector3(.25f, 0, 0);
                    Vector3 offset2 = new Vector3(-.25f, 0, 0);
                    Vector3 offset3 = new Vector3(0, .25f, 0);
                    Vector3 offset4 = new Vector3(-.5f, 0, 0);
                    Vector3 offset5 = new Vector3(.5f, 0, 0);
                    Bullet Copy = (Instantiate(shot, transform.position + offset1, transform.rotation)) as Bullet;
                    Bullet Copy2 = (Instantiate(shot, transform.position + offset2, transform.rotation)) as Bullet;
                    Bullet Copy3 = (Instantiate(shot, transform.position + offset3, transform.rotation)) as Bullet;
                    Bullet Copy4 = (Instantiate(shot2, transform.position + offset4, transform.rotation)) as Bullet;
                    Bullet Copy5 = (Instantiate(shot2, transform.position + offset5, transform.rotation)) as Bullet;
                    counter = 0;
                    a.on = false;
                    b.on = false;
                }
                else if (cont.power < 4f)
                {
                    Vector3 offset1 = new Vector3(.25f, 0, 0);
                    Vector3 offset2 = new Vector3(-.25f, 0, 0);
                    Vector3 offset3 = new Vector3(0, .25f, 0);
                    Vector3 offset4 = new Vector3(-.5f, 0, 0);
                    Vector3 offset5 = new Vector3(.5f, 0, 0);
                    Bullet Copy = (Instantiate(shot, transform.position + offset1, transform.rotation)) as Bullet;
                    Bullet Copy2 = (Instantiate(shot, transform.position + offset2, transform.rotation)) as Bullet;
                    Bullet Copy3 = (Instantiate(shot, transform.position + offset3, transform.rotation)) as Bullet;
                    Bullet Copy4 = (Instantiate(shot2, transform.position + offset4, transform.rotation)) as Bullet;
                    Bullet Copy5 = (Instantiate(shot2, transform.position + offset5, transform.rotation)) as Bullet;
                    counter = 0;
                    a.on = true;
                    b.on = false;
                }
                else if (cont.power < 5f)
                {
                    Vector3 offset1 = new Vector3(.25f, 0, 0);
                    Vector3 offset2 = new Vector3(-.25f, 0, 0);
                    Vector3 offset3 = new Vector3(0, .25f, 0);
                    Vector3 offset4 = new Vector3(-.5f, 0, 0);
                    Vector3 offset5 = new Vector3(.5f, 0, 0);
                    Bullet Copy = (Instantiate(shot, transform.position + offset1, transform.rotation)) as Bullet;
                    Bullet Copy2 = (Instantiate(shot, transform.position + offset2, transform.rotation)) as Bullet;
                    Bullet Copy3 = (Instantiate(shot, transform.position + offset3, transform.rotation)) as Bullet;
                    Bullet Copy4 = (Instantiate(shot2, transform.position + offset4, transform.rotation)) as Bullet;
                    Bullet Copy5 = (Instantiate(shot2, transform.position + offset5, transform.rotation)) as Bullet;
                    counter = 0;
                    a.on = true;
                    b.on = true;
                }
            }
        }
    }


}
