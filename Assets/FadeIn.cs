using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {
    public static FadeIn eternal;
    public bool fadingOut, doNotFade;
    public SpriteRenderer screen;
    public float inc;
    public int timer;

	// Use this for initialization
	void Start () {
        doNotFade = true;
	}
	
	// Update is called once per frame
	void Update () {
        fadeBlack();
	}

    void fadeBlack()
    {
        Color invis = new Color(0, 0, 0, 0);
        if (!doNotFade)
        {
            if (inc < 240)
            {
                if (fadingOut)
                {
                    screen.color = Color.Lerp(Color.black,invis, inc / 240);
                }
                else
                {
                    screen.color = Color.Lerp(invis, Color.black, inc / 240);
                }
                inc++;
            }
            else if (inc == 240)
            {
                fadingOut = !fadingOut;
                inc = 0;
                timer++;
                if (timer > 0)
                {
                    doNotFade = true;
                    timer = 0;
                    inc = 0;
                }
            }
            
        }
        else
        {
            doNotFade = true;
            inc = 0;
            timer = 0;
        }
    }

    void Awake()
    {
        if (eternal == null)
        {
            DontDestroyOnLoad(gameObject);
            eternal = this;
        }
        else if (eternal != this)
        {
            Destroy(gameObject);
        }
    }
}
