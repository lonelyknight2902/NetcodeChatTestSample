using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkStart : MonoBehaviour
{

    public void StartHost()
    {
        Debug.Log("host");
        NetworkManager.Singleton.StartHost();
    }
    
    public void StartClient()
    {
        Debug.Log("client");
        NetworkManager.Singleton.StartClient();
    }
}
