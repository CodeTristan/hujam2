using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;

public class Notebook : MonoBehaviour
{
    public GameObject notebook;
    public GameObject previouspage;
    public GameObject nextpage;
    public GameObject stats;
    public GameObject crewnotes;
    public int page;
    public void NoteBookButton()
    {
        notebook.SetActive(true);
    }
    public void Close()
    {
        notebook.SetActive(false);
    }
    public void PageChange(string whichpage)
    {
        if (whichpage=="next")
        {
            page++;
        }
        else if (whichpage=="previous")
        {
            page--;
        }
        switch (page)
        {
            case 0:
                previouspage.SetActive(false);
                stats.SetActive(true);
                crewnotes.SetActive(false);
                break;
            case 1:
                previouspage.SetActive(true);
                stats.SetActive(false);
                crewnotes.SetActive(true);
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                nextpage.SetActive(true);
                break;
            case 5:
                nextpage.SetActive(false);
                break;

            default:
                break;
        }
    }
}
