using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMove : MonoBehaviour {

    //public Transform agentGoal;
    public float agentSpeedMin = 0f;
    public float agentSpeedMax = 3f;
    public float agentHealth = 2f;
    public float distanceClose = 3f;

    private float agentSpeed;
    private NavMeshAgent agent;
    private GameObject player;

    // Audio clips and settings
    private AudioSource soundSource;
    private float soundVolLow = .5f;
    private float soundVolHigh = 1.0f;

    public AudioClip soundKill;
    public AudioClip soundHitSoft;
    public AudioClip soundHitHard;

    private void Awake() {
        soundSource = GetComponent<AudioSource>();
    }

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
        if (collision.gameObject.tag == "bullet" && agentHealth > 0) {
            // Play sound
            soundSource.pitch = Random.Range(soundVolLow, soundVolHigh);
            if (Vector3.Distance(gameObject.transform.position, GameObject.Find("Player").transform.position) <= distanceClose) {
                //Debug.Log("Hard shot!");
                soundSource.PlayOneShot(soundHitHard);
            }
            else {
                //Debug.Log("Soft shot!");
                soundSource.PlayOneShot(soundHitSoft);
            }
            // Destroy the bullet
            Destroy(collision.gameObject);

            agentHealth--;

            if (agentHealth <= 0) {
                agent.speed = 0;
                soundSource.pitch = 1;
                soundSource.PlayOneShot(soundKill);
                // Kill it after playing sound
                Destroy(gameObject, soundKill.length);
            }
        }
    }
}
