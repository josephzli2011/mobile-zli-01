using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING}

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float delay;
    }
    public List<Wave> waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    public Transform[] spawnPoints;

    private float searchCountdown = 1f;

    public float countMultiplier = 1.5f;

    public Text waveCompletedText;

    private SpawnState state = SpawnState.COUNTING;

    void WaveCompleted()
    {
        if (nextWave + 1 > waves.Count - 1)
        {
            Wave wave = new Wave();
            wave.name = "Wave " + (nextWave + 1);
            wave.enemy = waves[nextWave].enemy;
            wave.count = (int)(waves[nextWave].count * countMultiplier);
            wave.delay = waves[nextWave].delay;
            nextWave++;
            waves.Add(wave);
        }
        else
        {
            nextWave++;
        }

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        
    }

    IEnumerator textHide()
    {
        yield return new WaitForSeconds(timeBetweenWaves - 1f);
        waveCompletedText.gameObject.SetActive(false);
    }

    private void Start()
    {
        waveCompletedText.gameObject.SetActive(false);
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if(!EnemyIsAlive())
            {
                Debug.Log("Wave Completed!");
                waveCompletedText.text = "WAVE " + (1+nextWave) + " COMPLETED!";
                waveCompletedText.gameObject.SetActive(true);
                StartCoroutine(textHide());
                WaveCompleted();
            } else
            {
                return;
            }
        }

        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            } 

        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
            
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(_wave.delay);
        }

        state = SpawnState.WAITING;
        yield break;
        
    }

    void SpawnEnemy(Transform _enemy)
    {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        if(spawnPoints.Length == 0)
        {
            Debug.LogError("No spawnpoints. You are a bad boy!");
        }
        Instantiate(_enemy, sp.position, Quaternion.identity);
        Debug.Log("Spawning enemy: " + _enemy.name);
    }

}
