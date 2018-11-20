using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour {

    public float playerSpeed = 10f;
    public float playerSpeedAngular = 150.0f;
    public float bulletSpeed = 10f;
    public float bulletDestroyTime = 2f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
        var navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent != null) {
            navMeshAgent.speed = playerSpeed;
            navMeshAgent.angularSpeed = playerSpeedAngular;
            //navMeshAgent.updatePosition = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeedAngular;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Fire();
        }
    }

    void Fire () {
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, bulletDestroyTime);
    }
}
