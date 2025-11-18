using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public GameManager gm;
    public InputSystem_Actions inputs;
    public Action<Vector2> OnMoveChange;
    public Action OnJumpPerformed;
    public Action OnAttackPerformed;
    public Action OnDead;
    public bool isAttack;
    private Vector2 moveInput;
    public int PlayerHealth = 5;
    private void Awake()
    {
        inputs = new();
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Move.started += OnMove;
        inputs.Player.Move.performed += OnMove;
        inputs.Player.Move.canceled += OnMove;

        inputs.Player.Jump.performed += OnJump;

        inputs.Player.Attack.performed += OnAttack;

    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isAttack = true;           
            Debug.Log("Attacoo!");
            OnAttackPerformed?.Invoke();
        }
        else 
        {
            
            isAttack = false;
        }

    }

    private void OnJump(InputAction.CallbackContext context)
    {
        OnJumpPerformed?.Invoke();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        OnMoveChange?.Invoke(moveInput);
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    void Start()
    {
        
    }
    public Vector2 MoveInput => moveInput;
    public void Update()
    {
        PlayerDead();
    }
    public void PlayerDead()
    {
        gm.TestRestHealh();
        if(PlayerHealth <= 0)
        {
            OnDead?.Invoke();
            Debug.Log("Player Dead");
            
        }
    }
}
