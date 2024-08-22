using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform[] casas;
    private int indiceAtual = 0;
    public float velocidade = 5f;

    public void MoverParaFrente(int passos)
    {
        indiceAtual += passos;

        if(indiceAtual>= casas.Length)
        {
            indiceAtual = casas.Length - 1;
        }

        StartCoroutine(MoverSuavemente(casas[indiceAtual].position));
    }

    public void MoverParaTras(int passos)
    {
        indiceAtual -= passos;

        if (indiceAtual < 0)
        {
            indiceAtual = 0;
        }
        StartCoroutine(MoverSuavemente(casas[indiceAtual].position));
    }

    private IEnumerator MoverSuavemente(Vector3 novaPosicao)
    {
        while(Vector3.Distance(transform.position, novaPosicao) > 0.01)
        {
            transform.position = Vector3.MoveTowards(transform.position, novaPosicao, velocidade * Time.deltaTime);
            yield return null;
        }

        transform.position = novaPosicao;
    }


    // Start is called before the first frame update
    void Start()
    {
        transform.position = casas[indiceAtual].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
