using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver_popupScript : MonoBehaviour
{
    [HideInInspector]
    public string needLevel = null;
    //void Start()
    //{
    //    StartCoroutine(Loads());
    //}

    //IEnumerator Loads()
    //{
    //    yield return new WaitForSeconds(1f);
    //    AsyncOperation loadsScens = SceneManager.LoadSceneAsync(SettingsCur.nomderLoadScens);

    //    while (!loadsScens.isDone)
    //    {
    //        yield return null;
    //    }
    //}
    private void Update()
    {
        if(needLevel != null && Input.anyKeyDown)
        {
            AsyncOperation loadsScens = SceneManager.LoadSceneAsync(needLevel);
        }
    }
}
