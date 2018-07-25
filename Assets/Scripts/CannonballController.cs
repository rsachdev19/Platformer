using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CannonballController : MonoBehaviour {

    public AudioClip clip;
    public float volume;
    new AudioSource audio;
    bool hasPlayed = false;
    public int speed;
    public Vector3 endPoint;

    // Use this for initialization
    void Start() {
        audio = GetComponent<AudioSource>();
        print(transform.position.x + " " + transform.position.y + " " + transform.position.z);
    }

    // Update is called once per frame
    void Update() {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPoint, Time.deltaTime * speed);
        if (Vector3.Distance(transform.localPosition, endPoint) <= 0.1) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Player")) {
            if (!hasPlayed) {
                audio.PlayOneShot(clip, volume);
                System.Threading.Thread.Sleep(350);
                hasPlayed = true;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
