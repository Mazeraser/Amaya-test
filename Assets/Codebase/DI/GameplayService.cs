using System.Linq;
using Codebase.Data;
using Codebase.Factories;
using Codebase.View;
using UnityEngine;
using UnityEngine.UI;
using VContainer.Unity;

namespace Codebase.DI
{
    public class GameplayService : IStartable, IInitializable
    {
        private GridFactory _gridFactory;
        private GameobjectGridComponent _gameobjectGridComponent;
        private TaskFactory _taskFactory;
        private LevelData[] _levelData;
        private CardData _currentAnswer;
        private int _levelIndex = 0;
        private TaskViewComponent _taskViewComponent;
        private RestartViewComponent _restartViewComponent;

        private int LevelIndex
        {
            set
            {
                _levelIndex=value;
                if(_levelIndex<_levelData.Length)
                    GenerateLevel(false);
                else
                {
                    _gameobjectGridComponent.DeactivateGrid();
                    _restartViewComponent.UpdateView();
                }
            }
        }

        public GameplayService(GameobjectGridComponent gameobjectGridComponent,
                            TaskViewComponent taskViewComponent,
                            GridFactory gridFactory, 
                            TaskFactory taskFactory, 
                            LevelData[] levelData,
                            RestartViewComponent restartViewComponent)
        {
            _gameobjectGridComponent = gameobjectGridComponent;
            _gridFactory = gridFactory;
            _taskFactory = taskFactory;
            _levelData = levelData;
            _taskViewComponent = taskViewComponent;
            _restartViewComponent = restartViewComponent;
        }

        void IInitializable.Initialize()
        {
            CardViewComponent.CardHasClicked += CheckAnswer;
            CardViewComponent.RightChooseAnimationFinishedEvent += RaiseLevel;
            _restartViewComponent.ReloadGame += RestartGame;
        }
        void IStartable.Start()
        {
            GenerateLevel(true);
        }

        private void GenerateLevel(bool withBounce)
        {
            Debug.Log("Bounce: "+withBounce);
            _gameobjectGridComponent.GenerateGrid(_levelData[_levelIndex],withBounce);
            _currentAnswer = GenerateAnswer();
            _taskViewComponent?.SetNewCard(_currentAnswer);
        }

        private CardData GenerateAnswer()
        {
            CardData result = _taskFactory.Create(_levelData[_levelIndex].CardBundle);
            while (!_gridFactory.ExistingCards.Contains(result))
            {
                result = _taskFactory.Recreate(result, _levelData[_levelIndex].CardBundle);
            }
            return result;
        }

        private void RaiseLevel()
        {
            LevelIndex = _levelIndex + 1;
        }
        private bool CheckAnswer(CardData selected)
        {
            return (_currentAnswer.Value == selected.Value);
        }

        private void RestartGame()
        {
            LevelIndex = 0;
        }
    }
}