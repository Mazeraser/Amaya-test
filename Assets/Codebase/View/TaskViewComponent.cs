using System;
using System.Collections;
using System.Collections.Generic;
using Codebase.Data;
using Codebase.Tweens;
using TMPro;
using UnityEngine;

namespace Codebase.View
{
    public class TaskViewComponent : MonoBehaviour
    {
        private CardData _currentAnswer;
        [SerializeField] 
        private TMP_Text _textField;

        public void SetNewCard(CardData newAnswer)
        {
            _currentAnswer = newAnswer;
            _textField.text = "Find " + newAnswer.Value;
        }
        
        private void Start()
        {
            GetComponent<ITween>().Do(1f,1f,()=>{Debug.Log("Fade in has performed");});
        }
    }
}