using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sounds")]
    private AudioSource audioSource;
    [SerializeField] AudioClip[] jumps;
    [SerializeField] AudioSource run;
    [SerializeField] AudioClip[] dies;
    [SerializeField] AudioClip[] darts;
    [SerializeField] AudioClip bottle;
    [SerializeField] AudioClip pickup;
    [SerializeField] AudioClip shoot;
    [SerializeField] AudioClip grapple;
    [SerializeField] AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(GameManager.isPaused)
        {
            music.volume = 0.02f;
        }
        else
        {
            music.volume = 0.1f;
        }
    }

    public void PlaySound(string sound)
    {
        switch (sound)
        {
            case "jump":
                audioSource.PlayOneShot(jumps[Random.Range(0, jumps.Length)]);
                break;
            case "run":
                run.Play();
                break;
            case "die":
                audioSource.PlayOneShot(dies[Random.Range(0, dies.Length)]);
                break;
            case "dart":
                audioSource.PlayOneShot(darts[Random.Range(0, darts.Length)]);
                break;
            case "bottle":
                audioSource.PlayOneShot(bottle);
                break;
            case "pickup":
                audioSource.PlayOneShot(pickup);
                break;
            case "shoot":
                audioSource.PlayOneShot(shoot);
                break;
            case "grapple":
                audioSource.PlayOneShot(grapple);
                break;
        }
    }

    public void StopSound(string sound)
    {
        switch (sound)
        {
            case "run":
                run.Stop();
                break;
        }
    }
}
