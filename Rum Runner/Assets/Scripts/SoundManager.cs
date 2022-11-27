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
    //[SerializeField] AudioSource[] darts;
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
                Debug.Log("JUMP");
                audioSource.PlayOneShot(jumps[Random.Range(0, jumps.Length)], 0.24f);
                break;
            case "run":
                Debug.Log("RUN");
                run.Play();
                break;
            case "die":
                Debug.Log("DIE");
                audioSource.PlayOneShot(dies[Random.Range(0, dies.Length)]);
                break;
            //case "dart":
            //    break;
            case "bottle":
                Debug.Log("BOTTLE");
                audioSource.PlayOneShot(bottle);
                break;
            case "pickup":
                Debug.Log("PICKUP");
                audioSource.PlayOneShot(pickup, 0.2f);
                break;
            case "shoot":
                Debug.Log("SHOOT");
                audioSource.PlayOneShot(shoot, 0.2f);
                break;
        }
    }

    public void StopSound(string sound)
    {
        switch (sound)
        {
            //case "jump":
            //    Debug.Log("JUMP");
            //    jumps[Random.Range(0, jumps.Length)].Stop();
            //    break;
            case "run":
                Debug.Log("RUN");
                run.Stop();
                break;
                //case "die":
                //    Debug.Log("DIE");
                //    dies[Random.Range(0, dies.Length)].Stop();
                //    break;
                ////case "dart":
                ////    break;
                //case "bottle":
                //    Debug.Log("BOTTLE");
                //    bottle.Stop();
                //    break;
                //case "pickup":
                //    Debug.Log("PICKUP");
                //    pickup.Stop();
                //    break;
                //case "shoot":
                //    Debug.Log("SHOOT");
                //    shoot.Stop();
                //    break;
        }
    }

    //[Header("Sounds")]
    //[SerializeField] AudioSource[] jumps;
    //[SerializeField] AudioSource run;
    //[SerializeField] AudioSource[] dies;
    ////[SerializeField] AudioSource[] darts;
    //[SerializeField] AudioSource bottle;
    //[SerializeField] AudioSource pickup;
    //[SerializeField] AudioSource shoot;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //public void PlaySound(string sound)
    //{
    //    switch (sound)
    //    {
    //        case "jump":
    //            Debug.Log("JUMP");
    //            jumps[Random.Range(0, jumps.Length)].Play();
    //            break;
    //        case "run":
    //            Debug.Log("RUN");
    //            run.Play();
    //            break;
    //        case "die":
    //            Debug.Log("DIE");
    //            dies[Random.Range(0, dies.Length)].Play();
    //            break;
    //        //case "dart":
    //        //    break;
    //        case "bottle":
    //            Debug.Log("BOTTLE");
    //            bottle.Play();
    //            break;
    //        case "pickup":
    //            Debug.Log("PICKUP");
    //            pickup.Play();
    //            break;
    //        case "shoot":
    //            Debug.Log("SHOOT");
    //            shoot.Play();
    //            break;
    //    }
    //}

    //public void StopSound(string sound)
    //{
    //    switch (sound)
    //    {
    //        case "jump":
    //            Debug.Log("JUMP");
    //            jumps[Random.Range(0, jumps.Length)].Stop();
    //            break;
    //        case "run":
    //            Debug.Log("RUN");
    //            run.Stop();
    //            break;
    //        case "die":
    //            Debug.Log("DIE");
    //            dies[Random.Range(0, dies.Length)].Stop();
    //            break;
    //        //case "dart":
    //        //    break;
    //        case "bottle":
    //            Debug.Log("BOTTLE");
    //            bottle.Stop();
    //            break;
    //        case "pickup":
    //            Debug.Log("PICKUP");
    //            pickup.Stop();
    //            break;
    //        case "shoot":
    //            Debug.Log("SHOOT");
    //            shoot.Stop();
    //            break;
    //    }
    //}
}
