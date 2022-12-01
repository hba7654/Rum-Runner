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
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string sound)
    {
        switch (sound)
        {
            case "jump":
                audioSource.PlayOneShot(jumps[Random.Range(0, jumps.Length)], 0.24f);
                break;
            case "run":
                run.Play();
                break;
            case "die":
                audioSource.PlayOneShot(dies[Random.Range(0, dies.Length)], 0.24f);
                break;
            case "dart":
                audioSource.PlayOneShot(darts[Random.Range(0, darts.Length)], 0.24f);
                break;
            case "bottle":
                audioSource.PlayOneShot(bottle);
                break;
            case "pickup":
                audioSource.PlayOneShot(pickup, 0.2f);
                break;
            case "shoot":
                audioSource.PlayOneShot(shoot, 0.2f);
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
