using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CarrotSpawner : MonoBehaviour
{

    public GameObject carrotPrefab;
    public GameObject speedCarrotPrefab;
    public GameObject badCarrotPrefab;
    public float spawnInterval = 2f;
    public float speedCarrotChance = 0.1f;
    public float BadCarrotChance = 0.2f;
    public Transform UpperBound;
    public Transform LowerBound;
    public Transform LeftBound;
    public Transform RightBound;
    public int maxCarrots;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnCarrot", 1f, spawnInterval);
    }

    void SpawnCarrot()
    {
        int currentCarrots = GameObject.FindGameObjectsWithTag("Carrot").Length + 
            GameObject.FindGameObjectsWithTag("SpeedCarrot").Length +
            GameObject.FindGameObjectsWithTag("BadCarrot").Length;


        if (currentCarrots >= maxCarrots)
        {
            return;
        }
        float x = Random.Range(LeftBound.position.x, RightBound.position.x);
        float y = Random.Range(LowerBound.position.y, UpperBound.position.y);

        Vector2 pos = new Vector2(x, y);

        float r = Random.value;

        if (r < speedCarrotChance)
        {
            Instantiate(speedCarrotPrefab, pos, Quaternion.identity);
        }
        else if (r < speedCarrotChance + BadCarrotChance)
        {
            Instantiate(badCarrotPrefab, pos, Quaternion.identity);
        }
        else
        {
            Instantiate(carrotPrefab, pos, Quaternion.identity);
        }
    }
}