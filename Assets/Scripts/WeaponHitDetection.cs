using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitDetection : MonoBehaviour
{
    public GameObject weaponVFX;
    public float damage; 
    public CharacterCombatManager _player;

    private void OnTriggerEnter(Collider other) {
        if (_player && _player.GetAttacking() && other.tag == "Enemy") {
            GameObject clonedVFX = Instantiate(weaponVFX, other.ClosestPointOnBounds(this.transform.position), Quaternion.identity);
            Destroy(clonedVFX, 2);

            EnemyHitDetection enemyHitDetection = other.GetComponent<EnemyHitDetection>();
            enemyHitDetection.Hit();

            HealthManager healthManager = other.GetComponent<HealthManager>();
            healthManager.TakeDamage(damage);
        }
    }
}
