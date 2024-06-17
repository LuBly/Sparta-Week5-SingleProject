using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    private float updateDelay = 0.5f;
    private float timer = 0f;
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.IdleParameterHash);
    }

    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if(timer > updateDelay)
        {
            if (IsTargetOn())
                stateMachine.ChangeState(stateMachine.RunState);

            timer = 0f;
        }
    }

    public bool IsTargetOn()
    {
        return stateMachine.Target == null ? false : true;
    }
}