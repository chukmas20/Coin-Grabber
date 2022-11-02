using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public Transform groundPoint;
    public Transform minHeightPoint;
    public Transform maxHeightPoint;

    private float minY;
    private float maxY;

    public float minGap;
    public float maxGap;

    public ObjectPuller[] groundPullers;
    private float[] groundWidths;

    private CoinsGenerator coinGenerator;
    void Start()
    {
        minY = minHeightPoint.position.y;
        maxY = maxHeightPoint.position.y;
        groundWidths = new float[groundPullers.Length];

        for (int i = 0; i < groundPullers.Length; i++)
        {
            groundWidths[i] = groundPullers[i].pulledObject.GetComponent<BoxCollider2D>().size.x;
        }

        coinGenerator = FindObjectOfType<CoinsGenerator>();
    }

    private void Update()
    {
        if(transform.position.x < groundPoint.position.x)
        {
            int random = Random.Range(0, groundPullers.Length);
            float distance = groundWidths[random] / 2;

            float gap = Random.Range(minGap, maxGap);
            float height = Random.Range(minY, maxY);

            transform.position = new Vector3(transform.position.x + distance + gap, height, transform.position.z);
            GameObject ground = groundPullers[random].GetPulledGameObject();
            ground.transform.position = transform.position;
            ground.SetActive(true);

            coinGenerator.SpawnCoins(
                transform.position,
                groundWidths[random]
            );

            transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);


        }
    }

    // Update is called once per frame

}
