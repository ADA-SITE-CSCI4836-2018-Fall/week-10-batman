using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawn : MonoBehaviour {

    public GameObject agentPrefab;
    public float timeSpawn = 2f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnAgent", timeSpawn, timeSpawn);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnAgent() {  
        GameObject go = Instantiate(agentPrefab);
        //Vector3 p = new Vector3(0, 0, 0);
        //go.transform.position = p;
    }
}
