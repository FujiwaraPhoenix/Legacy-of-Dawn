using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject shot;

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
        if (Input.GetKey(KeyCode.Z))
        {
            if (counter > 5)
            {
                GameObject Copy = (Instantiate(shot, transform.position, transform.rotation)) as GameObject;
                counter = 0;
            }
        }
    }
}
