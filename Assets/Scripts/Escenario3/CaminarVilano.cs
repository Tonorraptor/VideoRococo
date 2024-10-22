using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminarVilano : MonoBehaviour
{
    public float speed = 0f;
    private Animator animator;
    void Start()
    {
        //animator = GetComponent<Animator>();
        //animator.SetBool("Caminar", true);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.W))
        {
            speed= 5f;
        }
    }

}