using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Playerr : MonoBehaviour

{
    public Animator anim;
    public float speed;
        
    void Update()
        {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        Vector3 movement= new Vector3 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0f);
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;
    }

        
    }
