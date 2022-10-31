using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPuller : MonoBehaviour
{
    public GameObject pulledObject;
    public int numberOfObject;
    private List<GameObject> gameObjects;
    void Start()
    {
        gameObjects = new List<GameObject>();

        for (int i = 0; i < numberOfObject; i++)
        {
            GameObject gameObject = Instantiate(pulledObject);
            gameObject.SetActive(false);
            gameObjects.Add(gameObject);
        }
    }
    public GameObject GetPulledGameObject()
    {
        foreach(GameObject gameObject in gameObjects)
        {
            if (!gameObject.activeInHierarchy)
                return gameObject;
        }
        GameObject gameObj = Instantiate(pulledObject);
        gameObj.SetActive(false);
        gameObjects.Add(gameObj);
        return gameObj;

    }

    public static implicit operator GameObject(ObjectPuller v)
    {
        throw new NotImplementedException();
    }
}
