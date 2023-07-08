using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NextCard : MonoBehaviour
{
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Image iconImage;
    Queue<CardData> cards= new Queue<CardData>();
    CardData nextCardDara = null;

    public void Init()
    {
        for(int i = 0; i < 5; i++)
        {
            int rand = Random.Range(0, ControllerManager.Instance.dataCont.picupCds.Count);
            CardData so = ControllerManager.Instance.dataCont.picupCds[rand];
            cards.Enqueue(so);

        }
        nextCardDara = cards.Dequeue();
        InvokeRepeating("NextCardAdd", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (nextCardDara != null)
        {
            costText.text = $"{nextCardDara.Cost}";
            iconImage.sprite = nextCardDara.CharImage;
        }
            
    }
    public void NextCardAdd() {
        if (cards.Count >= 5)
        {
            return;
        }
        int rand = Random.Range(0, ControllerManager.Instance.dataCont.picupCds.Count);
        CardData so = ControllerManager.Instance.dataCont.picupCds[rand];
        cards.Enqueue(so);
    }
    public CardData NextCardData() 
    {
        CardData cd = nextCardDara;
        nextCardDara = cards.Dequeue();
        return cd;
    }
}
