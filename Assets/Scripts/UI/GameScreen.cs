using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceInvadersMiniGame
{
    public class GameScreen : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Canvas canvas;
        [SerializeField] private TMP_Text levelNameText;
        [SerializeField] private TMP_Text controlsText;
        [Header("Parents")]
        [SerializeField] private Transform playerParent;
        [SerializeField] private Transform enemiesParent;
        [SerializeField] private Transform bulletParent;
        [Header("Spawn points")]
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private List<Transform> enemySpawnPoints;

        public Transform PlayerParent => playerParent;
        public Transform EnemiesParent => enemiesParent;
        public Transform BulletParent => bulletParent;
        public Transform PlayerSpawnPoint => playerSpawnPoint;
        public List<Transform> EnemySpawnPoints => enemySpawnPoints;

        private MiniGame miniGame;
        private PlayerInput input;

        public void Init(MiniGame miniGame, PlayerInput input)
        {
            this.miniGame = miniGame;
            this.input = input;

            miniGame.OnEnable += Show;
            miniGame.OnDisable += Hide;
            miniGame.OnLevelStarted += SetLevelName;
        }

        private void OnDestroy()
        {
            miniGame.OnEnable -= Show;
            miniGame.OnDisable -= Hide;
            miniGame.OnLevelStarted -= SetLevelName;
        }

        public void Show()
        {
            canvas.enabled = true;
            SetControlsText();
        }

        public void Hide()
        {
            canvas.enabled = false;
        }

        public void SetLevelName(LevelConfig level)
        {
            levelNameText.text = level.LevelName;
        }

        public void SetControlsText()
        {
            //TODO show active control scheme
            InputAction moveAction = input.Actions.MiniGame.Movement;
            string moveBindings = moveAction.GetBindingDisplayString();
            moveBindings = moveBindings.Split(" |")[0];
            InputAction attackAction = input.Actions.MiniGame.Attack;
            string attackBindings = attackAction.GetBindingDisplayString();
            attackBindings = attackBindings.Split(" |")[0];
            controlsText.text = $"Move: {moveBindings} | Attack: {attackBindings}";
        }
    }
}