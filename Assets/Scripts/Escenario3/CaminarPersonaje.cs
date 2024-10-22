using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CaminarPersonaje : MonoBehaviour
{
    public bool activarDialogo = false;
    public float speed = 5f;
    private Animator animator;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject panel2;
    [SerializeField] private GameObject paradero;
    [SerializeField] TMP_Text texto;
    [SerializeField, TextArea(4, 6)] private string[] LineaDialogo;
    private float tipeo = 0.1f;
    private int indice;
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
            activarDialogo = true;
            DialogoPanel();
        }
        else if (activarDialogo && indice < LineaDialogo.Length && texto.text == LineaDialogo[indice])
        {
            DialogoNuevo();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            paradero.SetActive(false);
            panel.SetActive(false);
            panel2.SetActive(true);
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
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        speed = 5f;
        animator.SetBool("Caminar", true);
    }
    private void DialogoPanel()
    {
        if (activarDialogo == true)
        {
            panel.SetActive(true);
            indice = 0;
            StartCoroutine(ShowLine());
        }
    }
    private void DialogoNuevo()
    {
        indice++;
        if (indice < LineaDialogo.Length)
        {
            StartCoroutine(ShowLine());
        }
    }
    private IEnumerator ShowLine()
    {
        texto.text = string.Empty;
        foreach (char ch in LineaDialogo[indice])
        {
            texto.text += ch;
            yield return new WaitForSeconds(tipeo);
        }
    }
}