﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip colorShiftSound;
    static AudioSource colorShiftSrc;

    public static AudioClip dashSound;
    static AudioSource dashSrc;

    public static AudioClip swordSound;
    static AudioSource swordSrc;

    public static AudioClip jumpSound;
    static AudioSource jumpSrc;


    // Start is called before the first frame update
    void Start()
    {
        colorShiftSound = Resources.Load<AudioClip>("ColorShiftSFX");
        colorShiftSrc = GetComponent<AudioSource>();

        dashSound = Resources.Load<AudioClip>("DashSFX2");
        dashSrc = GetComponent<AudioSource>();

        swordSound = Resources.Load<AudioClip>("SwordSlash");
        swordSrc = GetComponent<AudioSource>();

        jumpSound = Resources.Load<AudioClip>("JumpYell");
        jumpSrc = GetComponent<AudioSource>();
    }

    public static void playColorShift()
    {
        colorShiftSrc.PlayOneShot(colorShiftSound);
    }

    public static void playDash()
    {
        dashSrc.PlayOneShot(dashSound);
    }

    public static void playSwordSlash()
    {
        swordSrc.PlayOneShot(swordSound);
    }
    public static void playJumpYell()
    {
        jumpSrc.PlayOneShot(jumpSound);
    }


}
