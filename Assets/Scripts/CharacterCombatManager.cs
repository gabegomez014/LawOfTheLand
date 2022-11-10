using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhysicsBasedCharacterController;
using UnityEngine.Events;


public class CharacterCombatManager : MonoBehaviour
{
    public Animator anim;
    [Header("Time available for combo")]
    public int term;

    [SerializeField] UnityEvent OnAttack1;
    [Space(15)]
    [SerializeField] UnityEvent OnAttack2;
    [Space(15)]
    [SerializeField] UnityEvent OnAttack3;
    [Space(15)]
    [SerializeField] UnityEvent OnDodge;
    [Space(15)]

    private CharacterManager _characterManager;

    private float _tempSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        _characterManager = GetComponent<CharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_characterManager && !_characterManager.GetJumping())
        {            
            Attack();
            
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
                        
                        clickCount++;
                    }

                    
                    else
                    {                        
                        anim.SetTrigger("Attack1");
                        
                        clickCount = 1;
                    }

                    
                    timer = 0;
                    break;

                
                case 2:
                    
                    if (timer <= term)
                    {                        
                        anim.SetTrigger("Attack3");
                        OnAttack3.Invoke();
                        
                        clickCount = 0;
                        
                        isTimer = false;
                    }

                    
                    else
                    {                        
                        anim.SetTrigger("Attack1");
                        
                        clickCount = 1;
                    }
                
                    timer = 0;
                    break;
            }
        }
    }

    void Dodge()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {            
            anim.SetTrigger("Dodge");
            OnDodge.Invoke();
            StartCoroutine(DodgeRoutine());
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
            // Play Skill1 animation
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

    IEnumerator DodgeRoutine() {
        _tempSpeed = _characterManager.movementSpeed;
        yield return new WaitForSeconds(2);
    }
}
