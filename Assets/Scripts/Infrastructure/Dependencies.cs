using System.Collections.Generic;

namespace SpaceInvadersMiniGame
{
    /// <summary>
    /// Container for all mini-game dependencies.
    /// Used in MiniGame class and state machine only.
    /// TODO change to proper DIContainer.
    /// </summary>
    public class Dependencies
    {
        //factories
        public PlayerFactory PlayerFactory;
        public BulletFactory BulletFactory;
        public EnemyFactory EnemyFactory;
        //persistent data
        public MiniGameData GameData;
        public EnemiesData EnemiesData;
        //components from prefab
        public GameScreen GameScreen;
        public PlayerInput Input;
        //config
        public PlayerConfig PlayerConfig;
        public List<LevelConfig> LevelsConfig;
    }
}