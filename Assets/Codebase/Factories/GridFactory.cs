using System.Collections.Generic;
using System.Linq;
using Codebase.Data;
using Codebase.Tweens;
using Codebase.View;
using UnityEngine;
using VContainer;

namespace Codebase.Factories
{
    public class GridFactory : MonoBehaviour, IFactory<GameObject, CardBundleData>
    {
        [SerializeField] 
        private Transform _parentGrid;
        [SerializeField] 
        private GameObject _cardPrefab;

        private List<CardData> _existingCards = new List<CardData>();
        public CardData[] ExistingCards => _existingCards.ToArray();
        
        public GameObject Create(CardBundleData property)
        {
            GameObject result = Instantiate(_cardPrefab, _parentGrid);
            if (_existingCards.Count < property.Cards.Length)
            {
                CardData card;
                do
                {
                    card = property.Cards[Random.Range(0, property.Cards.Length)];
                } while (_existingCards.Contains(card));
                _existingCards.Add(card);
                result.GetComponent<CardViewComponent>().SetCard(card);
                return result;
            }
            else
            {
                Destroy(result);
                Debug.LogError("All cards already created");
                return null;
            }
        }

        public void Clear()
        {
            _existingCards = new List<CardData>();
        }
    }
}