
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image Energy;
    [SerializeField] private Image EnergyBG;
    [SerializeField] private TMP_Text EnergyText;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image textBG;



    private float MyEnergy = 10;
    private float curEnergy = 0;
    private float time;

    public float CurEnergy
    {
        set
        {
            curEnergy -= value;
            Energy.fillAmount = curEnergy / MyEnergy;
        }
        get {
            return curEnergy;
        }
    }
    void Start()
    {
        Energy.fillAmount = curEnergy / MyEnergy;
        EnergyBG.fillAmount = curEnergy / MyEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (curEnergy <= 10)
        {
            if (time > 0.5f)
            {
                time= 0;
                curEnergy += 1f;
                Energy.fillAmount = curEnergy / MyEnergy;
                float curEnergyText = Mathf.Floor(curEnergy);
                EnergyText.text = string.Format($"{curEnergyText}/10");
            }
        }
        double energy = (curEnergy/MyEnergy)*10f;
        energy = System.Math.Truncate(energy);
        EnergyBG.fillAmount = ((float)energy / 10f) + 0.1f;

    }

    public void ShowText(string text)
    {
        this.text.text = text;
    }
    public void MainButton()
    {
        SceneManager.LoadScene(0);
    }






}

