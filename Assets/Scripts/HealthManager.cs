using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float health;
    public GameObject deathVFX;
    public Transform spawnPoint;
    public float lifeTime;

    private float _currentHealth;
    private BlazeAI _blazeAI;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = health;
        _blazeAI = GetComponent<BlazeAI>();
    }

    public void TakeDamage(float damage) {
        _currentHealth -= damage;

        if (_currentHealth <= 0) {
            Death();
        }
    }

    private void Death() {
        Vector3 position = this.transform.position;
        // position.y = position.y + 1.2f;
        if (deathVFX) {
            GameObject clonedVFX = Instantiate(deathVFX, position, Quaternion.identity);

            if (spawnPoint) {
                clonedVFX = Instantiate(deathVFX, spawnPoint.position, Quaternion.identity);
            } else {
                clonedVFX = Instantiate(deathVFX, position, Quaternion.identity);
            }
            clonedVFX.transform.LookAt(Camera.main.transform.position);
            clonedVFX.transform.localEulerAngles = new Vector3(-90, clonedVFX.transform.localEulerAngles.y, 0);
            Destroy(clonedVFX, lifeTime);
        } else {
            Debug.LogWarning("Death VFX is not set");
        }

        if (_blazeAI) {
            _blazeAI.Death();
        } else {
            Debug.LogWarning("Blaze AI is not set");
        }

        Destroy(this.gameObject);
    }
}
