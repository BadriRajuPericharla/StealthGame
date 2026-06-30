using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    public Animator enemyAnimator;
    void Start()
    {
        enemyAnimator=GetComponent<Animator>();
    }
    public void PlayAttackAnimation()
    {
        enemyAnimator.SetTrigger("IsAttack");
    }
    public void PlayDeathAnimation()
    {
        enemyAnimator.SetTrigger("IsDie");
    }
}
