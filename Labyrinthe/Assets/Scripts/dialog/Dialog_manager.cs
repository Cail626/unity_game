using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_manager : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;
    public bool dialogStarted;

    public Animator animator;

    private Queue<string> sentences;

    public static Dialog_manager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de " +
                "Dialog_manager dans la scene");
        }

        instance = this;

        sentences = new Queue<string>();
        dialogStarted = false;
    }

    public void ActionDialog(Dialog dialog)
    {
        /*
         * Initiate dialog if not already initiated
         * Otherwise load the next sentence
         */

        if(!dialogStarted)
        {
            animator.SetBool("isOpen", true);

            nameText.text = dialog.name;

            sentences.Clear();

            foreach (string sentence in dialog.sentences)
            {
                sentences.Enqueue(sentence);
            }

            dialogStarted = true;
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            ;
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

    public void EndDialog()
    {
        animator.SetBool("isOpen", false);
        dialogStarted = false;
    }
}
