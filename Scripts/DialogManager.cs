using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject DialogBox;
    [SerializeField] private Text DialogText;
    [SerializeField] private GameObject zbutton;
    private Dialog dialog;
    private int currentline = 0;
    public float typespeed;
    private bool isTyping;
    private bool ondialog;

    public static DialogManager instance { get; private set; }

    void Awake()
    {
        instance = this;
    }
    public void ShowDialog(Dialog dialog)
    {
        // yield return new WaitForEndOfFrame(); this is if happen in interaction with NPC
        this.dialog = dialog;
        DialogBox.SetActive(true);
        ondialog = true;
        StartCoroutine(TypeDialog(dialog.Lines[currentline]));
    }

    public IEnumerator TypeDialog(string dialog)
    {
        isTyping = true;
        FindObjectOfType<SFX>().setVolume("levels", 0.15f);
        FindObjectOfType<SFX>().setVolume("theme", 0.3f);
        zbutton.SetActive(false);
        DialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {

            DialogText.text += letter;
            FindObjectOfType<SFX>().Play("dialog_type");
            yield return new WaitForSeconds(typespeed);
        }
        zbutton.SetActive(true);
        isTyping = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && isTyping == false && ondialog == true)
        {
            FindObjectOfType<SFX>().Play("dialog_next");
            currentline++;
            if (currentline < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentline]));
            }
            else
            {
                currentline = 0;
                DialogBox.SetActive(false);
                ondialog = false;
                FindObjectOfType<SFX>().setVolume("levels", 0.4f);
                FindObjectOfType<SFX>().setVolume("theme", 0.8f);
                StartCoroutine(waittowalk());
            }

        }
    }

    IEnumerator waittowalk()
    {
        yield return new WaitForSeconds(1f);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<player_control>().startmove();
    }
}
