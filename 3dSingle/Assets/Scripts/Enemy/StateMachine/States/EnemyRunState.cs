﻿using UnityEngine;

public class EnemyRunState : EnemyBaseState
{
    public EnemyRunState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier *= 5f;
        StartAnimation(stateMachine.Enemy.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.RunParameterHash);
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
        Vector3 dir = (stateMachine.Target.transform.position - stateMachine.Enemy.transform.position).normalized;
        Vector3 dirOut = new Vector3(dir.x, 0, dir.z);
        return dirOut;
    }

    private void Rotate(Vector3 movementDir)
    {
        if (movementDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDir);
            stateMachine.Enemy.transform.rotation = Quaternion.Lerp(
                stateMachine.Enemy.transform.rotation,
                targetRotation,
                stateMachine.RotationDamping * Time.fixedDeltaTime
                );
        }
    }

    private void Move(Vector3 movementDir)
    {
        float movementSpeed = GetMovementSpeed();
        stateMachine.Enemy.Rigidbody.velocity = movementDir * movementSpeed;
    }

    private float GetMovementSpeed()
    {
        return stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
    }
}
