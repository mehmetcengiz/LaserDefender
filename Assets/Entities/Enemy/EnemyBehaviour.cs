using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    public float Healt = 150f;
    public GameObject Projectile;
    public float ProjectileSpeed = 10f;
    public float ShotsPerSeconds = 0.5f;
    public int ScoreValue = 150;
    public AudioClip FireSound;
    public AudioClip DeathSound;

    private ScoreKeeper _scoreKeeper;
    void Start() {
        _scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }


    void Update() {
        float probability = Time.deltaTime*ShotsPerSeconds;
        if(Random.value < probability) {Fire();}
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile) {
            Healt -= missile.GetDamage();
            missile.Hit();
            if (Healt <= 0) {
                Die();
            }
        }
    }

    void Fire() {
        GameObject missile = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ProjectileSpeed);
        AudioSource.PlayClipAtPoint(FireSound,transform.position);
    }

    void Die() {
        AudioSource.PlayClipAtPoint(DeathSound, transform.position);
        Destroy(gameObject);
        _scoreKeeper.Score(ScoreValue);
    }


}
