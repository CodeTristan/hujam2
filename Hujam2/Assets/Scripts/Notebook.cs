using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notebook : MonoBehaviour
{
    public GameObject notebook;
    public void NoteBookButton()
    {
        notebook.SetActive(true);
    }
    public void Close()
    {
        notebook.SetActive(false);
    }
}
