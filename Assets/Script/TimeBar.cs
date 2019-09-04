using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeBar : MonoBehaviour
{
    public float TimeLeft;
    public float MaxTime;
    Image Time_Bar;
    // Start is called before the first frame update
    void Start()
    {
        MaxTime = 20.0f;
        TimeLeft = MaxTime;
        Time_Bar = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (TimeLeft>0 && this.enabled==true)
        {
            TimeLeft -=1f*Time.deltaTime;
            Time_Bar.fillAmount = TimeLeft / MaxTime;
        }
        else if (TimeLeft <= 0)
        {
            this.gameObject.SetActive(false);
            MaxTime = 20;
            TimeLeft = MaxTime;
            Time_Bar.fillAmount = 1;
        }
    }
}
