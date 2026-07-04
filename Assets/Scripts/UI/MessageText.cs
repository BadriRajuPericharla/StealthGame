using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MessageText : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI messageTxt;
    public void KeyCollectMessage()
    {
        messageTxt.text="Collect The Door Key To Open";
    }
}
