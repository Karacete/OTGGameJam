using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class JumpScareScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(JumpScare());
    }
    IEnumerator JumpScare()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
