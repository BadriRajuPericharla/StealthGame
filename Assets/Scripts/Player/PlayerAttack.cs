using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerMovement player;
    void Start()
    {
        player=GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.playerAnimations.PlayAttackAnimation();
        }
    }
}
