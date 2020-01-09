using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Clases;
using System.Linq;

//En este scripts se escribiran todos los estados necesarios para el juego
public class Estados: MonoBehaviour
{
    /*public static bool isPaused = false;/// <summary>
    /// Dice si el juego esta pausado o no 
    /// </summary>
    */
    //Estados en el uso del arco (apuntando, disparando)
    

    public GameObject enemigoCuchillo;
    public GameObject enemigoRango;
    public GameObject enemigoMachete;
    public GameObject enemigoPesado;
    public GameObject checkPoint;
    public GameObject cofre;

    static GameObject EnemigoCuchillo;
    static GameObject EnemigoRango;
    static GameObject EnemigoMachete;
    static GameObject EnemigoPesado;
    static GameObject CheckPoint;
    static GameObject Cofre;


    public enum eEstadoArco{
        Nada,
        Apuntando, 
        Disparando
    }
    public enum eEstadoAccionJugador
    {
        Nada,
        Leyendo
    }
    public enum eEstadoJugador
    {
        Nada,
        Atacando
    }
    public enum eEstadoJuego
    {
        Play,
        Pause,
    }

    public static eEstadoArco EstadoArco;
    public static eEstadoAccionJugador EstadoAccion;
    public static eEstadoJugador EstadoJugador;
    public static eEstadoJuego EstadoJuego;


    public static bool JuegoCompletado = false;
    public static int indiosCapturados = 3; //cuando llege a 0, se termina el juego
    public static bool NewGame = true;

    static GameObject[] Cofres;
    static GameObject[] enEscena;



    private void Awake()
    {
        EstadoJuego = eEstadoJuego.Play;
        EnemigoCuchillo = enemigoCuchillo;
        EnemigoMachete = enemigoMachete;
        EnemigoRango = enemigoRango;
        EnemigoPesado = enemigoPesado;
        CheckPoint = checkPoint;
        
    }
    private void Start()
    {

        if (!NewGame)
        {

            SaveState.LoadGame();

        }
        enEscena = GameObject.FindGameObjectsWithTag("EnemigoMachete").
           Concat(GameObject.FindGameObjectsWithTag("EnemigoRango").
           Concat(GameObject.FindGameObjectsWithTag("EnemigoNormalCuchillo").
           Concat(GameObject.FindGameObjectsWithTag("Pesado")))).ToArray();


    }
    private void Update()
    {
        
        if(EstadoJuego == eEstadoJuego.Play)
        {
            Time.timeScale = 1;
        }
        else if(EstadoJuego == eEstadoJuego.Pause)
        {
            Time.timeScale = 0;
        }


    }
    public static void cargarEnemigos()
    {

        foreach (GameObject enemigo in enEscena)
        {
            if(enemigo.tag != "BOSS2" || enemigo.tag != "Boss1")
            {
                if (!enemigo.activeSelf)
                {
                    enemigo.SetActive(true);
                }

            }
        }

            recargarVida(enEscena);
        
    }
    public static void cargarCheckpoints(List<Vector2> checkpoints)
    {
        GameObject[] enEscena = GameObject.FindGameObjectsWithTag("CheckPoint");
        foreach (Vector2 checkpoint in checkpoints)
        {
            if (!enEscena.Select(o => o.transform.position).Contains(checkpoint))
            {
                Instantiate(CheckPoint,checkpoint,Quaternion.identity);
            }
        }
    }
    public static void cargarJugador(PlayerStats player)
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = player.posicionJugador;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>().vida = 100;
    }
    private static void recargarVida(GameObject[] enemigos)
    {
        foreach(GameObject enemigo in enemigos)
        {
            if(enemigo.tag == "EnemigoRango")
            {
                enemigo.GetComponent<RangeEnemyControl>().vida = enemigo.GetComponent<RangeEnemyControl>().vidaInicial;
            }
            else
            {
                enemigo.GetComponent<Enemigo>().vida = enemigo.GetComponent<Enemigo>().vidaInicial;

            }

        }

    }
   


    public static void cargarJugadorCompleto(PlayerStats player, int vida)
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = player.posicionJugador;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>().vida = vida;

    }

    public static List<Items> guardarItems()
    {
        
        List<Items> Items = new List<Items>();

        if (Inventario.SlotCuchillo)
        {
            Items.Add(new Items("Cuchillo", 0, true));
        }
        if (Inventario.SlotArco)
        {
            Items.Add(new Items("Arco", Inventario.totalFlechas, true));

        }
        else
        {
            Items.Add(new Items("Arco", 0, false));
        }

        if (Inventario.SlotLanza)
        {
            Items.Add(new Items("Lanza", 0, true));
        }

        if (Inventario.SlotObjeto)
        {
            Items.Add(new Items("Objeto", Inventario.totalPociones, true));
        }
        else
        {
            Items.Add(new Items("Objeto", 0, false));
        }



            return Items;
    } 
    public static void CargarItems(List<Items> items)
    {
        foreach(Items item in items)
        {
            switch (item.Nombre)
            {
                case "Cuchillo":
                    Inventario.SlotCuchillo = item.Desbloqueado;
                    break;
                case "Arco":
                    Inventario.SlotArco = item.Desbloqueado;
                    Inventario.totalFlechas = item.Cantidad;
                    break;
                case "Lanza":
                    Inventario.SlotLanza = item.Desbloqueado;
                    break;
                case "Objeto":
                    Inventario.SlotObjeto = item.Desbloqueado;
                    Inventario.totalPociones = item.Cantidad;
                    break;
            }
        }
    }

    public static GameObject[] guardarCofres()
    {
        GameObject[] cofres = GameObject.FindGameObjectsWithTag("Cofre");
        return cofres;
    }
    public static void CargarCofres(GameObject[] Cofres)
    {
        foreach(GameObject cofre in GameObject.FindGameObjectsWithTag("Cofre"))
        {
            foreach(GameObject cargaCofre in Cofres)
            {
                if(cofre.transform.position == cargaCofre.transform.position)
                {
                    cofre.GetComponent<chestControl>().abierto = 
                        cargaCofre.GetComponent<chestControl>().abierto;
                    continue;
                }
            }
        }
    }

    public static List<GameObject> guardarJefes()
    {
        List<GameObject> Boss = new List<GameObject>();
        Boss.Add(GameObject.FindGameObjectWithTag("Boss1"));
        Boss.Add(GameObject.FindGameObjectWithTag("BOSS2"));

        return Boss;
    }
    public static void cargarJefes(List<GameObject> Boss)
    {
        if(Boss[0] != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Boss1"));
        }
        
        if(Boss[1] != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("BOSS2"));
        }
    }



    public static void Pausar()
    {
        //EstadoJuego = eEstadoJuego.Play
       
    }
    public static void Resumir()
    {
       // isPaused = false;

           

    }


}
