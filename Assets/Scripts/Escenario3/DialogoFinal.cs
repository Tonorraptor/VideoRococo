using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogoFinal : MonoBehaviour
{
    public bool activarDialogo = false;
    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text texto;
    [SerializeField, TextArea(4, 6)] private string[] LineaDialogo;
    private float tipeo = 0.1f;
    private int indice;
    public string name;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            activarDialogo = true;
            DialogoPanel();
        }
        else if (activarDialogo && indice < LineaDialogo.Length && texto.text == LineaDialogo[indice])
        {
            DialogoNuevo();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(name);
        }
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
