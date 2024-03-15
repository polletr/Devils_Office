using UnityEngine;

    public abstract class BaseState
    {

        protected float nextDirection;

        public PlayerController player { get; set; }
        public InputManager inputManager { get; set; }

        protected BaseState currentState;

        public virtual void EnterState() { }
        public virtual void ExitState() { }
        public virtual void StateFixedUpdate() { }
        public virtual void StateUpdate() { }
        public virtual void HandleMovement() { }
        public virtual void HandleRotation(float rotateAngle) { }
        public virtual void StopInteract() { }

    }
