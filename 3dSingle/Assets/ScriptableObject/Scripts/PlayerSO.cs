using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]

public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public float BaseMoveSpeed { get; private set; } = 5f;
    [field: SerializeField] public float RotationDamping { get; private set; } = 8f;
    [field: SerializeField] public PlayerAttackData AttackData { get; private set; }
}

[Serializable]
public class PlayerAttackData
{
    [field: SerializeField] public string AtkName { get; private set; }
    [field: SerializeField] public int AtkIdx {  get; private set; }
    [field: SerializeField] public float AtkRange { get; private set; }
    [field: SerializeField] public float AtkDamage { get; private set; }
    [field: SerializeField][field: Range(1f,3f)] public float AtkSpeed { get; private set; }
}