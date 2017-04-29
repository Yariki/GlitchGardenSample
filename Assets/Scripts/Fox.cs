using UnityEngine;
using System.Collections;

public class Fox : CoreAttackers
{
    protected override void OnTriggered(Collider2D collider)
    {
        var gameObject = collider.gameObject;

        if (!gameObject.GetComponent<Defender>())
        {
            return;
        }

        if (gameObject.GetComponent<Stone>() && anim != null)
        {
            anim.SetTrigger("needJump");
        }
        else if (attacker != null  && anim != null)
        {
            anim.SetBool("isAttacking", true);
            attacker.Attack(gameObject);
        }
    }
}
