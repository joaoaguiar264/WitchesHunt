                            using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManagerSFX : MonoBehaviour
{
    public static AudioSource AudioSFX;
    public static AudioSource AudioMusic;
    public static AudioClip right, wrong, pit, grassStep, woodStep, rockStep, sandStep, medalionVibrance, hide, sword, mouseClick, treeMagic, water, templarSteps;
    public PhotonView pv;


    void Start()
    {
        AudioSFX = this.GetComponent<AudioSource>();
      //  AudioMusic = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();

        right = Resources.Load<AudioClip>("SFX_right");
        wrong = Resources.Load<AudioClip>("SFX_wrong");
        pit = Resources.Load<AudioClip>("SFX_poço");
        hide = Resources.Load<AudioClip>("SFX_esconder");
        grassStep = Resources.Load<AudioClip>("SFX_grassStep");
        sword = Resources.Load<AudioClip>("SFX_espada");
        templarSteps = Resources.Load<AudioClip>("templario caminhando");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
