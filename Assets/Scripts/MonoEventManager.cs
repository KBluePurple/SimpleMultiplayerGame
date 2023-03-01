using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoEventManager : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        _instance = new GameObject("MonoEventManager").AddComponent<MonoEventManager>();
        _instance.gameObject.hideFlags = HideFlags.HideAndDontSave;
    }

    public static MonoEventManager Instance => _instance;

    private static MonoEventManager _instance;
    private static readonly Queue<IEnumerator> Coroutines = new();
    private static readonly Queue<Action> Actions = new();

    public static void QueueCoroutine(IEnumerator invokeCoroutine)
    {
        Coroutines.Enqueue(invokeCoroutine);
    }
    
    public static void QueueAction(Action action)
    {
        Actions.Enqueue(action);
    }

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public static Action OnUpdate { get; set; }

    private void Update()
    {
        OnUpdate?.Invoke();
        
        while (Coroutines.Count > 0)
        {
            StartCoroutine(Coroutines.Dequeue());
        }
        
        while (Actions.Count > 0)
        {
            Actions.Dequeue().Invoke();
        }
    }
}