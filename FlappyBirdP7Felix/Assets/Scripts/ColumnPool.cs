using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColumnPool : MonoBehaviour
{

    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float columnMin = -1f;
    public float columnMax = 3.5f;
    public float spawnRate = 4f;

    private float timeSinceLastspawn;
    private float spawnXPosition = 10f;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    public GameObject[] Columns;
    private int currentColumn;
    // Start is called before the first frame update
    void Start()
    {
        Columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            Columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastspawn = Time.deltaTime;

        if (gameController.instance.gameOver == false && timeSinceLastspawn >= spawnRate)
        {
            timeSinceLastspawn = 0;
            float SpawnYPosition = Random.Range (columnMin, columnMax);
            Columns[currentColumn].transform.position = new Vector2(spawnXPosition, SpawnYPosition);
        }
    }
}
