using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Character
{
    private void Start()
    {
        Init();
        curHP = charData.HP;
    }

}
