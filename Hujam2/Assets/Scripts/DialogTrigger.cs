using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public string Context;
    public Dialog[] dialogs;

    private DialogManager manager;
    private int index;

    private void Start()
    {
        manager = FindObjectOfType<DialogManager>();
    }
    public void TriggerDialog()
    {
        manager.maxDialogCount = dialogs.Length;
        manager.dialogCount = 0;
        manager.StartDialog(dialogs);
        manager.context = Context;
    }
}
