using DG.Tweening;
using System;
using UnityEngine;

namespace Codebase.Tweens
{
	[RequireComponent(typeof(CanvasGroup))]
	public class Fade : MonoBehaviour, ITween
	{
	    [SerializeField]
	    private CanvasGroup _group;

	    public void Do(float value, float duration, Action onComplete)
	    {
		    _group.DOFade(value, duration).OnComplete(
			    () => onComplete?.Invoke()
		    );
	    }
	}
}