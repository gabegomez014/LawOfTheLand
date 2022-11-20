using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitDetection : MonoBehaviour
{
    private BlazeAI _blazeAI;

    private void Start() {
        _blazeAI = GetComponent<BlazeAI>();
    }

    public void Hit() {
        if (_blazeAI) {
            _blazeAI.Hit();
        } else {
            Debug.LogWarning("BlazeAI is not set");
            _blazeAI = GetComponent<BlazeAI>();
            _blazeAI.Hit();
        }
    }
}
