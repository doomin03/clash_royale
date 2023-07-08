using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] NextCard nextCard;
    [SerializeField] private CardUI[] cards;
    [SerializeField] private Transform spwanTrans;


    void Start()
    {

        StartCoroutine(FristCardSpwan());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FristCardSpwan()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            //cards[i].ShowBGObject();
            //cards[i].Index = i;
            //cards[i].SetSpwan(spwanTrans);
            //cards[i].SetCardData(nextCard.NextCardData());
            //yield return new WaitForSeconds(0.2f);
            cards[i].Index= i;
            cards[i]
                .ShowBGObject()
                .SetSpwan(spwanTrans)
                .SetCardData(nextCard.NextCardData());
            yield return new WaitForSeconds(1);
        }
        InvokeRepeating("NextSpawnCard",1f,1f);
    }

    

    public void NextSpawnCard()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].Empty)
            {
                cards[i].ShowBGObject()
                    .SetSpwan(spwanTrans)
                    .SetCardData(nextCard.NextCardData());

                break;
            }
        }

    }
}
