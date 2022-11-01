using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AtivarJogadorAnimacao : MonoBehaviour
{
    [SerializeField]
    private UnityEvent aoTerminarAnimacao;
    public void AtivarJogador()
    {
        aoTerminarAnimacao.Invoke();
    }
}
