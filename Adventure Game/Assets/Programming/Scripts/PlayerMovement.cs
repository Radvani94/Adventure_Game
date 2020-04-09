using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Input Actions
    PlayerInputActions inputAction;

    //Move
    Vector2 movementInput;

   private void Awake() 
   {

    inputAction = new PlayerInputActions();
    inputAction.Gameplay.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();

   }

   private void FixedUpdate() 
   {

      float x = movementInput.x;
      float y = movementInput.y;
   }

   void OnEnable() 
   {

    inputAction.Gameplay.Enable();

   }

   void OnDisable() 
   {

    inputAction.Gameplay.Disable();

   }
}
