using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VictorySound : MonoBehaviour
{
    public AudioClip clip;
    public float volume;
    new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        // Nothing to see here
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Play the sound only on the trigger
            audio.PlayOneShot(clip, volume);
            
            int y = SceneManager.GetActiveScene().buildIndex;
            int total = SceneManager.sceneCountInBuildSettings;
            System.Threading.Thread.Sleep(750);
            if (y + 1 != total) {                
                SceneManager.LoadScene(y + 1);
            } else {
                Application.Quit();
            }
        }
    }
}
