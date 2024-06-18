using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        UpdateAttackSpeed();
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
    }

    public override void Update()
    {
        base.Update();
    }

    private void UpdateAttackSpeed()
    {
        stateMachine.Player.Animator.SetFloat(
            stateMachine.Player.AnimationData.AttackSpeedParameterHash, 
            stateMachine.Player.Stat.AttackData.AtkSpeed
            );
    }
}