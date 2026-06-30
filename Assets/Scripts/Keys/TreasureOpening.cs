using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureOpening : MonoBehaviour
{
    public Keys keys;
    public GameObject player;
    public float ClaimRange=3f;
    public InventoryManager inventoryManager;
    public GameObject pointLight;
    public string[] RequiredKeyNames;
    bool allKeysCollected;
    Animator animator;
    void Start()
    {
        animator=GetComponent<Animator>();
    }
    void Update()
    {
        float distance=Vector3.Distance(transform.position,player.transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance<ClaimRange)
        {
            allKeysCollected=true;
            for(int i = 0; i < RequiredKeyNames.Length; i++)
            {
                
                if (!inventoryManager.HasTreasureKey(RequiredKeyNames[i]))
                {
                    allKeysCollected=false;
                    break;
                }
                if (allKeysCollected)
                {
                    animator.SetBool("IsOpen",true);
                    pointLight.SetActive(true);
                    StartCoroutine(GameComplete());
                    Debug.Log("Win");
                }
            }
        }
    }
    IEnumerator GameComplete()
    {
        yield return new WaitForSeconds(1.5f);
        UiManager.instance.ShowGameComplete();
    }
}
