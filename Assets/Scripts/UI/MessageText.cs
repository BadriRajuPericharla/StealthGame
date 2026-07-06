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
        
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        messageTxt.enabled=true;
        messageTxt.text="Collect The Door Key To Open";
        yield return new WaitForSeconds(1.5f);
        messageTxt.enabled=false;
    }
}
