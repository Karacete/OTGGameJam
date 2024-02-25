using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalAraSahneScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(JumpScare());
    }
    IEnumerator JumpScare()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
