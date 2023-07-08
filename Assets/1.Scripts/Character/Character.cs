using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public struct CharactersData
{
    public float HP;
    public string finding;
    public float attRange;
    public float damege;
    public float attackSpeed;
}
public abstract class Character : MonoBehaviour
{
    public CharactersData charData = new CharactersData();
    [SerializeField]
    private Image HPImage;
    public Animator animator;
    public NavMeshAgent agent;
    public CardData cardData;
    private float delayTime;
    protected virtual void Init()
    {
        charData.HP = cardData.HP;
        charData.attRange = cardData.AttRange;
        agent.speed = cardData.Speed;
        charData.damege = cardData.Damage;
        charData.attRange = cardData.AttRange;
        charData.attackSpeed = cardData.AttackSpeed;
    }
    protected float curHP;
    public float HP { 
        get 
        {
            return curHP; 
        } 
        set
        {
            
            curHP -= value;
            HPImage.fillAmount = curHP/charData.HP;
            if(curHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
       
        GameObject[] characters = GameObject.FindGameObjectsWithTag(charData.finding);
        if (characters.Length == 0)
            return;
        float distanace = 100f;
        GameObject findTarget = null;
        foreach (GameObject character in characters)
        {
            float dis = Vector3.Distance(agent.transform.position, character.transform.position);
            if (distanace>dis)
            {
                findTarget = character;
                distanace = dis;
            }
        }
        if (findTarget == null)
        {
            return;
        }
        if(charData.attRange < distanace)
        {
            agent.SetDestination(findTarget.transform.position);
            animator.SetTrigger("run");
        }
        else
        {
            animator.SetTrigger("idle");
            agent.SetDestination(transform.position);
            delayTime += Time.deltaTime;
            if (delayTime >= charData.attackSpeed)
            {                               
                transform.LookAt(findTarget.transform.position);
                if (findTarget.GetComponent<Castle>())
                {
                    animator.SetTrigger("attack");
                    findTarget.GetComponent<Castle>().HP = charData.damege;
                }
                else  if (findTarget.GetComponent<MainCastle>())
                {
                    animator.SetTrigger("attack");
                    findTarget.GetComponent<MainCastle>().HP = charData.damege;
                }
                else if (findTarget.GetComponent<Character>())
                {
                    animator.SetTrigger("attack");
                    findTarget.GetComponent<Character>().HP = charData.damege;
                }

                if (findTarget.Equals("my"))
                {
                    if(findTarget.GetComponent<MainCastle>()) {
                        animator.SetTrigger("attack");
                        findTarget.GetComponent<MainCastle>().HP = charData.damege;
                    }
                }
                else if (charData.finding.Equals("enemy"))
                {
                    if (findTarget.GetComponent<EmeyCastle>())
                    {
                        animator.SetTrigger("attack");
                        findTarget.GetComponent<EmeyCastle>().HP = charData.damege;
                    }
                }

                delayTime = 0;
            }
            
        }
        
    }
   
    
}
