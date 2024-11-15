using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    Vector2 direction;
    private List<Transform> tramos;
    public Transform prefabSegmento;
    private void Start()
    {
        direction = Vector2.right;
        tramos = new List<Transform>();
        tramos.Add(this.transform);
        this.transform.position = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
        }
    }
    private void FixedUpdate()
    {
        for(int i = tramos.Count-1; i>0; i--)
        {
            tramos[i].position = tramos[i - 1].position;
        }
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x + direction.x), Mathf.Round(this.transform.position.y + direction.y), 0f);
    }

    private void Grow()
    {
        Transform segmento = Instantiate(this.prefabSegmento);
        segmento.position = tramos[tramos.Count - 1].position;

        tramos.Add(segmento);
    }
    private void Die()
    {
        for(int i = 1; i<tramos.Count-1; i++)
        {
            Destroy(tramos[i].gameObject);
        }

        tramos.Clear();
        tramos.Add(this.transform);

        SceneManager.LoadScene("Died");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
        }
        else if(collision.tag == "Obstacle")
        {
            Die();
        }

    }
}
