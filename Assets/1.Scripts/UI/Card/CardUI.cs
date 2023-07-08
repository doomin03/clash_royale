using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Data.Common;

public class CardUI : MonoBehaviour,IDragHandler,IDropHandler
{ 
    [SerializeField] private Transform spwanTrans;
    [SerializeField] private GameObject bgObject;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Image Icon;
    [SerializeField] private Canvas canvas;
    


    CardData cardData;
    
    public int Index { get; set; }
    public bool Empty { get; set; }

    private int cardCost;

    public CardUI SetSpwan(Transform spwanTrans)
    {
        this.spwanTrans = spwanTrans;
        return this;
    }

    public CardUI ShowBGObject()
    {
        Empty= false;
        bgObject.SetActive(true);
        GetComponent<Button>().enabled = true;    
        
        return this;
    }

    public CardUI HideBGObject()
    {
        Empty = true;
        bgObject.SetActive(false);
        GetComponent<Button>().enabled = false;
        return this;
    }
    void SetCost()
    {
        costText.text = cardData.Cost.ToString();
        cardCost = cardData.Cost;
    }
    void SetIcon()
    {
        Icon.sprite = cardData.CharImage;
    }
    
    
    public CardUI SetCardData(CardData cardData)
    {
        this.cardData = cardData;
        SetCost();
        SetIcon();
        return this;
    }
    public void Spawn()
    {
        //float curEnergy = ControllerManager.Instance.uiCont.CurEnergy;
        //if(!((curEnergy- (float)cardCost) < 0))
        //{
        //    Character character = Instantiate(cardData.Char, spwanTrans);
        //    character.charData.finding = "enemy";
        //    character.tag = "my";
        //    character.cardData=this.cardData;
        //    ControllerManager.Instance.uiCont.CurEnergy = (float)cardCost;
        //    HideBGObject();
        //}
        //else
        //{
        //    ControllerManager.Instance.uiCont.ShowText("에너지가 부족합니다");
        //}
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().anchoredPosition+=eventData.delta/canvas.scaleFactor;
    }
    RaycastHit hit;
    

    
    private void Update()
    {
        if(Physics.Raycast(transform.position,transform.forward,out hit, 100))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red) ;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(hit.transform == null)
        {
            StartCoroutine("cardPosInit");
            return;
        }
        float curEnergy = ControllerManager.Instance.uiCont.CurEnergy;
        if(!((curEnergy- (float)cardCost) < 0))
        {
            Character character = Instantiate(cardData.Char, spwanTrans);
            character.charData.finding = "enemy";
            character.tag = "my";
            character.cardData=this.cardData;
            character.transform.position = new Vector3(hit.point.x, 0.5f, hit.point.z);
            ControllerManager.Instance.uiCont.CurEnergy = (float)cardCost;
            HideBGObject();
        }
        else
        {
            ControllerManager.Instance.uiCont.ShowText("에너지가 부족합니다");
        }
        StartCoroutine(cardPosInit());
    }
    IEnumerator cardPosInit()
    {
        transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        transform.parent.GetComponent<HorizontalLayoutGroup>().enabled=true;
    }
}
