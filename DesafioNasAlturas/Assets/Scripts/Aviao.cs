using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Aviao : MonoBehaviour
{
    [SerializeField]
    private float forca = 10f;

    private Rigidbody2D rigidBody;

    private Vector3 posicaoInicial;
    private bool deveImpulsionar;

    private Animator animacao;

    [SerializeField]
    private UnityEvent aoBater;

    [SerializeField]
    private UnityEvent aoPassarPeloObstaculo;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        posicaoInicial = transform.position;
        animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animacao.SetFloat("VelocidadeY", rigidBody.velocity.y);
    }

    void FixedUpdate()
    {
        if (deveImpulsionar)
        {
            Impulsionar();
            deveImpulsionar = false;
        }
    }

    public void DarImpulso()
    {
        deveImpulsionar = true;
    }

    private void Impulsionar()
    {
        rigidBody.velocity = Vector2.zero;
        rigidBody.AddForce(Vector2.up * forca, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidBody.simulated = false;
        aoBater.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        aoPassarPeloObstaculo.Invoke();
    }
    public void Reiniciar()
    {
        transform.position = posicaoInicial;
        rigidBody.simulated = true;
    }
}
