using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {

    private int roadCount;

    public float offset = 0.706f;

    public GameObject roadPart;
    public Vector3 lastPos;

	public void StartBuilding () {
        InvokeRepeating("CreateNewRoadPart", 1f, .5f);
	}
	
    void CreateNewRoadPart()
    {
        float chance = Random.Range(0.0f, 1.0f);
        Vector3 spawnPos = chance > 0.5f ?
            new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset) :
            new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);

        GameObject g = Instantiate(roadPart, spawnPos, Quaternion.Euler(0,45,0));
        lastPos = g.transform.position;

        roadCount++;
        if (roadCount % 5 == 0)
            g.transform.GetChild(0).gameObject.SetActive(true);
    }
}
