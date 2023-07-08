using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.UIElements;

public class MyUIController : MonoBehaviour
{
    [SerializeField] private Image[] mycardImages;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private List<CardData> cardDatas;
    [SerializeField]
    private Sprite[] CardIcon;
    [SerializeField]
    private Image IconCard;
    [SerializeField]
    private Transform parent;
    
    public Image[] Cards;
    [SerializeField]
    private Transform BG;

    [HideInInspector]
    public string[] myNums;
    

    void Start()
    {
        CreateCArd();
        for (int i = 0; i<mycardImages.Length; i++)
        {
            mycardImages[i].GetComponent<Slot>().index = i;
        }
     
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("mycard")))
        {
            string[] arrayStr = { "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1" };
            myNums = arrayStr;
            DataSave();
        }
        else
        {
            MyCardSetting();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    void CreateCArd()
    {
        List<Image> myCardImage = new List<Image>();
        foreach(var item in sprites)
        {
            Image img = Instantiate(IconCard, parent);
            img.sprite = item;
            img.raycastTarget = false;
            img.color = new Color(1f, 1f, 1f, 0.5f);
            myCardImage.Add(img);
        }
        for(int i = 0;i< cardDatas.Count; i++)
        {
            for (int j = 0;j< myCardImage.Count; j++)
            {
                if (cardDatas[i].CharImage.name == myCardImage[j].sprite.name)
                {
                    myCardImage[j].color = new Color(1f, 1f, 1f, 1f);
                    myCardImage[j].raycastTarget =true ;
                    break;
                }
            } 
        }
    }
    
    public void Battle()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    public void DataSave()
    {
        string str = string.Empty;
        for (int i = 0;i< myNums.Length;i++)
        {
            str+= myNums[i];
            if (i != (myNums.Length - 1))
            {
                str+= ",";
            }
        }
        PlayerPrefs.SetString("mycard", str);
    }
    public void MyCardSetting()
    {
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("mycard")))
        {
            string[] strs = PlayerPrefs.GetString("mycard").Split(',');
            myNums = strs;
            for (int i = 0; i < strs.Length; i++)
            { 
                if (strs[i] != "-1")
                {
                    Sprite sprite = null;
                    foreach(var item in sprites)
                    {
                        if (strs[i] == item.name)
                        {
                            sprite = item;
                            break;
                        }
                    }
                    if(sprite!= null)
                    {
                        mycardImages[i].sprite = sprite;
                        mycardImages[i].color = new Color(1f,1f, 1f, 1f);
                    }
                    
                }
                else
                {
                    mycardImages[i].color = new Color(1f, 1f, 1f, 0.5f);
                }
            }
        }
    }

    
}
