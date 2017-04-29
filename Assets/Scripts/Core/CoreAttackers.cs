using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public abstract class CoreAttackers : MonoBehaviour
{

    protected Animator anim;
    protected Attacker attacker;


    // Use this for initialization
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    protected virtual  void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        OnTriggered(collider);
    }

    protected abstract void OnTriggered(Collider2D collider);

}
