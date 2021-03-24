using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popuptext : MonoBehaviour
{
    public GameObject thankyoutext;
    private bool activated;
    // Start is called before the first frame update

    public void poptext()
    {
        if (!activated)
        {
            activated = true;
            thankyoutext.SetActive(true);
        }

    }
}
