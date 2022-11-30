using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private Transform[] _spawnLocations;
    [SerializeField]
    private WaveStruct[] _waves;
    [SerializeField]
    private Transform _enemyHolder;
    [SerializeField]
    private float _spawnRate = 3;
    [SerializeField]
    private float _spawnDelay = 1.5f;

    private int _currentWave = 0;
    private List<GameObject> _enemiesThisWave;
    private bool _keepSpawning = true;

    private void Start() {
        StartSpawning();
    }

    public void StartSpawning()
    {
        // _uiManager.SetFinalWave(_waves.Length);
        // _uiManager.UpdateWave(_currentWave + 1);
        StartCoroutine(SpawnPowerups());
        StartCoroutine(SpawnEnemies());
    }

    public void StopSpawning()
    {
        _keepSpawning = false;
        foreach (Transform child in _enemyHolder)
        {
            Destroy(child.gameObject);
        }

        // foreach (Transform child in _powerupHolder)
        // {
        //     Destroy(child.gameObject);
        // }
    }

    public void GameRestarted()
    {
        _keepSpawning = true;
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerups());
    }

    IEnumerator SpawnPowerups()
    {
        yield return new WaitForSeconds(_spawnDelay/2);

        while (_keepSpawning)
        {
            float waitTime = Random.Range(3, 7);
            Vector3 spawnPos = _spawnLocations[Random.Range(0,_spawnLocations.Length)].position;

            //Checking to see if we should drop a rare power-up (Currently set to a 5% probability)
            // if (Random.value <= 0.05f)
            // {
            //     GameObject rarePowerupToSpawn;
            //     int powerupType = Random.Range(0, _rarePowerups.Length);
            //     rarePowerupToSpawn = _rarePowerups[powerupType];

            //     Instantiate(rarePowerupToSpawn, spawnPos, Quaternion.identity, _powerupHolder);
            // }

            // else
            // {
            //     GameObject powerupToSpawn;
            //     int powerupType = Random.Range(0, _powerups.Length);
            //     powerupToSpawn = _powerups[powerupType];

            //     Instantiate(powerupToSpawn, spawnPos, Quaternion.identity, _powerupHolder);
            // }

            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator SpawnEnemies() 
    {
        yield return new WaitForSeconds(_spawnDelay);
        _enemiesThisWave = _waves[_currentWave].GetEnemies();

        while (_keepSpawning)
        {
            if (_enemiesThisWave.Count == 0)
            {

                //Check to see if the player has killed all enemies for this wave
                if (_enemyHolder.childCount == 0)
                {
                    _currentWave += 1;

                    if (_currentWave == _waves.Length)
                    {
                        // Player has beat the game!
                        _keepSpawning = false;
                        // _uiManager.PlayerWon();
                        break;
                    }

                    else if (_currentWave == _waves.Length - 1)
                    {
                        // _player.BossIncoming();
                    }

                    _enemiesThisWave = _waves[_currentWave].GetEnemies();
                    // _uiManager.UpdateWave(_currentWave + 1);

                    yield return new WaitForSeconds(1);
                }

                else
                {
                    // do nothing until the player beats the current wave
                    yield return new WaitForSeconds(0.25f);
                    continue;
                }
            }

            Vector3 spawnPos = _spawnLocations[Random.Range(0,_spawnLocations.Length)].position;

            if (_currentWave + 1 == _waves.Length)
            {
                spawnPos.x = 0;
            }

            GameObject enemyToSpawn;
            int enemyType = Random.Range(0, _enemiesThisWave.Count);
            enemyToSpawn = _enemiesThisWave[enemyType];
            Instantiate(enemyToSpawn, spawnPos, Quaternion.identity, _enemyHolder);
            _enemiesThisWave.RemoveAt(enemyType);
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}
