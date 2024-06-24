using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    /*public float speed = 1.0f; // T?c ?? di chuy?n c?a mây
    public float minHeight = 0.5f; // ?? cao t?i thi?u c?a mây
    public float maxHeight = 1.5f; // ?? cao t?i ?a c?a mây
    public float minX = -10.0f; // V? trí X t?i thi?u c?a mây
    public float maxX = 10.0f; // V? trí X t?i ?a c?a mây

    private Vector3 startPosition;
    private float direction = 1.0f;

    void Start()
    {
        startPosition = transform.position;
        transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minHeight, maxHeight), startPosition.z);
    }

    void Update()
    {
        MoveCloud();
    }

    void MoveCloud()
    {
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

        // N?u mây di chuy?n ra kh?i màn hình, ??t l?i v? trí c?a nó
        if (transform.position.x > maxX)
        {
            direction = -1.0f;
        }
        else if (transform.position.x < minX)
        {
            direction = 1.0f;
        }

        // Thay ??i ?? cao c?a mây m?t cách ng?u nhiên ?? t?o c?m giác t? nhiên
        float newY = Mathf.Lerp(minHeight, maxHeight, Mathf.PingPong(Time.time * speed, 1));
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }*/
    [SerializeField] float _scrollSpeed;
    [SerializeField] float _initX;
    [SerializeField] float _minX;




    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-_scrollSpeed, 0f, 0f) * Time.deltaTime);

        if (transform.position.x < _minX)
            transform.position = new Vector3(_initX, transform.position.y, transform.position.z);
    }

}
