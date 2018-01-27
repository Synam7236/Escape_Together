using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkInputText : MonoBehaviour {
    public GameObject InputBox;
    public GameObject Typing;
    Text instruction;
    Text typingtext;
    public int num_enigme;


    private void Start()
    {
        instruction = GetComponent<Text>();
        typingtext = Typing.GetComponent<Text>();

    }


    IEnumerator Typingsomething()
    {
        
        yield return new WaitForSeconds(5);
        
    }


    public void Attente()
    {
        Debug.Log(typingtext.text);
        typingtext.text = "Typing...";
        Debug.Log(typingtext.text);
        System.Threading.Thread.Sleep(100);
        typingtext.text = "";
        Debug.Log(typingtext.text);
    }

    void Update()
    {
        var input = InputBox.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;

        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }

    private void SubmitName(string arg0)
    {
        bool[] enigmes = new bool[20];
        Debug.Log(enigmes);
        Debug.Log(enigmes[1]);
        Debug.Log(arg0);
        string[] Demandes = new string[] { "Anonyme: Dit moi hello", "Anonyme: J'ai besoin d'un code à 4chiffres", "Anonyme: Un nom d'auteur de théatre" };
        Debug.Log(PlayerPrefs.GetInt("num_enigme"));
        num_enigme = PlayerPrefs.GetInt("num_enigme");

        if (arg0 == "hello" && num_enigme == 0)
        {
            enigmes[0] = true;
            Debug.Log("Boucle hello");
            Attente();
            instruction.text = "Anonyme: Ok c'est un peu stressant ici j'ai plein de boutons et différents codes à taper. Il est écrit : Si vous voulez survivre résolvez les énigmes avec votre partenaire. Sur l'instruction 1 : Taper un code à 4 Chiffres";
            PlayerPrefs.SetInt("num_enigme", 1);

        }
       else if (arg0 == "1234" && num_enigme == 1)
        {
            enigmes[1] = true;
            Debug.Log("Boucle 1234");
            Attente();
            instruction.text = "Anonyme: 1234 ça clignotte ! ça doit être bon signe ! Maintenant un nom d'auteur de théatre";
            PlayerPrefs.SetInt("num_enigme", 2);
        }
        else if(arg0 == "Molière" && num_enigme == 2)
        {
            enigmes[2] = true;
            Debug.Log("Boucle Molière");
            Attente();
            instruction.text = "Anonyme: Molière ok";
            PlayerPrefs.SetInt("num_enigme", 3);
        }
        else
        {
           instruction.text = "Anonyme: C'est pas ça que je t'ai demandé";
           Attente();
           instruction.text = Demandes[num_enigme];
        }
    }

}

