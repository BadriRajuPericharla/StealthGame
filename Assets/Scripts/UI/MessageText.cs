using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MessageText : MonoBehaviour
{
    public static MessageText instance;
    void Awake()
    {
        if (instance == null)
        {
            instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public TextMeshProUGUI messageTxt;
    public void KeyCollectMessage()
    {
        messageTxt.text="Collect The Door Key To Open";
        StartCoroutine(Timer());
    }
    public void TreasureOpenMessage()
    {
        messageTxt.text="Collect All The Keys To Open Treasure";
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        messageTxt.enabled=true;
        yield return new WaitForSeconds(1.5f);
        messageTxt.enabled=false;
    }
}
