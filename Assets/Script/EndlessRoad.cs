using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoad : MonoBehaviour {
    public GameObject[] Road;
    private Transform Player;
    private float spawnz=10.0f;
    private float safezone = 15.0f;
    private float RoadLength=20.0f;
    private int createRoadInrow = 6;
    private int lastCreatedRoadIndex = 0;
    private List<GameObject> CreatedRoad;
	// Use this for initialization
	void Start () {
        CreatedRoad = new List<GameObject>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i=0;i<createRoadInrow;i++)
        {
            if (i < 2)
                spawnRoad(0);
            else
            spawnRoad();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.transform.position.z-safezone>(spawnz-createRoadInrow*RoadLength))
        {
            spawnRoad();
            RemoveRoad();
        }
	}
    private void spawnRoad(int PrefabsIndex = -1)
    {
        GameObject CreateRoad;
        if (PrefabsIndex == -1)
            CreateRoad = Instantiate(Road[RandomSpawn()]) as GameObject;
        else
            CreateRoad = Instantiate(Road[PrefabsIndex]) as GameObject;
        CreateRoad.transform.SetParent(transform);
        CreateRoad.transform.position = Vector3.forward * spawnz;
        spawnz += RoadLength;
        CreatedRoad.Add(CreateRoad);
    }
    private int RandomSpawn()
    {
        if (Road.Length <= 1)
            return 0;
        int RandomIndex = lastCreatedRoadIndex;
        while(RandomIndex==lastCreatedRoadIndex)
        {
            RandomIndex = Random.Range(0, Road.Length);
        }
        lastCreatedRoadIndex = RandomIndex;
        return RandomIndex;
    }
    private void RemoveRoad()
    {
        
        Destroy(CreatedRoad[0]);
        CreatedRoad.RemoveAt(0);
        
    }
}
