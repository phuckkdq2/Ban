using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;

    GameController m_gc;

    Rigidbody2D m_rb;

    public GameObject hitVFX;
    GameObject m_VFX;

    // Start is called before the first frame update
    void Start()
    {
        
        m_rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeToDestroy);

        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.up * speed ;
    }

    public void showVFX(){
        m_VFX =  Instantiate(hitVFX, transform.position, Quaternion.identity);
        Destroy(m_VFX, 2);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){

            // tạo hiệu ứng nổ 
            showVFX();
            m_gc.ScoreIncrement();
            Destroy(gameObject);           // huy vien dan
            Destroy(other.gameObject);      // huy enemy
            
            
        }else if(CompareTag("SceneTopLimit")){
            Destroy(gameObject);  
        }
    }
}
