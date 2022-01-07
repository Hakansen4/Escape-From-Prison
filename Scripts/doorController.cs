using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;
    private AudioSource audio;
    public AudioClip sound;
    private bool opened = false;
    private Animator anim;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("MainCamera") != null)
            PlayerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        //This will tell if the player press F on the Keyboard. P.S. You can change the key if you want.
        if (Input.GetKeyDown(KeyCode.F))
        {
            Pressed();
        }
    }

    void Pressed()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {

            // if raycast hits, then it checks if it hit an object with the tag Door.
            if (doorhit.transform.tag == "door")
            {

                //This line will get the Animator from  Parent of the door that was hit by the raycast.
                anim = doorhit.transform.GetComponentInParent<Animator>();

                audio.clip = sound;
                audio.Play();

                //This will set the bool the opposite of what it is.
                opened = !opened;

                //This line will set the bool true so it will play the animation.
                anim.SetBool("Opened", !opened);
            }
        }
    }
}
