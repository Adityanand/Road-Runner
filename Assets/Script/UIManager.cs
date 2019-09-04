using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void TryAgain()
    {
        SceneManager.LoadScene("Road Runner");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
