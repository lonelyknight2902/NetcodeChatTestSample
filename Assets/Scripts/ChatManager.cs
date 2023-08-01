using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    [SerializeField] private TMP_Text chatText;
    [SerializeField] public TMP_InputField inputField;
    private Queue<string> _chat = new Queue<string>();
    private const int MaxMessage = 23;

    public static ChatManager instance;

    private void Start()
    {
        instance = this;
    }

    public void AddChat(string message, ulong id)
    {
        // _chat.Push(id + "> " + message);
        _chat.Enqueue(id + "> " + message);
        if (_chat.Count > MaxMessage)
        {
            _chat.Dequeue();
        }

        chatText.text = string.Join("\n", _chat);
    }
}
