using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    public float minWidth = -0.5f;
    public float maxWidth = 1f;
    public float spawnTime = 1f;
    public Vector3 startingPosition;
    // Start is called before the first frame update
    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnTime,spawnTime);
        startingPosition = transform.position;
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }


    // Update is called once per frame
    public void Spawn()
    {
        GameObject pipe = Instantiate(pipePrefab, transform.position, Quaternion.identity);
        transform.position = startingPosition;
        pipe.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        ChangePosition();
    }
    public void ChangePosition()
    {
        Vector3 position = transform.position;
        position.x += Random.Range(minWidth, maxWidth);
        transform.position = position;
    }
}
