using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyZoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ZoomIn()
    {
        transform.localScale = transform.localScale * 2f;
    }

    public void ZoomOut()
    {
        transform.localScale = transform.localScale * 0.5f;
    }
}
