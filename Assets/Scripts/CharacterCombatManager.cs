using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PhysicsBasedCharacterController;
using UnityEngine.Events;
using Cinemachine;

public class CharacterCombatManager : MonoBehaviour
{
    public Animator anim;
    [Header("Time available for combo")]
    public int health = 1;
    public int term;
    public float dodgeForce;
    public float attackTime;
    public CinemachineFreeLook playerCam;
    public LockOnScript lockOnScript;

    public Ability[] abilities;

    [SerializeField] UnityEvent OnAttack1;
    [Space(15)]
    [SerializeField] UnityEvent OnAttack2;
    [Space(15)]
    [SerializeField] UnityEvent OnAttack3;
    [Space(15)]
    [SerializeField] UnityEvent OnDodge;
    [Space(15)]

    private CharacterManager _characterManager;
    private Rigidbody _rb;

    private int _currentHealth;
    private float _currentAttackTime;

    // Start is called before the first frame update
    private void Start()
    {
        _currentHealth = health;
        _characterManager = GetComponent<CharacterManager>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_characterManager && !_characterManager.GetJumping())
        {            
            Attack();
            
            ToggleLockOn();

            Dodge();
            
            Block();

            Skill1();
            
            Skill2();
            
            Skill3();
            
            Skill4();
            
            Skill5();
            
            Skill6();
            
            Skill7();
            
            Skill8();
        }
    }

    int clickCount;
    float timer;
    bool isTimer;
    bool attacking;

    
    void Attack()
    {   
        if (isTimer)
        {
            timer += Time.deltaTime;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            switch (clickCount)
            {
                
                case 0:
                    attacking = true;
                    _characterManager.SetAttacking(true);
                    _currentAttackTime = attackTime;
                    
                    anim.SetTrigger("Attack1");
                    OnAttack1.Invoke();
                    
                    isTimer = true;
                    
                    clickCount++;
                    break;

                
                case 1:
                    
                    if (timer <= term)
                    {                        
                        anim.SetTrigger("Attack2");
                        OnAttack2.Invoke();
                        _currentAttackTime = attackTime;
                        
                        clickCount++;
                    }

                    
                    else
                    {                        
                        anim.SetTrigger("Attack1");
                        
                        clickCount = 1;
                    }

                    // _characterManager.SetAttacking(false);
                    timer = 0;
                    break;

                
                case 2:
                    
                    if (timer <= term)
                    {                        
                        anim.SetTrigger("Attack3");
                        OnAttack3.Invoke();
                        _currentAttackTime = attackTime;
                        
                        clickCount = 0;
                        
                        isTimer = false;
                    }

                    
                    else
                    {                        
                        anim.SetTrigger("Attack1");
                        
                        clickCount = 1;
                    }
                
                    // _characterManager.SetAttacking(false);
                    timer = 0;
                    break;
            }
        } else if (_currentAttackTime <= 0 && attacking){
            attacking = false;
            _characterManager.SetAttacking(false);
        } else if (_currentAttackTime > 0) {
            _currentAttackTime -= Time.deltaTime;
        }
    }

    void ToggleLockOn()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab) && lockOnScript && playerCam)
        {            
            if (lockOnScript.enabled) {
                lockOnScript.enabled = false;
                playerCam.enabled = true;
            } else {
                playerCam.enabled = false;
                lockOnScript.enabled = true;
            }
        }
    }

    void Dodge() 
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && lockOnScript && playerCam)
        {            
            anim.SetTrigger("Dodge");
            OnDodge.Invoke();
            _rb.velocity += this.transform.forward * dodgeForce;
        }
    }

    void Block()
    {
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("Block", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("Block", false);
        }
    }

    // Skill1
    void Skill1()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Ability ability = abilities[0];
            // Play Skill1 animation
            ability.Initialize(this.gameObject);

            AnimatorOverrideController animController = anim.runtimeAnimatorController as AnimatorOverrideController;
            List<KeyValuePair<AnimationClip, AnimationClip>> animOverrideParams =
                new List<KeyValuePair<AnimationClip, AnimationClip>>();

            AnimationClip originalClip = animController.runtimeAnimatorController.animationClips.Where(
                clip => clip.name.Contains("Skill1")
            ).ToList()[0];

            animOverrideParams.Add(
                new KeyValuePair<AnimationClip, AnimationClip>(originalClip, ability.abilityAnim)
            );

            animController.ApplyOverrides(animOverrideParams);

            ability.TriggerAbility();

            anim.SetTrigger("Skill1");
        }
        
    }
    // Skill2
    void Skill2()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Play Skill2 animation
            anim.SetTrigger("Skill2");
        }
    }
    // Skill3
    void Skill3()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Play Skill3 animation
            anim.SetTrigger("Skill3");
        }
    }
    // Skill4
    void Skill4()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // Play Skill4 animation
            anim.SetTrigger("Skill4");
        }
    }
    // Skill5
    void Skill5()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            // Play Skill5 animation
            anim.SetTrigger("Skill5");
        }
    }
    // Skill6
    void Skill6()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            // Play Skill6 animation
            anim.SetTrigger("Skill6");
        }
    }
    // Skill7
    void Skill7()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            // Play Skill7 animation
            anim.SetTrigger("Skill7");
        }
    }
    // Skill8
    void Skill8()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            // Play Skill8 animation
            anim.SetTrigger("Skill8");
        }
    }

    public bool GetAttacking() {
        return attacking;
    }

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
        if (_currentHealth <= 0) {Death();}
    }

    public void Death() {
        Destroy(this.gameObject);
    }
}
