using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour {
    public int itemNo;
    //True is Bombs. False is Power.
    public bool itemType;
    public SpriteRenderer spr;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        live();
	}

    void live()
    {
        if (itemType)
        {
            if (Controller.Instance.bombs >= itemNo)
            {
                spr.enabled = true;
            }
            else
            {
                spr.enabled = false;
            }
        }
        else
        {
            if (Controller.Instance.lives >= itemNo)
            {
                spr.enabled = true;
            }
            else
            {
                spr.enabled = false;
            }
        }
    }
}
