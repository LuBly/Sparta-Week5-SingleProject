using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }
    public GameObject Target { get; private set; }
    // States 추가
    public EnemyIdleState IdleState { get; private set; }
    public EnemyRunState RunState { get; private set; }

    // 구현
    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    public float RotationDamping { get; private set; }

    public EnemyStateMachine(Enemy enemy)
    {
        Enemy = enemy;
        
        Target = GameObject.FindGameObjectWithTag("Player");

        MovementSpeed = Enemy.Stat.BaseMoveSpeed;
        RotationDamping = Enemy.Stat.RotationDamping;

        // Status추가
        IdleState = new EnemyIdleState(this);
        RunState = new EnemyRunState(this);
    }
}
