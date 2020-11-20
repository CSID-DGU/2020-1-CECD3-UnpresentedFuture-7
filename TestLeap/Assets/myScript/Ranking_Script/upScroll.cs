using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upScroll : MonoBehaviour
{
    [SerializeField] Scrollbar scroll;
    
    void OnTriggerStay(Collider col)
    {
        StartCoroutine("Up");
    }
    void OnTriggerExit(Collider col)
    {
        StopCoroutine("Up");
    }

    IEnumerator Up()
    {
        for (float v = scroll.value; v <= 1; v += 0.05f)
        {
            scroll.value = v;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
