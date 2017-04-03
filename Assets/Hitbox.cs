using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {
    public bool on;
    public Controller cont;
    public SpriteRenderer spriteRenderer;
    public Sprite a;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!Controller.Instance.paused)
        {
            onoff();
        }
        }

    void onoff()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            on = true;
        }
        else
        {
            on = false;
        }
        if (!on)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
    }
}
