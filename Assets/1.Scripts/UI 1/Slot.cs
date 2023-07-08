using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
   
    public Image image;
    private MyUIController cont;
    [HideInInspector]
    public int index;

    MyUIController con;

    private void Start()
    {
        cont= FindObjectOfType<MyUIController>();
        con= FindObjectOfType<MyUIController>();
    }
    public void OnDrop()
    {
        foreach(var item in con.Cards)
        {
            if (FindObjectOfType<UICardMove>().GetComponent<Image>().sprite.Equals(item.sprite))
            {
                return;                
            }

        }
       
        image.sprite = FindObjectOfType<UICardMove>().GetComponent<Image>().sprite;
        image.color = new Color(1f, 1f, 1f,1f);
        cont.myNums[index] = image.sprite.name;
        cont.DataSave();
        FindObjectOfType<UICardMove>().GetComponent<Image>().sprite = null;        

    }
    public void Button()
    {
        image.color = new Color(1f, 1f, 1f, 0.5f);

        cont.myNums[index] = "-1";
        cont.DataSave();
        image.sprite = null;
    }
    
}
