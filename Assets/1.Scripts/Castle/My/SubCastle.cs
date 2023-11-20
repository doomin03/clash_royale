using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCastle : Castle
{
    // Start is called before the first frame update
    private void Start()
    {
        classData.finding = "enemy";
        classData.HP = 5000.0f;
        classData.damege = 50;
        classData.attackRange = 50;
        curHP = maxHP;
        curHP = classData.HP;

    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log(curHP);
        Attack();
    }
}
