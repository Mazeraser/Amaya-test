using UnityEngine;
using Codebase.Data;
using Codebase.Factories;
using Codebase.Tweens;
using VContainer;

namespace Codebase.View
{
    public class GameobjectGridComponent : MonoBehaviour 
    {
        private GameObject [,] grid;
        private GridFactory _gridFactory;
        [SerializeField] 
        private float _spacing;

        [Inject]
        private void Construct(GridFactory gridFactory)
        {
            _gridFactory = gridFactory;
        }

        public void GenerateGrid(LevelData levelData, bool bounce=false)
        {
            if (grid != null)
                ClearGrid();
            grid = new GameObject[levelData.Columns, levelData.Rows];
            float yPos = levelData.Rows/(-2)*_spacing;
            for(int y = 0; y < levelData.Rows; y++)
            {
                float xPos = levelData.Columns/(-2)*_spacing;
                for(int x = 0; x < levelData.Columns; x++)
                {
                    GameObject card = _gridFactory.Create(levelData.CardBundle);
                    if (bounce)
                    {
                        ITween bounceTween = card.AddComponent<Bounce>();
                        bounceTween.Do(0.2f,0.4f,()=>Destroy((Bounce)bounceTween));
                    }
                    
                    card.transform.position = new Vector3(card.transform.position.x + xPos,
                        card.transform.position.y + yPos,
                        card.transform.position.z);
                    grid[x,y] = card;

                    xPos += _spacing;
                    xPos = Mathf.Round( xPos / _spacing) * _spacing;
                }
                yPos += _spacing;
                yPos = Mathf.Round( yPos / _spacing) * _spacing;
            }
        }

        private void ClearGrid()
        {
            _gridFactory.Clear();
            foreach (var row in grid)
            {
                foreach (var cell in grid)
                {
                    Destroy(cell);
                }
            }
        }

        public void DeactivateGrid()
        {
            foreach (var row in grid)
            {
                foreach (var cell in grid)
                {
                    cell.GetComponent<Collider2D>().enabled = false;
                }
            }
        }
    }
}