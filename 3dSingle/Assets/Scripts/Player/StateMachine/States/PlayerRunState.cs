﻿using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    private float updateDelay = 0.5f;
    private float timer = 0f;
    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier *= 5f;
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
        timer += Time.deltaTime;
        if (timer > updateDelay)
        {
            if (IsTargetInRange())
                stateMachine.ChangeState(stateMachine.AttackState);

            timer = 0f;
        }
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
        Vector3 dir = (stateMachine.Target.transform.position - stateMachine.Player.transform.position).normalized;
        Vector3 dirOut = new Vector3(dir.x, 0, dir.z);
        return dirOut;
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

    private bool IsTargetInRange()
    {
        float dist = Vector3.Distance(stateMachine.Target.transform.position, stateMachine.Player.transform.position);
        return dist < stateMachine.Player.Stat.AttackData.AtkRange;
    }
}