using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private float starttime ;
    public Slider slider;
    public GameObject retrypnl;
    public GameObject car;
    public GameObject maingameUI;
    // Start is called before the first frame update
    void Start()
    {
        starttime = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value  == 0)
        {
            maingameUI.SetActive(false);
            car.SetActive(false);
            retrypnl.SetActive(true);
        }
        starttime -= 1*Time.deltaTime;

        slider.value = starttime;
    }
    
}
