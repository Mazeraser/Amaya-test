using System;
using System.Collections;
using System.Collections.Generic;
using Codebase.Tweens;
using UnityEngine;
using UnityEngine.UI;

namespace  Codebase.View
{
    public class RestartViewComponent : MonoBehaviour, IViewComponent
    {
        public event Action ReloadGame;
        
        [SerializeField] 
        private Fade _restartButtonTween;
        [SerializeField] 
        private Button _restartButton;
        [SerializeField] 
        private Fade _backgroundTween;
        [SerializeField] 
        private Fade _loadscreenTween;
        
        public void UpdateView()
        {
            _restartButton.interactable = true;
            _backgroundTween.Do(1f, 0.5f, () => { });
            _restartButtonTween.Do(1f,0.5f, () => {Debug.Log("Game finished");});
        }

        private void Start()
        {
            _restartButton.onClick.AddListener(() => { StartCoroutine(RestartGame());});
        }

        private IEnumerator RestartGame()
        {
            _restartButtonTween.Do(0f,0.1f, () => {});
            _backgroundTween.Do(0f, 0.1f, () => {});
            _loadscreenTween.Do(1f,0.5f, () => {ReloadGame?.Invoke();});
            yield return new WaitForSeconds(1f);
            _loadscreenTween.Do(0f,0.5f, ()=>{
                _restartButton.interactable = false;
            });
        }
    }
}
    
