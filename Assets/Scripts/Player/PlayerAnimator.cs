using System.Security.Cryptography;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private AnimatorStateInfo animatorStateInfo;
    public AnimatorStateInfo AnimatorStateInfo { get => animatorStateInfo; private set => animatorStateInfo = value; }


    public void TriggerDieAnimation()
    {
        animator.SetTrigger("Die");
    }

    public void TriggerJumpAnimation()
    {
        animator.SetTrigger("Jump");
    }

    public void SetFlyingAnimation(bool value)
    {
        animator.SetBool("IsFlying", value);
    }

    public void SetWalkingAnimation(bool value)
    {
        animator.SetBool("IsWalking", value);
    }

    public void FlipSpriteXAxis(bool flip)
    {
        spriteRenderer.flipX = flip;
    }

    private void Update()
    {
        AnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
    }
}
