using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public Transform spawPoint1;
    public Transform spawPoint2;

    public override void OnStartServer()
    {
        base.OnClientConnect();

        Debug.Log("Começou!Boraa galera!");
    }
    public override void OnStopServer()
    {
        base.OnStopServer();

        Debug.Log("Encerrando o Server...");
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        Debug.Log("Novo jogador conectado!");
    }

    public override void OnServerAddPlayer (NetworkConnectionToClient conn)
    {
        Transform startPoint;
        if (numPlayers == 0)
        {
            startPoint = spawPoint1;
        }
        else
        {
            startPoint = spawPoint2;
        }

        GameObject new_player = Instantiate(playerPrefab, startPoint.position, startPoint.rotation); NetworkServer.AddPlayerForConnection(conn, new_player);
    }
}
