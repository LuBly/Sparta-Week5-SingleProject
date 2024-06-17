using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Characters/Enemy")]

public class EnemySO : ScriptableObject
{
    [field: SerializeField] public float BaseMoveSpeed { get; private set; } = 3f;
    [field: SerializeField] public float RotationDamping { get; private set; } = 8f;
    [field: SerializeField] public EnemyAttackData AttackData { get; private set; }
}

[Serializable]
public class EnemyAttackData
{
    [field: SerializeField] public float AtkRange { get; private set; }
    [field: SerializeField] public float AtkDamage { get; private set; }
}