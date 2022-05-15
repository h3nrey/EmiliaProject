using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    Vector2 direction;
    Vector2 target;
    [SerializeField] float hookSpeed;
    [SerializeField]LineRenderer line;


    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       
        anim.SetFloat("speedHorizontal", direction.x);
        anim.SetFloat("speedVertical", direction.y);

        line.SetPosition(0, transform.position);
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);;
            line.SetPosition(1,target);
        }

        if(Input.GetMouseButton(1)) {
            transform.position = Vector2.MoveTowards(transform.position, target, hookSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate() {
        rb.velocity = direction.normalized * speed;
    }
}
