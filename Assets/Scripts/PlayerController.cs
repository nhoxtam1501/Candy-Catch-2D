using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    [SerializeField]
    float maxPos = 7f;

    [SerializeField]
    private float speed = 3;
   
    public static PlayerController Instance;
    


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * xInput * speed * Time.deltaTime;

        float xPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);



    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Candy"))
        {
            GameManager.Instance.IncrementScore();
            Destroy(collision.gameObject);
 
        }
    }
}
