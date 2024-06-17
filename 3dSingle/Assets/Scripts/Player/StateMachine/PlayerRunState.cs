using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier *= 10;
        StartAnimation(stateMachine.Player.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.RunParameterHash);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Move();
    }

    private void Move()
    {
        Vector3 movementDir = GetMovementDirection();
        Rotate(movementDir);
        Move(movementDir);
    }

    private Vector3 GetMovementDirection()
    {
        return (stateMachine.Target.transform.position - stateMachine.Player.transform.position).normalized;
    }

    private void Rotate(Vector3 movementDir)
    {
        if (movementDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDir);
            stateMachine.Player.transform.rotation = Quaternion.Lerp(
                stateMachine.Player.transform.rotation,
                targetRotation,
                stateMachine.RotationDamping * Time.fixedDeltaTime
                );
        }
    }

    private void Move(Vector3 movementDir)
    {
        float movementSpeed = GetMovementSpeed();
        stateMachine.Player.Rigidbody.velocity = movementDir * movementSpeed;
    }

    private float GetMovementSpeed()
    {
        return stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
    }
}