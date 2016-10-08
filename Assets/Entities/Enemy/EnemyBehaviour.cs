using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    public float Healt = 150f;
    public GameObject Projectile;
    public float ProjectileSpeed = 10f;
    public float ShotsPerSeconds = 0.5f;

    void Update() {
        float probability = Time.deltaTime*ShotsPerSeconds;
        if(Random.value < probability) {Fire();}
    }

    void Fire() {
        Vector3 StartPosition = transform.position + new Vector3(0, -1, 0);
        GameObject missile = Instantiate(Projectile, StartPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ProjectileSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile) {
            Healt -= missile.GetDamage();
            missile.Hit();
            if(Healt <= 0) { Destroy(gameObject);}
        }
    }
}
