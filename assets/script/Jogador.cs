using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    //implementando força do pulo pelo unity 
    public float ForçaPulo;
    public float speed= 5;
    public bool isGrounded;
    //contador de vida e pontos 
    public int Life;
    public int Coffe;

    public Text TextLife;
    public Text TextCoffe;

    //variavel check
    public GameObject lastCheckpoint;

    //atirar
    
    private float fireRate = 0.5f;
    private float nextFire;
    public GameObject bulletPrefab;
    public Transform shotSpawner;
    

    //ver
    private bool faceingRight;


    //dano queda
    public float quedaMAX;
    void Start(){
        TextLife.text = Life.ToString();
        TextCoffe.text = Coffe.ToString();
    
    
    }

    void Update(){
        Move();

        //resumindo variavel GetComponent<Rigidbody2D>() para rigidbody
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        //dizendo oq é o movimento 

        float movimento = Input.GetAxis("Horizontal");

       // movimentos
        

        //pulo 
        if (Input.GetKeyDown(KeyCode.UpArrow)&& isGrounded) {
            rigidbody.AddForce(new Vector2(0,ForçaPulo));
            //implementação som ao realizar o pulo 
            GetComponent<AudioSource>().Play();
        }

        //agachada // ALTERAR PARA ANDAR PARA BAIXO
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            GetComponent<Animator>().SetBool("Crouch",true) ;
        }
        else {
            GetComponent<Animator>().SetBool("Crouch", false);
        }
        if (isGrounded) {
            GetComponent<Animator>().SetBool("Jumping", false);
        }
        else {
            GetComponent<Animator>().SetBool("Jumping", true);
        }
        
        //flip do sprit 
        if (movimento > 0) {
            GetComponent<SpriteRenderer>().flipX = false;
            faceingRight = true;
        } else if(movimento<0){
            GetComponent<SpriteRenderer>().flipX = true;
            faceingRight = false;


            //animação de andando 
        }if (movimento > 0 || movimento < 0)
        {
            GetComponent<Animator>().SetBool("RunShot", true);
        }
        else {
            GetComponent<Animator>().SetBool("RunShot", false);
        }
        //animação / tiro 
        if (Input.GetKeyDown(KeyCode.Z)&& Time.time>nextFire) {
            nextFire = Time.time + fireRate;
            GameObject tempBullet = Instantiate(bulletPrefab,shotSpawner.position,shotSpawner.rotation);
            if (!faceingRight) {
                tempBullet.transform.eulerAngles = new Vector3(0, 0, 180);
            }
                GetComponent<Animator>().SetBool("Shoot",true);
            

        }if (Input.GetKeyUp(KeyCode.Z)) {
            GetComponent<Animator>().SetBool("Shoot", false); 
        }
       

    }
    void Move() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed; 
    
    }
    //Coletando Café 
    
    private void OnTriggerEnter2D(Collider2D collision2D)
    {

        if (collision2D.gameObject.CompareTag("Cafe"))
        {
            Destroy(collision2D.gameObject);
            Coffe++;
            TextCoffe.text = Coffe.ToString();
            if (Coffe == 10) {
                Life++;
                Coffe = 0;
                TextCoffe.text = Coffe.ToString();
                TextLife.text = Life.ToString();
            }
        }
        if (collision2D.gameObject.CompareTag("CheckPoint"))
        {
            lastCheckpoint = collision2D.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision2D)
    {if (collision2D.gameObject.CompareTag("Cafe")){}}

 
    //colissão com inimigo 
     
    public void OnCollisionEnter2D(Collision2D collision2D){
        if (collision2D.gameObject.CompareTag("Inimigo")){
            GetComponent<Animator>().SetBool("Hurt", true);
            Life--;
            
            TextLife.text = Life.ToString();
            
            if (Life ==0) {
                transform.position = lastCheckpoint.transform.position;
               
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("Hurt", false);
        }
        if (Life < 0)
        {
            Life = 0;
            TextLife.text = Life.ToString();
            Application.LoadLevel(4);
        }
        

        //colisão com plataforma e veiculo 
        if (collision2D.gameObject.CompareTag("Plataforma") || collision2D.gameObject.CompareTag("Veiculo"))
        {
            isGrounded = true;
        }
        
        //colissão com item de vida 
    
        if (collision2D.gameObject.CompareTag("Vida"))
        {
            Life++; 
        }  
        
    }
    public void OnCollisionExit2D(Collision2D collision2D){
        if (collision2D.gameObject.CompareTag("Plataforma") || collision2D.gameObject.CompareTag("Veiculo"))
        {
            isGrounded = false;
        }
        
    } public void QUEDA() {

        if (transform.position.y >= quedaMAX) {

            Life = -99;
            TextLife.text = Life.ToString();
           
        }
        


    }
}
