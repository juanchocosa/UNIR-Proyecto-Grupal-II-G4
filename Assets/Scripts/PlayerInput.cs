using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public float speed = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, moveY, 0);
        if (move != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
            transform.position += move * Time.deltaTime * speed;
            if (moveX > 0f)
            {
                transform.localScale = new Vector3(4, 4, 1);
            }
            else if (moveX < 0f)
            {
                transform.localScale = new Vector3(-4, 4, 1);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
