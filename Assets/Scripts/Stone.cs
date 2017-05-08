using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour
{

    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collider2)
    {
        Attacker attacker = collider2.gameObject.GetComponent<Attacker>();
        if (attacker && animator)
        {
            animator.SetTrigger("underAttack");
        }
    }


}
