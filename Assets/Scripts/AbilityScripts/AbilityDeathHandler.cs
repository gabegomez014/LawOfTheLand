using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDeathHandler : MonoBehaviour
{
    private GameObject _deathParticles;
    private Transform _abilityTransform;


    private float _abilityDuration = 1.5f;
    private float _deathParticlesDuration = 1.5f;
    private float _damage;
    private float _currentTime;
    private bool _abilitySet = false;
    // Start is called before the first frame update

    private void Update() {
        if (_abilitySet) {
            if (_currentTime >= _abilityDuration) {
                TriggerDeath();
            } else {
                _currentTime += Time.deltaTime;
            }   
        }
    }

    public void SetAbilityDuration(float duration) {
        _abilityDuration = duration;
        _abilitySet = true;
    }

    public void SetDeathParticles(GameObject deathParticles) {
        _deathParticles = deathParticles;
    }

    public void SetDeathParticlesDuration(float duration) {
        _deathParticlesDuration = duration;
    }

    public void SetAbilityTransform(Transform transform) {
        _abilityTransform = transform;
    }

    public void SetDamage(float damage) {
        _damage = damage;
    }

    public void TriggerDeath() {
        GameObject clonedParticles = Instantiate(_deathParticles, _abilityTransform.position, Quaternion.identity);
        Destroy(clonedParticles, _deathParticlesDuration);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            HealthManager healthManager = other.GetComponent<HealthManager>();
            healthManager.TakeDamage(_damage);

            TriggerDeath();
        }
    }
}
