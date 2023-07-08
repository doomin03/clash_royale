using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct GoldShop
{
    public string Title;
    public int price;
}
public class UIShop : MonoBehaviour
{
    [SerializeField] private UIShop_Item[] uIShop_Items;
    List<GoldShop> goldShops = new List<GoldShop>();
    // Start is called before the first frame update
    void Awake()
    {
        string[] titles = { "1","2","3","4","5","6"};
        int[] price = {10,100,1000,10000,10000,1000 };
        for (int i = 0; i<uIShop_Items.Length;i++)
        {
            GoldShop goldShop= new GoldShop();
            goldShop.Title = titles[i];
            goldShop.price = price[i];
            goldShops.Add(goldShop);
        }
        for (int i = 0; i < uIShop_Items.Length; i++)
        {
            uIShop_Items[i].TitleText ( goldShops[i].Title);
            uIShop_Items[i].PriceText( string.Format("{0:#,###}", goldShops[i].price));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
