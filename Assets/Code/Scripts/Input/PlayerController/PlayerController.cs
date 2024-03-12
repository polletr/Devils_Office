using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

//[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(InputManager))]
public class PlayerController : MonoBehaviour
{
        /*public PlayerState State { get; private set; }
        public PlayerStateType StateType;

        private Dictionary<PlayerStateType, PlayerState> playerStates;*/
        public BaseState currentState;

        //private InputManager inputManager;

        private Vector2 _moveInput;

        public Vector3 Position => transform.position;

        public Rigidbody2D _rb;
        private Collider2D _collider;

        [HideInInspector]
        public Animator anim;

        private void Awake()
        {
            ChangeState(new IdleState());

        }
        private void Update()
        {
            currentState?.StateUpdate();
        }
        private void FixedUpdate()
        {
            currentState?.StateFixedUpdate();
        }

        public void ChangeState(BaseState newState)
        {
            StartCoroutine(WaitFixedFrame(newState));
        }

        private IEnumerator WaitFixedFrame(BaseState newState)
        {

            yield return new WaitForFixedUpdate();
            currentState?.ExitState();
            currentState = newState;
            currentState.player = this;
            //currentState.inputManager = inputManager;
            currentState.EnterState();

        }

        #region Player Actions
/*        public void HandleJump()
        {
            currentState?.HandleJump();
        }
*/
        

        #endregion

}
