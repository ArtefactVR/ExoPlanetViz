using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyUniverse : MonoBehaviour {

    SkyStar[] skyStars;
    public GameObject starPrefab;
    public int numStars = 100;

	// Use this for initialization
	void Start () {
        skyStars = new SkyStar[numStars];

        for(int i=0; i<numStars; i++)
        {
            skyStars[i] = GenerateRandomStar(i);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    SkyStar GenerateRandomStar(int index)
    {
        GameObject newStarGO = Instantiate(starPrefab, transform);

        SkyStar newStar = newStarGO.GetComponent<SkyStar>();

        newStar.starName = "Star-" + index.ToString("0000");
        newStarGO.name = newStar.starName;
        newStar.starColorR = Random.Range(0f, 1f);
        newStar.starColorG = Random.Range(0f, 1f);
        newStar.starColorB = Random.Range(0f, 1f);
        newStar.starColorA = Random.Range(0.5f, 1f);

        Vector3 newPos = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized* Random.Range(200f, 800f);

        newStar.starPosX = newPos.x;
        newStar.starPosY = newPos.y;
        newStar.starPosZ = newPos.z;
        newStar.starSize = Random.Range(0.2f, 1f);

        newStar.RefreshStar();

        return newStar;
    }
}
