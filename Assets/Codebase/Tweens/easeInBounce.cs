using System;
using DG.Tweening;
using UnityEngine;

namespace Codebase.Tweens
{
    public class easeInBounce : MonoBehaviour, ITween
    {
        public void Do(float value, float duration, Action onComplete)
        {
            float startPosition = transform.position.x;
            DOTween.Sequence()
                .Append(transform.DOMoveX(startPosition - value, duration))
                .Append(transform.DOMoveX(startPosition + value, duration))
                .Append(transform.DOMoveX(startPosition, duration))
                .OnComplete(()=>onComplete?.Invoke());
        }
    }
}
    
