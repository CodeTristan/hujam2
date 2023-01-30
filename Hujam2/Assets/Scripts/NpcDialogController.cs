using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogController : MonoBehaviour
{
    public GameObject Exc;
    [SerializeField] Crew crew;
    private DayManager dayManager;

    public int[] dialogDays;

    private int dialogAvaliableIndex = 1;
    private int dialogFinished = 1;
    private void Start()
    {
        dayManager = FindObjectOfType<DayManager>();
    }

    private void Update()
    {
        if(!Exc.activeSelf && dialogFinished < dialogAvaliableIndex)
        {
            Exc.SetActive(true);
        }
    }
    public void checkAvailableDialogs()
    {
        dialogAvaliableIndex = 1;
        for (int i = 0; i < dialogDays.Length; i++)
        {
            if (dayManager.dayCount >= dialogDays[i])
            {
                dialogAvaliableIndex++;
            }
        }
    }
    public void StartDialog()
    {
            checkAvailableDialogs();
            if (dialogFinished < dialogAvaliableIndex)
            {
                Debug.Log("DialogStarted");
                crew.allCharDialogs[dialogFinished].TriggerDialog();
                dialogFinished++;
            }
            else //I guess s/he is busy dialog.
            {
                Debug.Log("NO DIALOG ERROR VAR");
                crew.allCharDialogs[0].TriggerDialog();
            }
            
        
        Exc.SetActive(false);
    }
}
