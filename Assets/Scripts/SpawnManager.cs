using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Michsky.UI.MTP;

public class SpawnManager : MonoBehaviour
{

    public UIManager uiManager;
    public GameObject roundPresentation;
    public float pauseOnAnimTime;
    public StyleManager roundManager;

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

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemies());
    }

    public void StopSpawning()
    {
        _keepSpawning = false;
        foreach (Transform child in _enemyHolder)
        {
            Destroy(child.gameObject);
        }
    }

    public void GameRestarted()
    {
        _keepSpawning = true;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() 
    {
        roundManager.textItems[0].text = "ROUND 1";
        roundPresentation.SetActive(true);
        yield return new WaitForSeconds(pauseOnAnimTime);
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
                        uiManager.ShowWinScreen();
                        break;
                    }


                    _enemiesThisWave = _waves[_currentWave].GetEnemies();
                    Debug.Log("Current wave is " + _currentWave);
                    roundManager.textItems[0].text = "ROUND " + (_currentWave + 1);
                    roundPresentation.SetActive(true);
                    yield return new WaitForSeconds(pauseOnAnimTime);
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
