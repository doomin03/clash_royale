using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySubCastle : Castle
{
     private void Start()
    {
        classData.finding = "my";
        classData.HP = 5000.0f;
        classData.damege = 0;
        classData.attackRange = 50;
        maxHP = classData.HP;
        curHP = maxHP;

    }


    // Update is called once per frame
    void Update()
    {
        Attack();
    }
}
