using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button serverBttn;
    [SerializeField] private Button hostBttn;
    [SerializeField] private Button clientBttn;

    private void Awake()
    {
        serverBttn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });
        hostBttn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
        clientBttn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }
}
