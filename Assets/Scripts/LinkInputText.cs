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
    public string Message;
    private bool Insulter;
    private int getkarma;
    private int nbIns;
    private string reponse;
    private string MessageArray;


    private void Start()
    {
        instruction = GetComponent<Text>();
        typingtext = Typing.GetComponent<Text>();

    }

    public void CheckListeInsultes(string myString)
    {
        string[] Insultes = new string[] { "sale","batard", "connard", "bite", "enculé", "salope", "con", "pd","chocolatine","pute","fuck","mère","race","catin","putain","merde","faggot","baiseur de chèvres","consanguin","branleur"};
        foreach (string item in Insultes)
        {
            if (myString.Contains(item))
                Insulter = true;
        }
    }
    
    IEnumerator Debut()
    {
        instruction.text = "Anonyme: Ok c'est un peu stressant ici j'ai plein de boutons et différents codes à taper. Il est écrit : Si vous voulez survivre résolvez les énigmes avec votre partenaire. Sur l'instruction 1 : Taper un code à 4 Chiffres";
        yield return new WaitForSeconds(15);
        typingtext.text = "";
        instruction.text = "Anonyme: Je sais pas pour vous mais je propose qu'on fasse ce qu'il dit pour qu'on puisse s'enfuir à deux... Allez chercher le code et taper le sur la machine";
    }

    IEnumerator TypingCoroutine(string chaineApres)
    {
        instruction.text = "Anonyme: Typing...";
        yield return new WaitForSeconds(Random.Range(3, 5));
        instruction.text = chaineApres;
    }
    IEnumerator TypingCoroutineInsultes(string chaineApres)
    {
        instruction.text = "Bon";
        yield return new WaitForSeconds(10);
        instruction.text = chaineApres;
    }

        public void AttenteDebut()
    {
        StartCoroutine(Debut());
    }

    public void AttenteTyping(string chaineapres)
    {

        StartCoroutine(TypingCoroutine(chaineapres));
    }

    public void AttenteTypingInsultes(string chaineapres)
    {
        StartCoroutine(TypingCoroutineInsultes(chaineapres));
    }

    void Update()
    {
        var input = InputBox.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
    }

    private void SubmitName(string arg0)
    {
        Insulter = false;
        CheckListeInsultes(arg0);
        if (Insulter)
        {
            //Debug.Log("OK");
            nbIns = PlayerPrefs.GetInt("nbreInsultes");
            string[] ReponsesInsultes = new string[] { "Ok....", "OH!Pas la peine de m'insulter ! Je suis dans la même galère", "ON avance pas alors arrête tes insultes!", "C'est quoi ton problème!?", "Ok Sale co*****, tu l'auras voulu, je me barre sans toi" };
            reponse = ReponsesInsultes[nbIns];
            AttenteTypingInsultes(reponse);
            PlayerPrefs.SetInt("nbreInsultes", nbIns + 1);
            getkarma = PlayerPrefs.GetInt("karma") - 10;
            PlayerPrefs.SetInt("karma", getkarma);
            //Debug.Log(PlayerPrefs.GetInt("karma"));
        }

        //Debug.Log(arg0);
        //string[] Demandes = new string[] {"Anonyme: Euh ... Taper hello si vous essayer de communiquer", "Anonyme: J'ai besoin d'un code à 4 chiffres", "Anonyme: Il me faut un nom d'auteur de théatre", "Anonyme: J'ai besoin d'un code avec des chiffres et des lettres" };
        string[,] TabDemandes = new string[,] { { "Anonyme: Euh ... Taper hello si vous essayer de communiquer", "Anonyme: Dites bonjour en anglais (hello au cas où vous êtes anglophobe)", "Anonyme: Allez vous pouvez le faire h e l l o", "Anonyme: S'il vous plaît, j'ai pas envie de rester ici éternellement, taper hello", "Anonyme: Vous êtes un robot ? Je sais pas ce que me suis imaginé... hello c'est trop dur pour une IA..." },
            { "Anonyme: J'ai besoin d'un code à 4 chiffres", "Anonyme: Vous tapez des choses aléatoires sur votre clavier ? ou un bug ? Si vous voyez ça allez chercher ce code à 4 chiffres", "Anonyme: C'est pas le bon... Continuez à chercher ce code à 4 chiffres", "Anonyme: J'essaye des combinaisons au pif de mon côté mais je trouve rien... On a besoin de vous pour ce code à 4 chiffres", "Anonyme: Toujours rien sur ce code à 4 chiffres .. Perdez pas de temps, il faut faire vite" },
            { "Anonyme: J'aurais bien aimé vous aider mais ma culture en d'auteur de theatre s'eleve à 0", "Anonyme: Shakespeare ça marche pas en tout cas, j'ai déjà essayé... Je suis même pas sur qu'il ait ecrit des pieces de theatre", "ça craint, vous savez quelquechose ? Je flippe et à cause de mon inculture sur ces dramaturges au theatre, je suis coincé comme vous j'imagine...", "Anonyme: Votre salle doit être sympa, enfin j'espere... Bon je divague allez chercher ce nom dramaturge", "Anonyme: Je vous ai déjà dit que j'étais claustro? J'ai déjà entendu dire que les dramaturges avait ce même problème" },
            { "Anonyme: J'ai besoin d'un code avec des chiffres et des lettres", "Anonyme: Apparement ce code ferait reference à un evenement, je sais pas si c'est un indice...", "Anonyme: Je sais pas quoi vous dire moi... Juste trouvez ce nom code", "Anonyme: Alors... Si il y avait un manuel <Comment sortir d'ici> avec ça ce serait plus simple ", "Anonyme: Je me demande combien de codes on va devoir déchiffrer surtout qu'ils deviennent de plus en plus long : 11 ici" },
            { "Anonyme: J'ai jamais ete bon en maths perso,j'espere que vous vous serez meilleur que moi", "Anonyme: Le fait est qu'on est coincé ici surement pour un bon temps donc je vais taper des chiffres aleatoires", "Vous pensez que le mec qui nous a enferme s'amuse à nous regarder trouver des codes dans tous les coins?", "Anonyme: J'ai une caméra au-dessus de moi.... Faites ces maths vite, je me sens pas bien", "Anonyme: AZJRoaziirzajrpaoipoaziepirp. Oula desole j'ai ecrit sur le mauvais truc... Ouais bon j'ai pas grand chose pour m'amuser le temps que vous cherchez ce problème" }
            ,{"Anonyme: ","Anonyme:","Anonyme:","Anonyme:","Anonyme:" }
        };
        //Debug.Log(PlayerPrefs.GetInt("num_enigme"));
        num_enigme = PlayerPrefs.GetInt("num_enigme");

        if (arg0.Contains("hello") && num_enigme == 0)
        {
            //instruction.text = "Anonyme: Ok c'est un peu stressant ici j'ai plein de boutons et différents codes à taper. Il est écrit : Si vous voulez survivre résolvez les énigmes avec votre partenaire. Sur l'instruction 1 : Taper un code à 4 Chiffres";
            AttenteDebut();
            //instruction.text = "Anonyme: Je sais pas pour vous mais je propose qu'on fasse ce qu'il dit pour qu'on puisse s'enfuir à deux... Allez chercher le code et taper le sur la machine";
            PlayerPrefs.SetInt("num_enigme", 1);
        }

        else if (arg0.Contains("1234") && num_enigme == 1)
        {
            Message = "Anonyme: 1234 ça clignotte ! ça doit être bon signe ! Maintenant : un nom d'auteur de théatre";
            AttenteTyping(Message);
            PlayerPrefs.SetInt("num_enigme", 2);
        }

        else if (arg0.Contains("Molière") && num_enigme == 2)
        {
            Message = "Anonyme: Molière... On est sur la bonne voie! Un code avec des chiffres et lettres en majuscules";
            AttenteTyping(Message);
            //instruction.text = "Anonyme: Molière... On est sur la bonne voie! Il faut un code ";
            PlayerPrefs.SetInt("num_enigme", 3);
        }

        else if (arg0.Contains("3MAGWAJ8102") && num_enigme == 3)
        {
            Message = "Anonyme: Aucun sens cette merde!Bref, Prochain truc à chercher: Un mot codé avec un language ancien ";
            AttenteTyping(Message);
            //instruction.text = "Anonyme: Aucun sens cette merde! Bref, Prochain truc à chercher: Un mot codé avec un language ancien ";
            PlayerPrefs.SetInt("num_enigme", 4);
        }

        else if (arg0.Contains("never") && num_enigme == 4)
        {
            Message = "Anonyme: Ah ouais le morse ... J'y aurais pas pensé, continuez comme ça on est sur la bonne voie ! Il faut maintenant <<un resultat à 4 chiffres>>, des maths peut-être ? ";
            AttenteTyping(Message);
            //instruction.text = "Anonyme: Aucun sens cette merde! Bref, Prochain truc à chercher: Un mot codé avec un language ancien ";
            PlayerPrefs.SetInt("num_enigme", 5);
        }

        else if (arg0.Contains("123456") && num_enigme == 5)
        {
            Message = "Anonyme: Vous devez être bon en maths, on a de la chance! Allez c'est parti pour un autre code... 6 digits cette fois, c'est reparti pour vous";
            AttenteTyping(Message);
            //instruction.text = "Anonyme: Aucun sens cette merde! Bref, Prochain truc à chercher: Un mot codé avec un language ancien ";
            PlayerPrefs.SetInt("num_enigme", 6);
        }

        else
        {
            MessageArray = TabDemandes[num_enigme, Random.Range(0, 5)];
            //Message = Demandes[num_enigme];
            AttenteTyping(MessageArray);

            //instruction.text = Demandes[num_enigme];
        }
    }

}

