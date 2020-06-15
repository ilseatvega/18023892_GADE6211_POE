using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for cinemachine
using Cinemachine;

public class HailShake : MonoBehaviour
{
    //sound
    private AudioSource thud;
    //using cinemachine virtual cam
    CinemachineVirtualCamera vCam;

    private void Start()
    {
        //get audio source component
        thud = GetComponent<AudioSource>();
        //getting the virtual cam and setting it to vcam
       vCam = Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
    }
    //when hail collides w ground
    private void OnCollisionEnter(Collision collision)
    {
        //if collides w ground
        if (collision.gameObject.tag == "Ground")
        {
            //sound
            thud.Play();
            //start shake coroutine
            StartCoroutine(Shake());
        }
    }
    //shake coroutine that shakes camera for 1 sec
    IEnumerator Shake()
    {//set amplitude gain to 3 (more "voilent" shake)
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 3f;
        //wait 1 sec
        yield return new WaitForSeconds(1f);
        //set it back to 0 (no shaking)
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
    }
}
