using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 4f;
    public Vector3 leftEdge;
    public GameObject topPipe;
    private BoxCollider2D pipeCollider;                        
    public float pipeHalfWidth;
    private void Start()
    {
        leftEdge = new Vector3(0, Screen.height / 2, -Camera.main.transform.position.z);
        leftEdge = Camera.main.ScreenToWorldPoint(leftEdge);
        pipeCollider = topPipe.GetComponent<BoxCollider2D>();
        pipeHalfWidth = pipeCollider.size.x / 2;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x + pipeHalfWidth < leftEdge.x)
        {
            Destroy(gameObject);
        }
    }

}
