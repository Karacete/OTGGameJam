using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yonetici : MonoBehaviour
{
    int yerlestirilen_parca = 0;
    int toplam_puzzle = 16;

    void Start()
    {
        
    }

    public void sayi_arttir()
    {
        yerlestirilen_parca++;

        if(yerlestirilen_parca == toplam_puzzle)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void Update()
    {
        
    }
}
