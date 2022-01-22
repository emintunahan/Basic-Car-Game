using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class car : MonoBehaviour
{
    float horizontal;
    Rigidbody2D rigid;
    public float hiz;
    int puan;
    public Text puantext;
    Vector3 toplam, fark;
    public GameObject camera;
    float zaman;
    int sayac;
    public Text zamantext;
    public Text uyaritext;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        fark = camera.transform.position - transform.position; // kameray� araba ile hareket ettirme
        uyaritext.text = "B�l�m� bitirmek i�in 10 saniyeniz var";
    }

    
    void Update()
    {
        arabahareket();
        puantext.text = "Puan:  " + puan; // paun� ekrana yazd�rma 
        toplam = transform.position + fark; // kameray� araba ile hareket ettirme
        camera.transform.position = new Vector3(toplam.x, toplam.y, camera.transform.position.z); // kameray� araba ile hareket ettirme
        zamanyazdir();
        zamantext.text = "S�re: " + sayac;
        if (sayac == 1)
        {
            uyaritext.gameObject.SetActive(false);
        }
        else if (sayac == 10)
        {
            uyaritext.text = "Oyun Bitti";
        }
        else if (sayac == 11) 
        {
            SceneManager.LoadScene(0);
        }
    }
    void arabahareket()
    {
        horizontal = Input.GetAxis("Horizontal");
        rigid.AddForce(new Vector3(horizontal*hiz, 0, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            puan++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag=="Finish")
        {
            Debug.Log("Oyun Bitti");
            uyaritext.gameObject.SetActive(false);
            uyaritext.text = "Oyun Bitti";
            SceneManager.LoadScene(0);

        }
    }
    void zamanyazdir()
    {
        zaman += Time.deltaTime; //zaman=zaman + time.deltatime;
        if (zaman > 1)
        {
            sayac++;
            zaman = 0;
        }
    }
}

