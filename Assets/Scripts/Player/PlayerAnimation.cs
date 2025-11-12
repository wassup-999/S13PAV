using System;

using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimation : MonoBehaviour 
{
    public Animator controller;
    public SpriteRenderer sprite;
    public bool IsMoving;
    
    private void Awake()
    {
        controller = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();    
    }
    void Start()
    {
        PlayerController.Instance.InputManager.OnMoveChange += SetMoveAnimation;
        PlayerController.Instance.InputManager.OnJumpPerformed += SetJumpAnimation;
        PlayerController.Instance.InputManager.OnAttackPerformed += SetAttackAnimation;
    }

    private void SetAttackAnimation()
    {
        
        
    }

    private void Update()
    {
        SetAttackAnimation();
        SetGroundedState();
    }
    public void SetGroundedState()
    {
        bool isGrounded =  PlayerController.Instance.playerMovement.IsGrounded;
        controller.SetBool("IsGrounded",isGrounded);
    }
    private void SetJumpAnimation()
    {
        controller.SetTrigger("OnJump");
        print("Jump");
    }

    private void SetMoveAnimation(Vector2 vector)
    {
        print(vector); 

        if(vector.x != 0 )
            controller.SetBool("isMoving", true);
        else
            controller.SetBool("isMoving", false);

        if(vector.x < 0)
            sprite.flipX = true;

        if(vector.x > 0)
            sprite.flipX = false;
    }

    
  


}
