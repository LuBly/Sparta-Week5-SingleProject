using UnityEngine;

public class PlayerIntroState : PlayerBaseState
{
    public PlayerIntroState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.IntroParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.IntroParameterHash);
    }
    
    private void OnIdleState()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }
}