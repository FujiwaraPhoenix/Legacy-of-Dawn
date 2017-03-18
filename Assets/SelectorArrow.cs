using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorArrow : MonoBehaviour {

    public PauseMenu pm;
    public SpriteRenderer spr;
	
    void Start()
    {
        spr.enabled = false;
    }

	// Update is called once per frame
	void Update () {
        if (Controller.Instance.paused)
        {
            spr.enabled = true;
        }
        if (!Controller.Instance.paused)
        {
            spr.enabled = false;
        }
		if (pm.redo)
        {
            transform.position = new Vector3(-5.95f, 8.2f, 0);
        }
        else
        {
            transform.position = new Vector3(-8.5f, 11.25f, 0);
        }
	}
}
