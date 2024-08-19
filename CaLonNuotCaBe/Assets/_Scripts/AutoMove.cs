using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public enum Target
    {
        None, Down, Up, Left, Right
    }

    Target targetMove;
    [SerializeField] float speed = 3f;
    public void SetTargetMove(Target target)
    {
        targetMove = target;
    }
    private void Update()
    {
        switch(targetMove)
        {
            case Target.Down:
                Vector2 directionDown = Vector2.down;
                transform.Translate(directionDown * speed * Time.deltaTime);
                break;
            case Target.Up:
                Vector2 directionUp = Vector2.up;
                transform.Translate(directionUp * speed * Time.deltaTime);
                break;
            case Target.Right:
                Vector2 directionRight = Vector2.right;
                transform.Translate(directionRight * speed * Time.deltaTime);
                break;
            case Target.Left:
                Vector2 directionLeft = Vector2.left;
                transform.Translate(directionLeft * speed * Time.deltaTime);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Exit")
        {
            Destroy(gameObject);
        }
    }
}
