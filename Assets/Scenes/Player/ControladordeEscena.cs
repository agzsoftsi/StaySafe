using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladordeEscena : MonoBehaviour
{
    public GameObject Player;
    public Camera CamaaraDejuego;
    public GameObject[] BloquePreFab;
    public float PunteroJuego;
    public float LugarSegurodeGeneracion = 12;
    public Text TextoJuego;
    public bool PerdisteJuego;
    //public Text TextoJuegoMensaje;

    // Start is called before the first frame update
    void Start()
    {
        PunteroJuego = -7;
        PerdisteJuego = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null){
        CamaaraDejuego.transform.position = new Vector3(
            Player.transform.position.x,
            CamaaraDejuego.transform.position.y,
            CamaaraDejuego.transform.position.z
        );
        TextoJuego.text="Days: " + Mathf.Floor(Player.transform.position.x);
        
        }
        else
        {
            if(!PerdisteJuego)
            {
                PerdisteJuego = true;
                TextoJuego.text+= "\n You Lose! \n Press Space to Restart or \n Press Escape to Main Menu";
                //TextoJuegoMensaje+= "\n- Take respiratory hygiene measures\n- Wash your hands frequently\n- Maintain social distance\n- Avoid touching your eyes, nose and mouth\n- If you have fever, cough, and shortness of breath, get medical attention on time\n- Stay informed and follow the recommendations of healthcare professionals";
            }
            if(PerdisteJuego)
            {
                if(Input.GetKeyDown("space"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                 if(Input.GetKeyDown("escape"))
                {
                    SceneManager.LoadScene("Intro");
                }
            }
        }

        while(Player!=null && PunteroJuego < Player.transform.position.x + LugarSegurodeGeneracion)
        {
            int indiceBloque = Random.Range(0,BloquePreFab.Length -1);
            if(PunteroJuego < 0)
            {
                indiceBloque = 7;

            }
            GameObject ObjetoBloque = Instantiate(BloquePreFab[indiceBloque]);
            ObjetoBloque.transform.SetParent(this.transform);
            Bloque bloque= ObjetoBloque.GetComponent<Bloque>();
            ObjetoBloque.transform.position=new Vector2(
                PunteroJuego + bloque.tamaño / 2,
                0
            );
            PunteroJuego += bloque.tamaño;
        

        }
        
    }
}
