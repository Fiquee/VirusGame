using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator sceneAnim;
    public string NextScene;
    // Start is called before the first frame update


    public void nextScene()
    {
        level_indicator.instance.level_index++;
        StartCoroutine("movetonextScene");
    }

    IEnumerator movetonextScene()
    {
        int level = level_indicator.instance.level_index;
        sceneAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(NextScene + "" + level.ToString());
    }

    public void playlevel()
    {
        StartCoroutine(startlevel());
    }
    IEnumerator startlevel()
    {
        int level = level_indicator.instance.level_index;
        sceneAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(NextScene + "" + level.ToString());
    }

    public void creditscene()
    {
        level_indicator.instance.level_index++;
        StartCoroutine(startcreditscene());
    }
    IEnumerator startcreditscene()
    {
        int level = level_indicator.instance.level_index;
        sceneAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SFX.instance.mainmenu = true;
        SceneManager.LoadScene(NextScene); //NextScene == credit scene
    }

    public void backtoMainMenu()
    {
        StartCoroutine(Mainmenu());
    }
    IEnumerator Mainmenu()
    {
        int level = level_indicator.instance.level_index;
        sceneAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(NextScene); //NextScene == main menu
    }
}
