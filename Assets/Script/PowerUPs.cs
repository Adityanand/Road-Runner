using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUPs : MonoBehaviour {
    private GameObject Player;
    private float Position;
    private float height = 1;
    private float spawnz = 25.0f;
    private float MagnetTime;
    private float ShoesTime;
    private float Coin2XTime;
    private float ScoreBoosterTime;
    private CoinManager CoinManager;

    public GameObject[] PowerUp;
    public bool IsMagnet;
    public bool IswearingJumpShoes;
    public bool IsScoreMultipler;
    public bool IsCoin2X;
    public float Timer=0.0f;
    public int ScoreBoosters;
    public int coin2X;
    public Text ScoreBoosterText;
    public GameObject Time_Bar;
    // Use this for initialization
    void Start () {
        IsMagnet= false;
        MagnetTime = 20.0f;
        ShoesTime = 20.0f;
        ScoreBoosterTime = 20.0f;
        Coin2XTime = 20.0f;
        ScoreBoosters = 1;
        StartCoroutine(PowerUps());
        ScoreBoosterText.text = "X" + ScoreBoosters;
        CoinManager = GameObject.FindGameObjectWithTag("CoinManager").GetComponent<CoinManager>();
    }
    private IEnumerator PowerUps()
    {
        Position = Random.Range(-4f, 3f);
        Position = (int)Position;
        GameObject Powerups = Instantiate(PowerUp[Random.Range(0, PowerUp.Length)], new Vector3(Position, height, spawnz), transform.rotation) as GameObject;
        yield return new WaitForSeconds(20);
        spawnz = this.gameObject.transform.position.z * 1.5f;
        StartCoroutine(PowerUps());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Magnet")
        {
            Timer = MagnetTime;
            if(Timer==MagnetTime)
            IsMagnet = true;
            Destroy(other.gameObject);
            Time_Bar.SetActive(true);
        }
        if(other.gameObject.tag=="Shoes")
        {
            Timer = ShoesTime;
            if (Timer == ShoesTime)
             IswearingJumpShoes = true;
            Destroy(other.gameObject);
            Time_Bar.SetActive(true);
        }
        if(other.gameObject.tag=="ScoreMultiplier")
        {
            Timer = ScoreBoosterTime;
            if (Timer==ScoreBoosterTime)
             IsScoreMultipler = true;
            Destroy(other.gameObject);
            Time_Bar.SetActive(true);
        }
        if(other.gameObject.tag=="CoinBooster")
        {
            Timer = Coin2XTime;
            if (Timer == Coin2XTime)
                IsCoin2X = true;
            Destroy(other.gameObject);
            Time_Bar.SetActive(true);
        }
    }
    void ScoreBooster()
    {
        if (IsScoreMultipler == true)
        {
            ScoreBoosters = 25;
            CoinManager.score = CoinManager.score + ScoreBoosters*Time.deltaTime;
            ScoreBoosterText.text = "x" + ScoreBoosters ;
        }
        else
        {
            ScoreBoosters = 1;
            CoinManager.score = CoinManager.score + ScoreBoosters * Time.deltaTime;
            ScoreBoosterText.text = "x" + ScoreBoosters;
        }
    }
    void JumpShoes()
    {
        if (IswearingJumpShoes == true)
            this.gameObject.GetComponent<PlayerMovement>().JumpForce = 200;
        else
            this.gameObject.GetComponent<PlayerMovement>().JumpForce = 100;
    }
    // Update is called once per frame
    void Update () {
        JumpShoes();
        ScoreBooster();
        if((IsMagnet==true)||(IswearingJumpShoes==true)||IsScoreMultipler==true||IsCoin2X==true)
        {
            Timer -= 1 * Time.deltaTime;
        }
        if(Timer<.1f)
        {
            IsMagnet = false;
            IswearingJumpShoes = false;
            IsScoreMultipler = false;
            IsCoin2X = false;
        }
        //Magnet = GameObject.FindGameObjectWithTag("Magnet").transform;
        //Magnet.transform.Rotate(0, 5, 0, Space.World);
    }
}
