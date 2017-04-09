using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Controller.Instance.bossMaxHP != 0)
        {
            float percentHP = 3.1f * Controller.Instance.bossHP / Controller.Instance.bossMaxHP;
            transform.localScale = new Vector3(percentHP, .5f, 0);
        }
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
	}
}
