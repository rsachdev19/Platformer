using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCannonBall : MonoBehaviour {

    public float TimeBetweenSpawn;
    public float Timer;
    public GameObject cannonball;
    private int offsetX;
    private int offsetY;
    private int offsetZ;
    public Vector3 endPoint;
    public int speed;
    // Use this for initialization
    void Start() {
        Timer = 0;
        offsetX = 5;
        offsetY = 3;
        offsetZ = 0;
    }

    // Update is called once per frame
    void Update() {
        Timer -= Time.deltaTime;
        if (Timer <= 0f) {
            Spawn();
            Timer = TimeBetweenSpawn;
        }
    }

    void Spawn() {
        Vector3 spawnPoint = transform.position;
        spawnPoint.y += offsetY;
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        if (eulerAngles.y == 0) {
            spawnPoint.x += offsetX;
        } else if (eulerAngles.y == 180) {
            spawnPoint.x -= offsetX;
        }
        //GameObject ball = Instantiate(cannonball, new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z + offsetZ), transform.rotation) as GameObject;
        GameObject ball = Instantiate(cannonball, spawnPoint, transform.rotation) as GameObject;
        CannonballController script = ball.GetComponent<CannonballController>();
        script.speed = speed;
        script.endPoint = endPoint;

    }
}
