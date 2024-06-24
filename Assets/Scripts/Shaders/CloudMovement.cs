using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    /*public float speed = 1.0f; // T?c ?? di chuy?n c?a m�y
    public float minHeight = 0.5f; // ?? cao t?i thi?u c?a m�y
    public float maxHeight = 1.5f; // ?? cao t?i ?a c?a m�y
    public float minX = -10.0f; // V? tr� X t?i thi?u c?a m�y
    public float maxX = 10.0f; // V? tr� X t?i ?a c?a m�y

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

        // N?u m�y di chuy?n ra kh?i m�n h�nh, ??t l?i v? tr� c?a n�
        if (transform.position.x > maxX)
        {
            direction = -1.0f;
        }
        else if (transform.position.x < minX)
        {
            direction = 1.0f;
        }

        // Thay ??i ?? cao c?a m�y m?t c�ch ng?u nhi�n ?? t?o c?m gi�c t? nhi�n
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
