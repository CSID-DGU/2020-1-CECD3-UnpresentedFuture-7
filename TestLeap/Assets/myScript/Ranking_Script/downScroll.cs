using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class downScroll : MonoBehaviour
{
    [SerializeField] Scrollbar scroll;

    void OnTriggerStay(Collider col)
    {
        StartCoroutine("Down");
    }
    void OnTriggerExit(Collider col)
    {
        StopCoroutine("Down");
    }

    IEnumerator Down()
    {
        for (float v = scroll.value; v >= 0; v -= 0.05f)
        {
            scroll.value = v;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
