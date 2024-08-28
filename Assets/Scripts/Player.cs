using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameController gameController;
    private Transform[] casas; //Refer�ncia as casas no tabuleiro
    private int indiceAtual = 0;
    public Player player; //Refer�ncia ao objeto Player
    public float velocidade;


    private void Start()
    {
        casas = gameController.casas;
    }
    public void MoverParaFrente(int passos)
    {
        int novoIndice = indiceAtual + passos;
        Debug.Log(novoIndice);

        //Garante que o �ndice n�o ultrapasse o n�mero de casas dispon�veis
        if(novoIndice >= casas.Length)
        {
            novoIndice = casas.Length - 1; //�ltima casa
        }

        if (novoIndice < 0)
        {
            novoIndice = 0;
        }

        //Atualiza o �ndice Atual
        indiceAtual = novoIndice;

        if (indiceAtual < casas.Length && indiceAtual >= 0)
        {
            StartCoroutine(MoverSuavemente(casas[indiceAtual].position));
        }
        else
        {
            Debug.LogError("Tentativa de acessar um �ndice fora dos limites: " + indiceAtual);
        }
    }

    public void MoverParaTras(int passos)
    {
        indiceAtual -= passos;

        //Garante que o �ndice n�o seja menor que 0
        if (indiceAtual < 0)
        {
            indiceAtual = 0;
            Debug.Log("�ndice = 0");
        }

        StartCoroutine(MoverSuavemente(casas[indiceAtual].position));
    }

    private IEnumerator MoverSuavemente(Vector3 novaPosicao)
    {
        while(Vector3.Distance(transform.position, novaPosicao) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, novaPosicao, velocidade * Time.deltaTime);
            yield return null;
        }

        transform.position = novaPosicao; //garante que a posi��o final seja exata
    }

    public int IndiceAtual()
    {
        return indiceAtual;
    }

}
