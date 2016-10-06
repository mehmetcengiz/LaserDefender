using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float Width = 10f;
    public float Height = 5f;
    public float speed = 10f;

    private bool _isMovingRight = true;
    private float _xmax;
    private float _xmin;


	void Start () {
	    float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
	    Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
	    _xmax = rightBoundary.x;
	    _xmin = leftBoundary.x;
        foreach (Transform child in transform) {
            GameObject enemy = Instantiate(enemyPrefab,child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }

	}

    public void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position,new Vector3(Width,Height));    
    }

	// Update is called once per frame
	void Update () {
	    if (_isMovingRight) {
	        transform.position += Vector3.right * speed * Time.deltaTime;
	    }
	    else {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

	    float rightEdgeOfFormation = transform.position.x + (0.5f*Width);
        float leftEdgeOfFormation = transform.position.x - (0.5f* Width);

	    if (leftEdgeOfFormation < _xmin || rightEdgeOfFormation > _xmax) {
	        _isMovingRight = !_isMovingRight;
	    }

	}
}
