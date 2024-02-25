using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tasi : MonoBehaviour
{
    Camera kamera;
    Vector2 baslangic_pozisyonu;
    GameObject[] kutu_dizisi;
    yonetici yonet;

    private void OnMouseDrag()
    {
        Vector3 pozisyon = kamera.ScreenToWorldPoint(Input.mousePosition);
        pozisyon.z=0;
        transform.position = pozisyon;
    }

    void Start()
    {
        kamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        baslangic_pozisyonu = transform.position;

        kutu_dizisi = GameObject.FindGameObjectsWithTag("kutu");
        yonet = GameObject.Find("yonetici").GetComponent<yonetici>();
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            foreach(GameObject kutu in kutu_dizisi)
            {
                if(kutu.name == gameObject.name)
                {
                    float mesafe = Vector3.Distance(kutu.transform.position , transform.position);

                    if(mesafe <=1)
                    {
                        transform.position = kutu.transform.position;
                        yonet.sayi_arttir();
                        this.enabled=false;
                    }

                    else
                    {
                        transform.position=baslangic_pozisyonu;
                    }
                }
            }
        }
    }
}
