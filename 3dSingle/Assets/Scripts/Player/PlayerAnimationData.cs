using System;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string introParameterName = "Intro";
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string runParameterName = "Run";

    [SerializeField] private string attackParameterName = "@Attack";
    [SerializeField] private string attackSpeedParameterName = "AttackSpeed";
    [SerializeField] private string skillParameterName = "Skill";
    [SerializeField] private string skillIdxParameterName = "SkillIdx";
    // 스킬 제작 시 Animator 추가

    public int IntroParameterHash { get; private set; }
    public int IdleParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    
    public int AttackParameterHash { get; private set; }
    public int AttackSpeedParameterHash { get; private set; }
    public int SkillParameterHash { get; private set; }
    public int SkillIdxParameterHash { get; private set; }


    public void Initialize()
    {
        IntroParameterHash = Animator.StringToHash(introParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
        AttackSpeedParameterHash = Animator.StringToHash(attackSpeedParameterName);

        SkillParameterHash = Animator.StringToHash(skillParameterName);
        SkillIdxParameterHash = Animator.StringToHash(skillIdxParameterName);
    }
}