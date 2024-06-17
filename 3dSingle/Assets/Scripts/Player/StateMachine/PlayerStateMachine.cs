using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }
    public GameObject Target {  get; private set; }
    // States �߰�
    public PlayerIdleState IdleState { get; private set; }
    public PlayerIntroState IntroState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    // ����
    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    public float RotationDamping { get; private set; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;
        // ���Ŀ� ���� ����� ���� Target���� �����ϴ� ���� �߰�
        Target = GameObject.FindGameObjectWithTag("Enemy");

        MovementSpeed = player.Stat.BaseMoveSpeed;
        RotationDamping = player.Stat.RotationDamping;

        // Status�߰�
        IntroState = new PlayerIntroState(this);
        IdleState = new PlayerIdleState(this);
        RunState = new PlayerRunState(this);

    }
}
