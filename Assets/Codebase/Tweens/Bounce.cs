using System;
using DG.Tweening;
using UnityEngine;

namespace Codebase.Tweens
{
    public class Bounce : MonoBehaviour, ITween
    {
        public void Do(float value, float duration, Action onComplete)
        {
            Vector3 scale = transform.localScale;
            DOTween.Sequence()
                .Append(transform.DOScale(scale * (1+value), duration))
                .Append(transform.DOScale(scale * (1-value), duration))
                .Append(transform.DOScale(scale, duration))
                .OnComplete(
                    () => onComplete?.Invoke()
                );
        }
    }
}
