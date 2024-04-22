using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    private float maxX;

    public GameObject[] candiesPrefab;
    [SerializeField]
    float spawnInterval;

    public static CandySpawner Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {   //friendly reminder: do not call InvokeReapeating in Update()
        //InvokeRepeating("SpawnCandy", 2f, 1f);
        StartSpawningCandies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    void SpawnCandy()
    {
        int candyIndex = Random.Range(0, candiesPrefab.Length);
        var randomX = Random.Range(-maxX, maxX);
        var pos = gameObject.transform.position;
        pos = new Vector3(randomX, pos.y, pos.z);
        Instantiate(candiesPrefab[candyIndex], pos, Quaternion.identity);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(1f);

        while(true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpawningCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies");
    }
}
