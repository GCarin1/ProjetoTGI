using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class Playerr : MonoBehaviour

{
    private bool _trocarCena = false;
    public Animator anim;
    public float speed;
    private GerenciaCenas _gerenciaCenas;

    void start() {
        _gerenciaCenas = GameObject.Find("ADMCenas").GetComponent<GerenciaCenas>();
    }
        
    void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        Vector3 movement= new Vector3 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0f);
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;

        if (_trocarCena = true && Input.GetKeyDown("space")) {
            TrocarCenaPC();
        }
     }

    public void TrocarCenaPC() {
            SceneManager.LoadScene("Kali");
    }

    private void OnTriggerEnter(Collider algo) {
        if(algo != null){
            _trocarCena = true;
        }
    }

    private void OnTriggerExit(Collider algo) {
            _trocarCena = false;
    }



}
