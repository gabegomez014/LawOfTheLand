using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDetection : MonoBehaviour
{
    public BlazeAI blazeAI;
    public int damage;
    private void OnTriggerEnter(Collider other) {
        if ((other.tag == "Player") && blazeAI.isAttacking) {
            other.GetComponent<CharacterCombatManager>().TakeDamage(damage);
        }
    }
}
