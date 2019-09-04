using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {
    private Transform Player;
    public GameObject CoinPrefabs;
    private float Position;
    private float height=1;
    private float spawnz=25.0f;
    private int CoinInst=5;
    private PlayerMovement playerMovement;
    private int HighScore;
    private int Iscore;
    AudioSource Audio;

    public float score;
    public int CoinCollected;
    public Text Coin;
    public Text Score;
    public Text HighScoreValue;
    public Text CurrentScore;
    public AudioClip Clip;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement=Player.GetComponent<PlayerMovement>();
        StartCoroutine(CoinSpawn());
        Audio = this.GetComponent<AudioSource>();
    }
    
	private IEnumerator CoinSpawn()
    {
        Position = Random.Range(-4f, 3f);
        Position = (int)Position;
        for (int i = 0; i < CoinInst; i++)
        {
            GameObject Coin = Instantiate(CoinPrefabs, new Vector3(Position, height,spawnz), transform.rotation);
            Coin.transform.SetParent(transform);
            spawnz += 1f;
        }
        spawnz = Player.transform.position.z *2;
        yield return new WaitForSeconds(5);
        StartCoroutine(CoinSpawn());
    }
    public void CoinCollect()
    {
        if (Player.GetComponent<PowerUPs>().IsCoin2X == true)
        {
            CoinCollected += 2;
            Audio.clip = Clip;
            Audio.Play();
        }
        else
        {
            CoinCollected += 1;
            Audio.clip = Clip;
            Audio.Play();
        }
        Coin.text = CoinCollected.ToString();
    }
    // Update is called once per frame
    void Update () {
        HighScore = PlayerPrefs.GetInt("HighScore", HighScore);
        HighScoreValue.text = "00" + HighScore;
        if (playerMovement.carhit != true)
        {
            score = score + 1.0f * Time.deltaTime * playerMovement.Multiplier;
            Iscore = (int)score;
            Score.text = "00" + Iscore;
            CurrentScore.text = "00" + Iscore;
        }
        if(HighScore<score)
        {
            HighScore = Iscore;
            HighScoreValue.text = "00" + HighScore;
        }
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.Save();
    }
}
