using UnityEngine;
using UnityEngine.InputSystem;
    public class InputHandler : MonoBehaviour
    {
        public Vector2 move,look;
        public bool jump, sprint, interaction;
        public float zoom;
        private bool cursorLocked = true;
        private bool cursorInputForLook = true;
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}
		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
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
        public void OnZoom(InputValue value)
        {
            zoom = value.Get<float>();
        }
    	public void OnInteraction(InputValue value)
		{
			InteractionInput(value.isPressed);
		}
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
        public void ZoomInput(float newZoomValue)
        {
            zoom = newZoomValue;
        }
        public void InteractionInput(bool newInteractionState)
        {
            interaction = newInteractionState;
        } 
    private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }
        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }