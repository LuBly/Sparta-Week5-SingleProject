public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;
    protected EnemySO enemyStat;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        enemyStat = stateMachine.Enemy.Stat;
    }
    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {

    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.Enemy.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Enemy.Animator.SetBool(animationHash, false);
    }
}
