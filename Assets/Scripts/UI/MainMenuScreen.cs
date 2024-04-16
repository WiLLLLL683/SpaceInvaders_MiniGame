using UnityEngine;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    public void Show()
    {
        canvas.enabled = true;
    }

    public void Hide()
    {
        canvas.enabled = false;
    }
}
