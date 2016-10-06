using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Speed=5.0f;
    public float Padding = 0.5f;

    private float _xmin;
    private float _xmax;
    

    void Start() {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distance));
        _xmin = leftMost.x + Padding;
        _xmax = rightMost.x - Padding;
    }
    void Update() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }
        //restrict the player to the Gamespace
        float newX = Mathf.Clamp(transform.position.x, _xmin, _xmax);
        transform.position = new Vector3(newX,transform.position.y,transform.position.z);
    }
}
