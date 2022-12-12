using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notebook : MonoBehaviour
{
    public GameObject notebook;
    public GameObject previouspage;
    public GameObject nextpage;
    public GameObject stats;
    public GameObject crewnotes;
    public Image crewimage;
    public TextMeshProUGUI[] crewtexts;
    public Sprite[] portraits;
    public string[] names;
    public string[] occupations;
    public string[] descriptions;
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
                crewtexts[0].SetText(names[0]);
                crewtexts[1].SetText(occupations[0]);
                crewtexts[2].SetText(descriptions[0]);
                crewimage.sprite = portraits[0];
                break;
            case 2:
                crewtexts[0].SetText(names[1]);
                crewtexts[1].SetText(occupations[1]);
                crewtexts[2].SetText(descriptions[1]);
                crewimage.sprite = portraits[1];
                break;
            case 3:
                crewtexts[0].SetText(names[2]);
                crewtexts[1].SetText(occupations[2]);
                crewtexts[2].SetText(descriptions[2]);
                crewimage.sprite = portraits[2];
                break;
            case 4:
                nextpage.SetActive(true);
                crewtexts[0].SetText(names[3]);
                crewtexts[1].SetText(occupations[3]);
                crewtexts[2].SetText(descriptions[3]);
                crewimage.sprite = portraits[3];
                break;
            case 5:
                nextpage.SetActive(false);
                crewtexts[0].SetText(names[4]);
                crewtexts[1].SetText(occupations[4]);
                crewtexts[2].SetText(descriptions[4]);
                crewimage.sprite = portraits[4];
                break;

            default:
                break;
        }
    }
}
