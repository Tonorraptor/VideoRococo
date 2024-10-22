using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje1 : MonoBehaviour
{
    [SerializeField] private GameObject objeto;
    public float speed = 4f;
    private Animator animator;

    void Start()
    {
        //animator = GetComponent<Animator>();
        //animator.SetBool("Caminar", true);
    }
    // Update is called once per frame
    void Update()
    {

        if (objeto.activeSelf)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    // Detect collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stop"))
        {
            speed = 0f;
            //animator.SetBool("Caminar", false);
        }
    }
}