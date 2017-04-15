using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour {
    public int SDTimer;
    public float maxScale;

	// Use this for initialization
	void Start () {
        SDTimer = 20;
        maxScale = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Controller.Instance.paused)
        {
            if (SDTimer > 0)
            {
                float xy = maxScale * Mathf.Sin(90 * SDTimer / 30);
                transform.localScale = new Vector3(xy, xy);
            }
            else
            {
                Destroy(this.gameObject);
            }
            SDTimer--;
        }
	}
}
