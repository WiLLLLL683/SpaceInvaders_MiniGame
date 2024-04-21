using SpaceInvadersMiniGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private MiniGame miniGame;

    private void Awake()
    {
        miniGame.Enable();
        miniGame.OnDisable += Quit;
    }

    private void Quit()
    {
        miniGame.OnDisable -= Quit;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
