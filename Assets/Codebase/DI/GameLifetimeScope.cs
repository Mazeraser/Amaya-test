using Codebase.Data;
using Codebase.Factories;
using Codebase.View;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace  Codebase.DI
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] 
        private LevelData[] _levelData;

        [SerializeField] 
        private GridFactory _gridFactory;
        [SerializeField] 
        private GameobjectGridComponent _gameobjectGridComponent;
        [SerializeField]
        private TaskViewComponent _taskViewComponent;
        [SerializeField] 
        private RestartViewComponent _restartViewComponent;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_levelData);
            builder.Register<TaskFactory>(Lifetime.Singleton);
            builder.RegisterComponent(_gridFactory);
            builder.RegisterComponent(_gameobjectGridComponent);
            builder.RegisterComponent(_taskViewComponent);
            builder.RegisterComponent(_restartViewComponent);
            builder.RegisterEntryPoint<GameplayService>();
        }
    }
}
    
