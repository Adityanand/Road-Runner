using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float JumpForce;
    public float TurnSpeed;
    public bool jump;
    public float Speedup;
    public bool carhit;
    public GameObject Panel;
    public int Multiplier;
    AudioSource Audio;
    public AudioClip[] clips;
   // Use this for initialization
    void Start () {
        speed = 5.0f;
        TurnSpeed = 5.0f;
        JumpForce = 100.0f;
        Speedup = 10.0f;
        Multiplier = 1;
        Audio = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        SpeedUp();
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Audio.isPlaying == false && jump==false)
        {
            Audio.clip = clips[0];
            Audio.Play();
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * TurnSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * TurnSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Space)&&jump==false)
        {
            jump = true;
            GetComponent<Animator>().SetBool("Jump", true);
          GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
            Audio.clip = clips[1];
            Audio.Play();
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Road")
        {
            jump = false;
            GetComponent<Animator>().SetBool("Jump", false);
        }
        if(collision.collider.tag=="Car")
        {
            carhit = true;
            GetComponent<Animator>().SetBool("CarHit",true);
            Panel.SetActive(true);
            speed = 0.0f;
            Audio.clip = clips[2];
            Audio.Play();
            Audio.volume = 1;
        }
    }

    private void SpeedUp()
    {
        Speedup = Speedup - 1 * Time.deltaTime;
        if (Speedup<=0.1f&& speed>=1.0f)
        {
            Multiplier += 1;
            speed += 1;
            Speedup = 10.0f;
        }
    }
}
