using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("Sonraki bolume gec");
        }
    }

    void Update()
    {
        
    }
}
