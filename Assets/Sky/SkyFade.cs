using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyFade : MonoBehaviour {
    Material thisMat;
    Color originalColor;


	// Use this for initialization
	void Start () {
        thisMat = GetComponent<Renderer>().material;
        originalColor = thisMat.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FadeOut()
    {
        thisMat.SetColor("_Color", new Color(originalColor.r, originalColor.g, originalColor.b, originalColor.a * 0.5f));
    }

    public void FadeIn()
    {
        thisMat.SetColor("_Color", new Color(originalColor.r, originalColor.g, originalColor.b, originalColor.a));
    }

    public void ClickConfirmed()
    {
        Debug.Log("ClickConfirmed:"+Time.realtimeSinceStartup+" ");
    }
}
