using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo3 : MonoBehaviour
{
    public bool activarDialogo = false;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject personaje;
    [SerializeField] GameObject personaje2;
    [SerializeField] TMP_Text texto;
    [SerializeField, TextArea(4, 6)] private string[] LineaDialogo;
    private float tipeo = 0.1f;
    private int indice;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            personaje.SetActive(true);
            activarDialogo = true;
            DialogoPanel();
        }
        else if (activarDialogo && indice < LineaDialogo.Length && texto.text == LineaDialogo[indice])
        {
            DialogoNuevo();
        }
    }
    private void DialogoPanel()
    {
        if (activarDialogo == true)
        {
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
        else
        {
            personaje2.SetActive(true);
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