using DapperDino.Inputs;
using UnityEngine;

namespace DapperDino.GettingStarted.Animators
{
    public class TurnButtonAnim : MonoBehaviour
    {
        [SerializeField] private Animator animator = null;

        private bool isFlipping = false;

        private Controls controls;

        private static readonly int hashFlipButton = Animator.StringToHash("FlipButton");

        private void Awake()
        {
            controls = new Controls();
            controls.Player.ChangeTurn.performed += ctx => FlipButton();
        }

        private void OnEnable() => controls.Enable();
        private void OnDisable() => controls.Disable();

        private void OnMouseDown()
        {
            FlipButton();
        }

        private void FlipButton()
        {
            if (isFlipping) { return; }

            animator.SetTrigger(hashFlipButton);

            isFlipping = true;
        }

        public void FinishFlipping() => isFlipping = false;
    }
}
