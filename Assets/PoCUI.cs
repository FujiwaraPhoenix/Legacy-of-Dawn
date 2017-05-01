using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoCUI : MonoBehaviour {
    int timer;
    public SpriteRenderer s;
    public Sprite defSprite, altSprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer % 10 == 5)
        {
            s.sprite = defSprite;
        }
        if (timer % 10 == 0)
        {
            s.sprite = altSprite;
        }
        if (timer > 180)
        {
            Destroy(this.gameObject);
        }
        timer++;
    }
}
