using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIGameManager : MonoBehaviour
{
    public InputSystem_Actions inputs;

    public WindowManager wmanager = new();

    [Header("Panels")]
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject statsPanel;
    [SerializeField] private GameObject configPanel;
    [SerializeField] private GameObject mapPanel;

    private void Awake()
    {
        inputs = new();
    }

    private void OnEnable()
    {
        inputs.Enable();

        inputs.UI.Escape.performed += HideCurrentPanel;

        wmanager.OnElementAdded += OnElementAdded;
        wmanager.OnElementRemoved += OnElementRemoved;
    }

    private void OnDisable()
    {
        inputs.UI.Escape.performed -= HideCurrentPanel;

        wmanager.OnElementAdded -= OnElementAdded;
        wmanager.OnElementRemoved -= OnElementRemoved;

        inputs.Disable();
    }

    private void OnElementAdded(Window window)
    {
        if (window.window != null)
        {
            window.window.SetActive(true);

            window.window.transform.SetAsLastSibling();
        }
    }

    private void OnElementRemoved(Window window)
    {
        if (window.window != null)
        {
            window.window.SetActive(false);

            window.window.transform.SetAsFirstSibling();
        }
    }

    private void HideCurrentPanel(InputAction.CallbackContext context)
    {
        if (wmanager.Count <= 0)
            return;

        Window currentWindow = wmanager.Pop();

        if (currentWindow.window == null)
        {
            HideCurrentPanel(context);
            return;
        }

        if (!currentWindow.window.activeSelf)
        {
            HideCurrentPanel(context);
            return;
        }

        currentWindow.window.SetActive(false);

        Debug.Log("Closed: " + currentWindow.window.name);
    }

    #region Buttons

    public void OpenInventory()
    {
        BtnOpenPanel(inventoryPanel);
    }

    public void OpenStats()
    {
        BtnOpenPanel(statsPanel);
    }

    public void OpenConfig()
    {
        BtnOpenPanel(configPanel);
    }

    public void OpenMap()
    {
        BtnOpenPanel(mapPanel);
    }

    #endregion

    public void BtnOpenPanel(GameObject panel)
    {
        if (panel.activeSelf)
            return;

        Window window = new(panel);

        wmanager.Push(window);
    }

    [Button]
    public void PeekFromStack()
    {
        if (wmanager.Count <= 0)
        {
            Debug.Log("Stack Empty");
            return;
        }

        Debug.Log(wmanager.Peek().window.name);
    }

    [Button]
    public void Count()
    {
        Debug.Log(wmanager.Count);
    }
}