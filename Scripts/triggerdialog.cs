using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerdialog : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogManager.instance.ShowDialog(dialog);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<player_control>().stopmove();
        }
    }
}
