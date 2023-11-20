using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public struct ClassData
{
    public string finding;
    public float HP;
    public float damege;
    public float attackRange;
}
public class Castle : MonoBehaviour
{
    [SerializeField]
    private Image MyHPImage;

    public ClassData classData = new ClassData();

    protected float maxHP = 0;
    protected float curHP = 0;

    private float delayTime;

    public float HP
    {
        get
        {
            return curHP;
        }
        set
        {
            curHP -= value;
            MyHPImage.fillAmount = curHP / maxHP;
            Die(curHP);
        }
    }





    public void Attack()
    {
        //GameObject[] characters = GameObject.FindGameObjectsWithTag(classData.finding);
        //if (characters.Length == 0)
        //    return;

        //float distanace = 100f;
        //GameObject findTarget = null;
        //foreach (GameObject character in characters)
        //{
        //    float dis = Vector3.Distance(transform.position, character.transform.position);
        //    if (distanace > dis)
        //    {
        //        findTarget = character;
        //        distanace = dis;
        //    }
        //}
        //if (findTarget == null)
        //{
        //    return;
        //}

        //if (classData.attackRange >= distanace)
        //{
        //    delayTime += Time.deltaTime;

        //    if (delayTime >= 1)
        //    {
        //        if (findTarget.GetComponent<Character>())
        //        {
        //            findTarget.GetComponent<Character>().HP = classData.damege;
        //            delayTime = 0;
        //        }
        //    }

        //}
    }
    private void Die(float curHP)
    {
        if (curHP < 0.0f)
            Destroy(gameObject);
    }




}




