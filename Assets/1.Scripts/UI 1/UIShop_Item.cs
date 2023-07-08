using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIShop_Item : MonoBehaviour
{
    TMP_Text title;
    TMP_Text price;
    // Start is called before the first frame update
   

    //public string Title
    //{
    //    get { return title.text; }
    //    set { 
    //        if(title != null)
    //        {
    //            title.text = value; 
    //        }
    //    }
    //}
    //public string Price
    //{
    //    get { return price.text; }
    //    set {
    //        if(price != null)
    //        {
    //            price.text = value; 
    //        }
    //    }
    //}

    public void TitleText(string str)
    {
        if (title == null)
            title = transform.GetChild(0).GetComponent<TMP_Text>();
        title.text = str;
    }
    public void PriceText(string str)
    { 
        if (price == null)
            price = transform.GetChild(2).GetComponent<TMP_Text>();
        price.text = str; 
    }
}
