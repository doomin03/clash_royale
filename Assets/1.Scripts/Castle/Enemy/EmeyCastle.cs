using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmeyCastle : MonoBehaviour
{

    [SerializeField]
    private Image MyHPImage;
    [SerializeField]
    private TMP_Text _Text;
    [SerializeField]
    private Transform EnemySpawn;

    private float maxHP = 5000;
    private float curHP = 0;
    private float time;
    [SerializeField]
    private TMP_Text _Text2; 

    private float emeyMaxEnergy = 100;
    private float emeyCurEnergy = 0;
    [SerializeField]
    private Image cost;
    [SerializeField]
    private GameObject panel;

    private CardData nextCardData;

    public float HP
    {
        get
        {
            return curHP;
        }
        set
        {
            curHP -= value;
            MyHPImage.fillAmount = curHP / maxHP;
            if (curHP <= 0)
            {
                gameObject.SetActive(false);
                cost.color = new Color(1f, 1f, 1f, 1f);
                panel.SetActive(true);
                _Text2.text = "Win";
                _Text2.color = Color.blue;
                Time.timeScale = 0f;
            }

        }
    }
    void Start()
    {
        curHP = maxHP;
        NextCardData();
    }

    void NextCardData()
    {
        int rand = Random.Range(0, ControllerManager.Instance.dataCont.datas.Length);
        nextCardData = ControllerManager.Instance.dataCont.datas[rand];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            HP = 1000;
            MyHPImage.fillAmount = curHP / maxHP;
        }


        time += Time.deltaTime;
        if (time > 0.5f)
        {
            time= 0;
            emeyCurEnergy += 0.1f;
        }


        if (nextCardData.Cost <= emeyCurEnergy)
        {
            emeyCurEnergy = 0;
            
            Character character = Instantiate(nextCardData.Char, EnemySpawn);
            character.charData.finding = "my";
            character.tag = "enemy";
            character.cardData = nextCardData;
            NextCardData();
        }
    }
}
