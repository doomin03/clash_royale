using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="CardData",menuName ="MyCardData/CardData")]
public class CardData : ScriptableObject
{
    [SerializeField] Character character;
    public Character Char { get { return character; } }

    [SerializeField] Sprite charImage;
    public Sprite CharImage { get { return charImage; } }

    [SerializeField] float hp;
    public float HP { get { return hp; } }

    [SerializeField] float damage;
    public float Damage { get { return damage; } }

    [SerializeField] int speed;
    public int Speed { get { return speed; } }

    [SerializeField] int cost;
    public int Cost { get { return cost; } }
    [SerializeField] float attRange;
    public float AttRange { get { return attRange; } }
    [SerializeField] float attackSpeed;
    public float AttackSpeed { get { return attackSpeed; } }

}
