using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyUnit")]
public class EnemyUnit : ScriptableObject
{
    //Basic
    public Sprite ArtWork;
    public float Speed;
    public float Value;
    public float SizeX;
    public float SizeY;

    //Behavior
    public bool CanChasingPlayer;
    public bool CanAttack;

    //Attack Varibles
    public float DisToAttack;
    public float AttackCoolDown;
    public GameObject Bullet;
}
