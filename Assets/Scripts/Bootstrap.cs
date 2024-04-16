using SpaceInvadersMiniGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private MiniGame miniGame;

    private void Awake()
    {
        miniGame.Launch();
    }
}
