using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace DapperDino.GettingStarted.Tweening
{
    public class TurnButton : MonoBehaviour
    {
        private bool isMyTurn = true;
        private bool isFlipping = false;

        private void OnMouseDown() => TryChangeTurn();

        private void TryChangeTurn()
        {
            if (isFlipping) { return; }

            StartCoroutine(ChangeTurn());
        }

        private IEnumerator ChangeTurn()
        {
            isFlipping = true;

            isMyTurn = !isMyTurn;

            float rotation = isMyTurn ? 0f : 180f;
            float targetRotation = rotation == 0f ? 180f : 0f;

            var tweener = DOTween.To(() => rotation, x => rotation = x, targetRotation, 1f)
                .SetEase(Ease.OutBack)
                .OnUpdate(() => transform.eulerAngles = new Vector3(rotation, 0f, 0f));

            while (tweener.IsActive()) { yield return null; }

            isFlipping = false;
        }
    }
}
