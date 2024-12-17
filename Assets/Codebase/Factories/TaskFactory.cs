using Codebase.Data;
using UnityEngine;
using System.Collections.Generic;

namespace Codebase.Factories
{
    public class TaskFactory : IFactory<CardData, CardBundleData>
    {
        private List<CardData> _usedCards = new List<CardData>();
        
        public CardData Create(CardBundleData property)
        {
            if (_usedCards.Count < property.Cards.Length)
            {
                CardData result;
                do
                {
                    result = property.Cards[Random.Range(0, property.Cards.Length)];
                } while (_usedCards.Contains(result));
                _usedCards.Add(result);
                return result;
            }
            else
            {
                Debug.LogError("All cards already used like answer");
                return null;
            }
        }

        public CardData Recreate(CardData  card, CardBundleData property)
        {
            _usedCards.Remove(card);
            return Create(property);
        }
    }
}

