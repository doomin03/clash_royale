using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCastle : Castle
{
    // Start is called before the first frame update
    void Start()
    {
        classData.isMain = false;
        classData.finding = "enemy";
        classData.hP = 2000f;
        classData.damege = 100;
        classData.attackRange = 80;
        maxHP = classData.hP;
        curHP = maxHP;
    }

    private void Update()
    {
        Attack();
    }
}
