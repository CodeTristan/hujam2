using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public string context;
    public TextMeshProUGUI text;
    public TextMeshProUGUI nameText;
    public GameObject continueButton;
    public GameObject dialogUI;
    public Image characterImage;
    public float typeSpeed;

    public Dialog[] currentDialogs;
    public int dialogCount;
    public int maxDialogCount;

    private Queue<string> sentences;
    private string sentence;

    private void Awake()
    {
        sentences = new Queue<string>();
    }
    public void StartDialog(Dialog[] dialog)
    {
        text.text = "";
        dialogUI.SetActive(true);
        currentDialogs = dialog;
        if (dialogCount == maxDialogCount)
        {
            EndDialog();
            return;
        }
        nameText.text = currentDialogs[dialogCount].Name;
        sentences.Clear();

        foreach (string sentence in dialog[dialogCount].sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public IEnumerator Type(string sentence)
    {
        text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
        continueButton.SetActive(true);
    }

    public void DisplayNextSentence()
    {
        
        continueButton.SetActive(false);
        if (dialogCount == maxDialogCount)
        {
            EndDialog();
            return;
        }
        if (sentences.Count == 0)
        {
            dialogCount++;
            StartDialog(currentDialogs);
        }
        else
        {
            sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(Type(sentence));
        }
    }
    public void EndDialog()
    {
        dialogUI.SetActive(false);
    }


}
