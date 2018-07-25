using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour {
    public AudioClip clip;
    public float volume;
    new AudioSource audio;
    bool hasPlayed = false;

    void Start()
    {
        hasPlayed = false;
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        // Nothing to see here
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (!hasPlayed)
            {
                audio.PlayOneShot(clip, volume);
                System.Threading.Thread.Sleep(350);
                hasPlayed = true;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
