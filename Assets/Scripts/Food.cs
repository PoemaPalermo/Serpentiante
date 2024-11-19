using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Collider2D spawnArea;
    int puntos;
    
    void Start()
    {
        SpawnComida();
        puntos = 0;
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.spawnArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);
    }
    private void SpawnComida()
    {        
        RandomizePosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SpawnComida();
            puntos += 1;
            Debug.Log("Tenes " + puntos + " puntos");
        }        
    }
}
