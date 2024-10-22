using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camino : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject paradero;
    public string name;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Caminar", true);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            panel.SetActive(false);
            paradero.SetActive(false);
        }
    }

    // Detect collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stop"))
        {
            speed = 0f;
            animator.SetBool("Caminar", false);
            panel.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(name);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        speed = 5f;
        animator.SetBool("Caminar", true);
    }
}