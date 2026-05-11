using UnityEngine;

public class UIWindow : MonoBehaviour
{
    [SerializeField] private string windowName;

    public string WindowName => windowName;

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}