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

    private Dialog[] currentDialogs;
    public int dialogCount;
    public int maxDialogCount;

    private Queue<string> sentences;
    private string sentence;

    public DialogTrigger FirstDialog;


    private void Awake()
    {
        sentences = new Queue<string>();
    }
    private void Start()
    {
        FirstDialog.TriggerDialog();
    }
    public void StartDialog(Dialog[] dialog)  //Starts dialog
    {
        text.text = "";
        dialogUI.SetActive(true);
        currentDialogs = dialog;
        if (dialogCount == maxDialogCount) //if there is no more dialog end it.
        {
            EndDialog();
            return;
        }

        nameText.text = currentDialogs[dialogCount].Name;
        if (currentDialogs[dialogCount].sprite == null)
            characterImage.gameObject.SetActive(false);
        else
        {
            characterImage.gameObject.SetActive(true);
            characterImage.sprite = currentDialogs[dialogCount].sprite;
        }
        
        sentences.Clear();

        foreach (string sentence in dialog[dialogCount].sentences)  //Adds each string sentence to queue
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public IEnumerator Type(string sentence) //Types sentence to screen
    {
        text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
        continueButton.SetActive(true);
    }

    public void DisplayNextSentence() //Goes next element of queue
    {
        
        continueButton.SetActive(false);
        if (dialogCount == maxDialogCount)
        {
            EndDialog();
            return;
        }
        if (sentences.Count == 0) //if dialog is finished starts another one.
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
