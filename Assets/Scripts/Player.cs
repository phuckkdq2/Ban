using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    public GameObject projectile;
    public Transform shootingPoint;

     GameController m_gc;

    public AudioSource aus;

    public AudioClip shootingSound;

    public AudioClip dieSound;

    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(m_gc.IsGameOver()){
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
        
        float xDir = Input.GetAxisRaw("Horizontal");
        // gioi han di chuyen toa do x
        if( (xDir < 0 && transform.position.x <= -8.1f) || (xDir > 0 && transform.position.x > 8.1f)){
            return;
        }

        transform.position += Vector3.right * moveSpeed * xDir  * Time.deltaTime ;

        float yDir = Input.GetAxisRaw("Vertical");
        // gioi han di chuyen toa do y
        if( (yDir < 0 && transform.position.y <= -4.7f) || (yDir > 0 && transform.position.y > 4f)){
            return;
        }
        
        transform.position += yDir * Vector3.up * moveSpeed * Time.deltaTime;

        
    }

    public void Shoot(){
        if(projectile && shootingPoint){
            Instantiate(projectile, shootingPoint.position, Quaternion.identity);
            if(aus && shootingSound){
                aus.PlayOneShot(shootingSound);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
    if(other.CompareTag("Enemy")){
            if(aus && dieSound){
                aus.PlayOneShot(dieSound);
            }
            m_gc.SetGameOverState(true);
            Destroy(other.gameObject);
            

        }
        
    }

}
