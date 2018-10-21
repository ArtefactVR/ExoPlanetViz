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


    TextMesh starNameText;

    // Use this for initialization
    void Start () {
        RefreshStar();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RefreshStar()
    {
        starNameText = GameObject.Find("StarNameText").GetComponent<TextMesh>();

        transform.position = new Vector3(starPosX, starPosY, starPosZ);
        GetComponent<Renderer>().material.color = new Color(starColorR, starColorG, starColorB, starColorA);
        transform.localScale = Vector3.one * starSize;
        GetComponent<SphereCollider>().radius= Mathf.Sqrt(Vector3.Distance(transform.position, Vector3.zero)) * 0.1f;
    }

    public void DisplayStarName()
    {
        starNameText.text = starName;
        starNameText.transform.position = transform.position + Vector3.up * starSize;
        starNameText.transform.localScale = Vector3.one*Mathf.Sqrt(Vector3.Distance(transform.position, Vector3.zero))*0.2f;
        starNameText.transform.forward = Camera.main.transform.forward;
    }
}
