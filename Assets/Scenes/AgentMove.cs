using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMove : MonoBehaviour {

    //public Transform agentGoal;
    public float agentSpeedMin = 0f;
    public float agentSpeedMax = 3f;

    private float agentSpeed;
    private NavMeshAgent agent;
    private GameObject player;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        agentSpeed = Random.Range(agentSpeedMin, agentSpeedMax);

        if (agent != null) {
            agent.speed = agentSpeed;
            agent.destination = player.transform.position;
        }
    }

    // Update is called once per frame
    void Update () {
        agent.destination = player.transform.position;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "bullet") {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
