using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool facingRight = true;
    float timeChoang = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if(timeChoang > 0)
        {
            timeChoang -= Time.deltaTime;
            movement = Vector2.zero;
        }
        else
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (movement.x > 0 && facingRight)
            {
                Flip();
            }
            else if (movement.x < 0 && !facingRight)
            {
                Flip();
            }
        }
    }
    public bool GetStatusChoang()
    {
        if (timeChoang > 0) return true;
        return false;
    }
    public void Choang()
    {
        timeChoang = 1f;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; 
        transform.localScale = scale;
    }
}
