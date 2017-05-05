using UnityEngine;
using System.Collections;

public class Lizard : CoreAttackers
{
    protected override void OnTriggered(Collider2D collider)
    {
        var gameObject = collider.gameObject;

        if (gameObject.GetComponent<Defender>() && anim != null && attacker != null)
        {
            anim.SetBool("isAttacking", true);
            attacker.Attack(gameObject);
        }
    }
}
