using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public int fuerzadeSalto;
    public int velocidaddeMov;
    bool EnelPiso = false;
    //public float SegIncremento;
    //public float TiempoActual;
    // Start is called before the first frame update
    void Start()
    {
        //TiempoActual = SegIncremento * 60;
    }

    // Update is called once per frame
    void Update()
    {
        //TiempoActual -= 1f;

       if(Input.GetKeyDown("space") && EnelPiso) 
       {
           this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzadeSalto));
       }
       this.GetComponent<Rigidbody2D>().velocity=new Vector2(velocidaddeMov, 
                this.GetComponent<Rigidbody2D>().velocity.y);


      //  if(TiempoActual < 0)
       // {
        //    velocidaddeMov += 0.01;
         //   TiempoActual = SegIncremento * 60;
        //}

    }

    

    private void OnTriggerEnter2D(Collider2D Collection)
    {
        EnelPiso = true;
        if(Collection.tag == "Enemigo1")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D Collection)
    {
        EnelPiso = false;
    } 
}
