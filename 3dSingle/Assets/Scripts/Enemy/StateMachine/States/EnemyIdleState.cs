using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    private float updateDelay = 0.5f;
    private float timer = 0f;

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.IdleParameterHash);
    }

    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (timer > updateDelay)
        {
            if (IsTargetOn())
                stateMachine.ChangeState(stateMachine.RunState);

            timer = 0f;
        }
    }

    private bool IsTargetOn()
    {
        return stateMachine.Target == null ? false : true;
    }
}
