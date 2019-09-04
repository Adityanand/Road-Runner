using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpeed : MonoBehaviour {
    public float speed;
    AudioSource Audio;
    public AudioClip Clip;
	// Use this for initialization
	void Start () {
        speed = 2.5f;
        Audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(Audio.isPlaying==false)
        {
            Audio.clip = Clip;
            Audio.Play();
            Audio.volume = .15f;
            Audio.spatialBlend = .9f;
        }
        if (player.GetComponent<PlayerMovement>().carhit == true)
            speed = 0.0f;
	}
}
