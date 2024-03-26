using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportProjectile : Projectile
{
    public override void Fire(Vector2 targetPos)
    {
        transform.position = (Vector3) targetPos;
        StartPhysAnim();
    }
}
