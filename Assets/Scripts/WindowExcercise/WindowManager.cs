using Sirenix.OdinInspector;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class WindowManager : MyStack<Window>
{
    public Action<Window> OnElementAdded;
    public Action<Window> OnElementRemoved;



    public override void Push(Window value)
    {
        base.Push(value);
        OnElementAdded?.Invoke(Peek());

    }

    public override Window Pop()
    {
        OnElementRemoved?.Invoke(Peek());
        return base.Pop();
    }




}