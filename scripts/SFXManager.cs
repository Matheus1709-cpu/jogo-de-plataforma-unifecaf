using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    public AudioSource somDaColeta, somDeDano, SomDoPulo;

    void Awake()
    {
        instance = this; 
    }

    
}
