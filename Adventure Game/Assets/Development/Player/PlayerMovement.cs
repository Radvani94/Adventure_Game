using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameSpace
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;
        public Camera mainCamera;
        public Text InteractableText;
        private int interactableScore = 0;
        public float speed = 12f;
        public float gravity = -9.81f;
        public float jumpHeight = 3f;
        public float movementSmoothingX = 0.15f;
        public float movementSmoothingY = 0.15f;
        public Vector2 movement = Vector2.zero;
        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;
        public float InteractableDistance = 10f;
        public Vector3 velocity;
        bool isGrounded;

        // Update is called once per frame
        void Update()
        {
            //////////////////////////////////////////////////////////////////////////////////////////
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            movement.x = Mathf.SmoothDamp(movement.x, Input.GetAxisRaw("Horizontal"), ref movement.x, movementSmoothingX);
            movement.y = Mathf.SmoothDamp(movement.y, Input.GetAxisRaw("Vertical"), ref movement.y, movementSmoothingY);

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            Vector3 move = transform.right * movement.x + transform.forward * movement.y;

            controller.Move(move * speed * Time.deltaTime);

            ///////////////////////////////////////////////////////////////////////////////////////

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            /////////////////////////////////////////////////////////////////////////////////////

            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                float distanceToInteractable = hit.distance;
                if (hit.transform.CompareTag("Interactable"))
                {
                    if (distanceToInteractable < InteractableDistance)
                    {
                        if (Input.GetKeyUp(KeyCode.E))
                        {
                            InteractableText.text = (interactableScore++).ToString();
                            Game.Instance.ScoreNow = interactableScore;
                            Debug.Log("In Range");
                        }
                    }
                }
            }
        }
    }
}
