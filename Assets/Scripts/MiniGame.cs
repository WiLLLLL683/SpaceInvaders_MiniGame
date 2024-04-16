using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private MainMenuScreen mainMenuScreen;
    [SerializeField] private GameScreen gameScreen;

    public void LaunchGame()
    {
        gameScreen.Hide();
        mainMenuScreen.Show();
        // TODO: Add your implementation
    }
}
