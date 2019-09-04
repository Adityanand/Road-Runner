using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    private CoinManager CoinManager;
    private PowerUPs Player;
    private Transform magnet;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PowerUPs>();
        magnet = GameObject.FindGameObjectWithTag("MagnetPower").transform;
        CoinManager = GameObject.FindGameObjectWithTag("CoinManager").GetComponent<CoinManager>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 5, 0, Space.World);
        Magnet();
        if(Player.transform.position.z-10.0f>this.transform.position.z)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Player")
        {
            CoinManager.CoinCollect();
            Destroy(this.gameObject);
        }
       
    }
    public void Magnet()
    {
        if (Player.IsMagnet == true)
        {
            if (Vector3.Distance(magnet.transform.position, this.transform.position) < 10)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, magnet.position, .5f);
            }
        }  
    }
}
