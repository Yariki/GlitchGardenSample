using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{

    public float seenEverySeconds;
    private float currentSpeed;
    private Animator animator;

    private GameObject currentTarget;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left   * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("isAttacking",false);
        }
    }

    void OnTriggerEnter2D()
    {
    }
    
    
    public void SetSpeed(float speed)
    {
    	currentSpeed = speed;
    }
    
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget == null)
        {
            return;
        }
        var healthComp = currentTarget.GetComponent<Health>();
        if (healthComp == null)
        {
            return;
        }
        healthComp.DealDamage(damage);
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
