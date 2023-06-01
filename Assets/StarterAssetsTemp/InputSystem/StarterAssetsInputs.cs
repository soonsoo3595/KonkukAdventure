using System;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class StarterAssetsInputs : MonoBehaviour
{
    PopupMgr popupMgr;

    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;

    [Header("Movement Settings")]
    public bool analogMovement;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;

    private void Awake()
    {
        GameManager.instance.enteringUI += Stop;
        GameManager.instance.exitUI += ReStart;
    }

    private void Start()
    {
        popupMgr = PopupMgr.instance;
    }

    /*
    private void Update()
    {
        if(!cursorLocked)
        {
            if(Input.GetMouseButtonDown(0))
            {
                cursorLocked = !cursorLocked;
                cursorInputForLook = !cursorInputForLook;

                SetCursorState(cursorLocked);
            }
        }
    }
    */

#if ENABLE_INPUT_SYSTEM
    public void OnMove(InputValue value)
    {
        if (popupMgr.IsPopupActive())
            return;

        MoveInput(value.Get<Vector2>());
    }

    public void OnLook(InputValue value)
    {
        if (cursorInputForLook)
        {
            LookInput(value.Get<Vector2>());
        }
    }
    public void OnJump(InputValue value)
    {
        JumpInput(value.isPressed);
    }

    public void OnSprint(InputValue value)
    {
        SprintInput(value.isPressed);
    }

    public void OnEscape(InputValue value)
    {
        cursorLocked = !cursorLocked;
        cursorInputForLook = !cursorInputForLook;

        SetCursorState(cursorLocked);
    }
#endif


    public void MoveInput(Vector2 newMoveDirection)
    {
        move = newMoveDirection;
    }

    public void LookInput(Vector2 newLookDirection)
    {
        look = newLookDirection;
    }

    public void JumpInput(bool newJumpState)
    {
        jump = newJumpState;
    }

    public void SprintInput(bool newSprintState)
    {
        sprint = newSprintState;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(cursorLocked);
    }

    public void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public void Stop()
    {
        if(popupMgr.IsPopupActive())
        {
            return;
        }

        cursorLocked = false;   
        cursorInputForLook = false; 
        LookInput(default);

        SetCursorState(cursorLocked);
    }

    public void ReStart()
    {
        if (popupMgr.IsPopupActive())
        {
            return;
        }

        cursorLocked = true;    
        cursorInputForLook = true; 

        SetCursorState(cursorLocked);
    }

    
}
	
