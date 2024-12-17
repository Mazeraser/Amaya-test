using System;
using System.Collections;
using System.Collections.Generic;
using Codebase.Data;
using Codebase.Tweens;
using UnityEngine;

namespace Codebase.View
{
    public class CardViewComponent : MonoBehaviour, IViewComponent
    {
        public static event Predicate<CardData> CardHasClicked;
        public static event Action RightChooseAnimationFinishedEvent;
        
        private CardData _card;

        [SerializeField] 
        private SpriteRenderer _icon;
        [SerializeField] 
        private GameObject _iconObject;
        [SerializeField] 
        private ParticleSystem _rightChooseParticleSystem;

        public void SetCard(CardData card)
        {
            _card = card;
            UpdateView();
        }

        public void UpdateView()
        {
            _icon.sprite = _card.Icon;
        }

        private void OnMouseDown()
        {
            Debug.Log(CardHasClicked?.Invoke(_card));
            if (CardHasClicked?.Invoke(_card)??false)
            {
                _rightChooseParticleSystem?.Play();
                ITween bounceTween = _iconObject.AddComponent<Bounce>();
                bounceTween.Do(0.2f, 0.4f, () =>
                {
                    Destroy((Bounce)bounceTween);
                    RightChooseAnimationFinishedEvent?.Invoke();
                });
            }
            else
            {
                ITween easeInBounceTween = _iconObject.AddComponent<easeInBounce>();
                easeInBounceTween.Do(0.1f,0.2f,()=>Destroy((easeInBounce)easeInBounceTween));
            }
        }
    }
}
    
