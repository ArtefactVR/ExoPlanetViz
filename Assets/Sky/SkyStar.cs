using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyStar : MonoBehaviour {
    public string starName;
    public float starColorR=1f;
    public float starColorG=1f;
    public float starColorB=1f;
    public float starColorA=1f;
    public float starSize=0.1f;
    public float starPosX;
    public float starPosY;
    public float starPosZ=2f;

	// Use this for initialization
	void Start () {
        RefreshStar();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RefreshStar()
    {
        transform.position = new Vector3(starPosX, starPosY, starPosZ);
        GetComponent<Renderer>().material.color = new Color(starColorR, starColorG, starColorB, starColorA);
        transform.localScale = Vector3.one * starSize;
    }
}
