using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumericalMenuUI : MonoBehaviour {
    public int type;
    public TextMesh t;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        display();
	}

    void display()
    {
        if (type == 0)
        {
            t.GetComponent<TextMesh>().text = "Score    " + Controller.Instance.points;
        }
        else if (type == 1)
        {
            t.GetComponent<TextMesh>().text = "Power    " + Controller.Instance.power + "/4.00";
        }
    }
}
