using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float moveSpeed = 1;
    public float lookRange = 20f;
    public float lookSphereCastRadius = 2f;

    public float attackRange = 3f;
    public float attackRate = 0.5f;
    public float attackForce = 1f;
    public int attackDamage = 5;

    public int initHealth = 10;

    public float searchDuration = 4f;
    public float searchingTurnSpeed = 120f;

	public string type;
}