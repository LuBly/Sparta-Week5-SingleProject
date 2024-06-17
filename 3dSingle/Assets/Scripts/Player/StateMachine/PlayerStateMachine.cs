using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }
    public GameObject Target {  get; private set; }
    // States 추가
    public PlayerIdleState IdleState { get; private set; }
    public PlayerIntroState IntroState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    // 구현
    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    public float RotationDamping { get; private set; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;
        // 차후에 가장 가까운 적을 Target으로 변경하는 로직 추가
        Target = GameObject.FindGameObjectWithTag("Enemy");

        MovementSpeed = player.Stat.BaseMoveSpeed;
        RotationDamping = player.Stat.RotationDamping;

        // Status추가
        IntroState = new PlayerIntroState(this);
        IdleState = new PlayerIdleState(this);
        RunState = new PlayerRunState(this);

    }
}
