using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;

    GameController m_gc;

    Rigidbody2D m_rb;

    public AudioSource aus;
    public AudioClip dieSound;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();

        m_gc = FindObjectOfType<GameController>();

        aus = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.down * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("DeathZone")){
            if(aus && dieSound){
                aus.PlayOneShot(dieSound);
            }
            m_gc.SetGameOverState(true);
            Destroy(gameObject);
        }
    }
}
