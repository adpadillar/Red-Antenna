using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Adjust the speed as needed
    public bool left = true;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial velocity to move left
    }

    // Update is called once per frame
    void Update()
    {
        if (left) {
            transform.position += speed * Time.deltaTime * Vector3.left;
            if(transform.position.x < -10)
                {
                    Destroy(gameObject);
                }
        } else {
            transform.position += speed * Time.deltaTime * Vector3.right;
            if(transform.position.x > 25)
                {
                    Destroy(gameObject);
                }
        }

        

    }
}
