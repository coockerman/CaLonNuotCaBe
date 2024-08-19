using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int scoreGet = 2;
    [SerializeField] int tuVi = 3;
    [SerializeField] int damage = 1;
    public int ScoreGet { get { return scoreGet; } }
    public int TuVi { get {  return tuVi; } }
    public int Damage { get { return damage; } }
    public void EnemyDie()
    {
        Destroy(gameObject);
    }
    public void EnemyNotActive()
    {
        damage = 0;
    }

}
