using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.Dark;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image healthBar;
    public GameObject exitScreen;
    public GameObject gameOverScreen;
    public GameObject gameWonScreen;

    private ModalWindowManager exitModalManager;
    private ModalWindowManager gameOverModalManager;
    private ModalWindowManager gameWonModalManager;


    private void Start() {
        exitModalManager = exitScreen.GetComponent<ModalWindowManager>();
        gameOverModalManager = gameOverScreen.GetComponent<ModalWindowManager>();
        gameWonModalManager = gameWonScreen.GetComponent<ModalWindowManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !exitScreen.activeSelf) {
            PresentExitModal();
        }
    }

    public void PresentExitModal() {
        exitModalManager.ModalWindowIn();
    }

    public void ResumeGame() {
        exitModalManager.ModalWindowOut();
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void UpdateHealthBar(float percent) {
        healthBar.fillAmount = percent;
    }

    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowGameOver() {
        gameOverModalManager.ModalWindowIn();
    }

    public void ShowWinScreen() {
        gameWonModalManager.ModalWindowIn();
    }
}
