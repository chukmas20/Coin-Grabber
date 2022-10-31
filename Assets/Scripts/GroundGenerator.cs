using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public Transform groundPoint;
    public ObjectPuller[] groundPullers;
    private float[] groundWidths;
    void Start()
    {
        groundWidths = new float[groundPullers.Length];
        for (int i = 0; i < groundPullers.Length; i++)
        {
            groundWidths[i] = groundPullers[i].pulledObject.GetComponent<BoxCollider2D>().size.x;
        }
    }

    private void Update()
    {
        if(transform.position.x < groundPoint.position.x)
        {
            int random = Random.Range(0, groundPullers.Length);
            float distance = groundWidths[random] / 2;

            transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
            GameObject ground = groundPullers[random].GetPulledGameObject();
            ground.transform.position = transform.position;
            ground.SetActive(true);

            transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);


        }
    }

    // Update is called once per frame

}
