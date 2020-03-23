using DapperDino.Inputs;
using DG.Tweening;
using UnityEngine;

namespace DapperDino.GettingStarted.Tweening
{
    public class TurnButton : MonoBehaviour
    {
        private bool isMyTurn = true;
        private bool isFlipping = false;

        private Controls controls;

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

            float rotation = isMyTurn ? 0f : 180f;
            float targetRotation = rotation == 0f ? 180f : 0f;

            var tweener = DOTween.To(() => rotation, x => rotation = x, targetRotation, 1f)
                .SetEase(Ease.OutBack)
                .OnStart(() => isFlipping = true)
                .OnUpdate(() => transform.eulerAngles = new Vector3(rotation, 0f, 0f))
                .OnComplete(() => isFlipping = false);

            isMyTurn = !isMyTurn;
        }
    }
}
