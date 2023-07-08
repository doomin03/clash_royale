using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContoller : MonoBehaviour
{
    public CardData[] datas;
    public List<CardData> picupCds;

    public void Init()
    {
        string[] strs = PlayerPrefs.GetString("mycard").Split(',');

        foreach(var str in strs)
        {
            if(str=="-1")
            { continue; }
            foreach(var data in datas)
            {
                if(str == data.CharImage.name)
                {
                    picupCds.Add(data);
                    break;
                }
            }
        }
    }
}
