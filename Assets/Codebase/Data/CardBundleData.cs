using System;
using UnityEngine;

namespace Codebase.Data
{
    [CreateAssetMenu(fileName = "New card bundle", menuName = "Card bundle", order = 0)]
    public class CardBundleData : ScriptableObject
    {
        [SerializeField] 
        private CardData[] _cards;

        public CardData[] Cards => _cards;
    }
}