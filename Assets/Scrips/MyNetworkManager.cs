using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public Transform spawPoint1;
    public Transform spawPoint2; 
    public List<Transform> coinSpawnPoints;
    public int maxCoinsInGame = 2;
    public static int spawnedCoins = 0;

    public override void OnStartServer()
    {
        Debug.Log("Começou!Boraa galera!");
    }
    public override void OnStopServer()
    {
        Debug.Log("Encerrando o Server...");
    }

    public override void OnClientConnect()
    {
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
            InvokeRepeating("SpawnCoin", 2, 2);
        }

        GameObject new_player = Instantiate(playerPrefab, startPoint.position, startPoint.rotation); NetworkServer.AddPlayerForConnection(conn, new_player);
    }
    public void SpawnCoin()
    {
        if (spawnedCoins < maxCoinsInGame)
        {
            Vector3 local = coinSpawnPoints[Random.Range(0, coinSpawnPoints.Count)].position;

            GameObject new_coin = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Coin"),local, transform.rotation);

            NetworkServer.Spawn(new_coin);
            spawnedCoins++;
        }
    }
}
 