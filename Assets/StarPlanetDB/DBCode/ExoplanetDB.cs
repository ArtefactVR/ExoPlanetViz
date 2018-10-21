using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StarNamePosition
{
    public string name;
    public Vector3 position;
}

public class ExoplanetDB : MonoBehaviour
{
    public Exoplanet_StarsUnique2 stars;
    public Exoplanet_Data_Planets planets;

    // Use this for initialization
    void Start()
    {
        Debug.LogFormat("First Star {0}", stars.dataArray[0].Pl_hostname);
        Debug.LogFormat("First Planet {0}", planets.dataArray[0].Pl_name);

        List<Exoplanet_StarsUnique2Data> starList = starsWithEarthSizePlanets();
        if (starList.Count > 0)
        {
            Debug.LogFormat("There are {0} stars with earth or smaller planets", starList.Count);

            foreach (var star in starList)
            {
                //Debug.LogFormat("  Star {0} has {1} planets", star.Pl_hostname, star.Pl_pnum);
            }
        }
        List<StarNamePosition> starList2 = getStarNamePosition();
        if (starList2.Count > 0)
        {
            Debug.LogFormat("There are {0} stars", starList2.Count);

            foreach (var star in starList2)
            {
                //Debug.LogFormat("  Star {0} has position {1}", star.name, star.position.ToString());
            }
        }

    }

    public List<Exoplanet_StarsUnique2Data> first100Stars()
    {
        List<Exoplanet_StarsUnique2Data> firstStars = stars.dataArray.Take(100).ToList();
        return firstStars;
    }

    Vector3 GetStarLocation(Exoplanet_StarsUnique2Data star)
    {
        Vector3 position = new Vector3(star.X, star.Y, star.Z);
        return position;
    }

    public List<Exoplanet_Data_PlanetsData> PlanetsForStar(Exoplanet_StarsUnique2Data star)
    {
        //List<Exoplanet_Data_PlanetsData> planetLists =
        var planetLists =
            from p in planets.dataArray
            where p.Pl_hostname == star.Pl_hostname
            select p;
        return planetLists.ToList();
    }

    public List<Exoplanet_Data_PlanetsData> PlanetsForStarNamed(string starName)
    {
        //List<Exoplanet_Data_PlanetsData> planetLists =
        var planetLists =
            from p in planets.dataArray
            where p.Pl_hostname == starName
            select p;
        return planetLists.ToList();
    }

    public List<Exoplanet_StarsUnique2Data> starsWithEarthSizePlanets()
    {
        var starList = from p in planets.dataArray
                       from s in stars.dataArray
                       where (p.Pl_rade <= 1.0 && p.Pl_rade > 0) && (p.Pl_hostname == s.Pl_hostname)
                       select s;
        return starList.Distinct().ToList();
    }

    public List<StarNamePosition> getStarNamePosition()
    {
        var starList = from s in stars.dataArray
                       select new StarNamePosition
                       {
                           name = s.Pl_hostname,
                           position = GetStarLocation(s)
                       };
        return starList.ToList();
    }
}