using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MyStack<String> nameStack = new();
    void Start()
    {
        
    }
    [Button]
    public void PushToStack(string value)
    {
        nameStack.Push(value);
    }
    [Button]
    public void PopFromStack()
    {
        Debug.Log(nameStack.Pop()); 
    }
    [Button]
    public void PeekFromStack()
    {
        Debug.Log(nameStack.Peek());
    }
    [Button]
    public void ClearStack()
    {
        nameStack.Clear();
    }
    [Button]
    public void Count() => Debug.Log(nameStack.Count);

}
