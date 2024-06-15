using UnityEngine;

public class PlayerNewAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    PlayerNew player;

    private Animator animator;

    private void Awake()
    {
        player = GetComponentInParent<PlayerNew>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking);
    }
}
