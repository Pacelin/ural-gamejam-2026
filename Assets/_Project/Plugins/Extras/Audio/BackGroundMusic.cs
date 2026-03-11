using System;
using Plugins.Audio;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Plugins.Extras
{ 
public class BackGroundMusic : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            AudioSystem.Music_BGM.PlayOneShot();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
}