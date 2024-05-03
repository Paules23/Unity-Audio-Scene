using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] footstepsOnGrass;
    public AudioClip[] footstepsOnWood;

    public string material;
    private int TimeToStep = 40;
    private int timer = 0;

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (vAxis > 0.1 || vAxis < -0.1)
        {
            if (timer > TimeToStep)
            {
                AudioSource myAudioSource = GetComponent<AudioSource>();
                myAudioSource.volume = Random.Range(0.9f, 1.0f);
                myAudioSource.pitch = Random.Range(0.8f, 1.2f);

                switch (material)
                {
                    case "Grass":
                        myAudioSource.PlayOneShot(footstepsOnGrass[Random.Range(0, footstepsOnGrass.Length)]);
                        break;

                    case "Wood":
                        myAudioSource.PlayOneShot(footstepsOnWood[Random.Range(0, footstepsOnWood.Length)]);
                        break;
                    case "Jumping":
                        break;
                    default:
                        break;
                }
                timer = 0;
            }
            timer++;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            
            case "Grass":
                material = collision.gameObject.tag;
                break;
            case "Wood":
                material = collision.gameObject.tag;
                break;
            default:
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Grass":
                material = "Jumping";
                break;
            case "Wood":
                material = "Jumping";
                break;

            default:
                break;
        }
    }
}
