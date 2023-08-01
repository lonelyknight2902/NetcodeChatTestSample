using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ChatPlayer : NetworkBehaviour
{
    private TMP_InputField _inputField;
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            AddMessageServerRpc($"Player {OwnerClientId.ToString()} joined the chat");
            _inputField = ChatManager.instance.inputField;
            _inputField.onSubmit.AddListener(SendMessageUI);
        }
    }

    public override void OnNetworkDespawn()
    { 
        if (IsOwner)
        {
            AddMessageServerRpc($"Player {OwnerClientId.ToString()} left the chat");
        }
    }

    private void SendMessageUI(string message)
    {
        _inputField.text = "";
        if (!string.IsNullOrWhiteSpace(message) && IsOwner)
        {
            AddMessageServerRpc(message);
        }
    }

    [ServerRpc]
    void AddMessageServerRpc(string message)
    {
        AddMessageClientRpc(message);
    }

    [ClientRpc]
    void AddMessageClientRpc(string message)
    {
        ChatManager.instance.AddChat(message, OwnerClientId);
        Debug.Log(message);
    }
}
