using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class ProjectileSpawner : MonoBehaviour
{
    [Header ("Internals")] // Components the script needs to work
    [SerializeField] private List<Projectile> firedProjectiles = new List<Projectile>();    // A list of all currently alive projectiles fired by this script
    /*NTS: The list isn't currently used for anything, but could for example be used to freeze all projectiles for a limited time. */

    /// <summary>
    /// Creates a new projectile and sends it toward targeted position.
    /// Used for when no target gameobject exists.
    /// </summary>
    /// <param name="projectilePrefab">The type of projectile to be fired</param>
    /// <param name="targetPos">The position the projectile will be fired toward</param>
    public void FireProjectileAtPos(Projectile projectilePrefab, Vector2 targetPos)
    {
        Projectile newProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);   // Creates new projectile of desired type at spawner
        newProjectile.Fire(targetPos);                                                                      // Tells projectile to fire at targeted position
        firedProjectiles.Add(newProjectile);                                                                // Adds projectile to list of all projectiles
    }

    /// <summary>
    /// Creates a new projectile and sends it toward target gameobject's position.
    /// Used for when targeting position of a gameobject.
    /// </summary>
    /// <param name="projectilePrefab">The type of projectile to be fired</param>
    /// <param name="target">The position the projectile will be fired toward</param>
    public void FireProjectileAtObj(Projectile projectilePrefab, GameObject target)
    {
        Projectile newProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);   // Creates new projectile of desired type at spawner
        newProjectile.Fire(target.transform.position);                                                      // Tells projectile to fire at target gameobject's position
        firedProjectiles.Add(newProjectile);                                                                // Adds projectile to list of all projectiles
    }
}
