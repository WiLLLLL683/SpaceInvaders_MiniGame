using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Transform playerSpawnPoint;

        public Transform PlayerSpawnPoint => playerSpawnPoint;

        public void Show()
        {
            canvas.enabled = true;
        }

        public void Hide()
        {
            canvas.enabled = false;
        }
    }
}