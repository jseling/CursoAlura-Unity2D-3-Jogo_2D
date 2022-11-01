using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleComputador : MonoBehaviour
{
    private Aviao aviao;
    // Start is called before the first frame update
    void Start()
    {
        aviao = GetComponent<Aviao>();
        StartCoroutine(Impulsionar());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Impulsionar()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.59f);
            aviao.DarImpulso();
        }

    }
}
