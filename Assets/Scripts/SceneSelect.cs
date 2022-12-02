using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public SpawnManager spawnManager;
    public GameObject mainPanels;

    private bool gamePlaying;


    public void StartGame() {
        mainPanels.SetActive(false);
        spawnManager.StartSpawning();
    }

    private void Update() {
        if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && !gamePlaying) {
            gamePlaying = true;
            StartGame();
        } 
    }
    
}
