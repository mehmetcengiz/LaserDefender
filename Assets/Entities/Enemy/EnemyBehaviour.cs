using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    public float Healt = 150f;


    void OnTriggerEnter2D(Collider2D collider) {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile) {
            Healt -= missile.GetDamage();
            missile.Hit();
            if(Healt <= 0) { Destroy(gameObject);}
        }
    }
}
