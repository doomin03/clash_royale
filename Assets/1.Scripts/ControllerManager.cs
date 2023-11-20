using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager Instance;

    public UIController uiCont;
    public CardController cardCont;
    public DataContoller dataCont;
    public NextCard nextCard;
   
    private void Awake() 
    { 
        Instance = this;
        
        dataCont.Init();
        nextCard.Init();
    
    } 
}
