using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICard : MonoBehaviour,IDragHandler
{

    public Image targetImg = null;
    [SerializeField] private MyUIController cont;
    
    public void OnDrag(PointerEventData eventData)
    {
        if (targetImg != null)
        {
            targetImg.transform.position = Input.mousePosition;
        }
    }

    public void OnPointUp()
    {
        if (targetImg != null)
        {
            
            targetImg.color = new Color(1f, 1f, 1f, 1f / 255f);
        }
        targetImg = null;
    }

    public void OnPointDown()
    {
        targetImg = FindObjectOfType<UICardMove>().GetComponent<Image>();
        targetImg.color = new Color(1f, 1f, 1f, 1f);
        targetImg.sprite = GetComponent<Image>().sprite;
        targetImg.transform.position = Input.mousePosition;
    }
}
