using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmeyCastle : Castle
{

    [SerializeField]
    private Transform EnemySpawn;

    
    private float time;
    

    
    private float emeyCurEnergy = 0;
   

    private CardData nextCardData;

    
    void Start()
    {
        init();
    }
    void init() {
        classData.finding = "my";
        classData.HP = 5000.0f;
        classData.damege = 50;
        classData.attackRange = 50;
        curHP = maxHP;
        curHP = classData.HP;

        NextCardData();
    }

    void NextCardData()
    {
        int rand = Random.Range(0, ControllerManager.Instance.dataCont.datas.Length);
        nextCardData = ControllerManager.Instance.dataCont.datas[rand];
    }

    void Update()
    {
        


        time += Time.deltaTime;
        if (time > 0.5f)
        {
            time= 0;
            emeyCurEnergy += 0.6f;
            Debug.Log(emeyCurEnergy);
        }


        if (nextCardData.Cost <= emeyCurEnergy)
        {
            emeyCurEnergy = 0;
            
            Character character = Instantiate(nextCardData.Char, EnemySpawn);
            character.charData.finding = "my";
            character.tag = "enemy";
            character.cardData = nextCardData;
            character.transform.position = EnemySpawn.transform.position;
            NextCardData();
        }


        
    }
}
