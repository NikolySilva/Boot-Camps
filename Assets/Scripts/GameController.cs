using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public Transform[] casas;
    public Player jogador;
    public GameObject painel;
    public Pergunta[] perguntas;
    public TMP_Text textoPerg;

    public void Opcao1()
    {

    }

    public void Opcao2()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        textoPerg.text = perguntas[0].pergunta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
