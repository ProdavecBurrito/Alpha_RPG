using UnityEngine;

public class UnitAnimationsController
{
    private Animator _unitAnimator;

    public void Init(Animator animator)
    {
        _unitAnimator = animator;
    }

    public void PlayAnimation(string animationName)
    {
        _unitAnimator.Play(animationName);
    }

    public void SetBool(string animationName, bool flag)
    {
        _unitAnimator.SetBool(animationName, flag);
    }

    public void CheckWalkState(bool isWalk)
    {
        if (isWalk)
        {
            SetBool("Walk", true);
        }
        else
        {
            SetBool("Walk", false);
        }
    }
}