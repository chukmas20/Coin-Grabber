using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    public ObjectPuller coinPuller;

    public void SpawnCoins(Vector3 position, float groundWidth)
    {
        int random = UnityEngine.Random.Range(1, 100);

        if (random < 50)
            return;

        int numberOfCoins = (int)UnityEngine.Random.Range(3f, groundWidth);
        float y = UnityEngine.Random.Range(2, 4);

        for (int i = 0; i < numberOfCoins; i++)
        {
            GameObject coin = coinPuller.GetPulledGameObject();
            coin.transform.position = new Vector3(position.x  + i, position.y + y, 0);
            coin.SetActive(true);

        }

      
    }

  
}
