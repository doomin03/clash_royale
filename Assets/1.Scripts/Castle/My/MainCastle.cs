using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class MainCastle : Castle
{
    private void Start()
    {
        classData.isMain = true;
        classData.finding = "enemy";
        classData.hP = 3500;
        classData.damege = 150;
        classData.attackRange = 80;
        maxHP = classData.hP;
        curHP = maxHP;
    }


    private void Update()
    {
        if (curHP <= maxHP)
        {
            Attack();
        }
        
    }
}
