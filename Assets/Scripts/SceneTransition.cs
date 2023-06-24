using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip animacionFinal;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (SceneManager.GetActiveScene().name == "Comic")
        {
            StartCoroutine(ComicScene());
        }
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            StartCoroutine(GameOverScene());
        }
    }

    public void Startcorutina(string scena)
    {
        StartCoroutine(ChangeScene(scena));
    }

    IEnumerator ChangeScene(string scena)
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene(scena);
    }

    IEnumerator ComicScene()
    {
        yield return new WaitForSeconds(31);
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene("Level");
    }
    IEnumerator GameOverScene()
    {
        yield return new WaitForSeconds(5f);
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene("Menu");
    }
}
