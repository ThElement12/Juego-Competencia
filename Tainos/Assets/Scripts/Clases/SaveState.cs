using Assets.Scripts.Clases;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;


public class SaveState : MonoBehaviour
{
    static Estados estados;
    static GameObject Player;
    static string RutaXML;
    static string RutaXMLCompleto;
    public static Game CurrentGame;
    public static CompleteGame JuegoCompleto;
  
    // Start is called before the first frame update
    void Start()
    {
        RutaXML = Application.persistentDataPath + "/CaonaboCheckPoint.xml";
        RutaXMLCompleto = Application.persistentDataPath + "/CaonaboGame.xml";
        Player = GameObject.FindGameObjectWithTag("Player");


    }
    public static void SaveGame(List<Items> items, GameObject[] cofres, List<GameObject> Jefes)
    {
        JuegoCompleto = new CompleteGame(new PlayerStats(Player.transform.position), Player.GetComponent<Jugador>().vida, items, Jefes);
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(CompleteGame));
        using (FileStream fstream = new FileStream(RutaXMLCompleto, FileMode.Create))
        {
            dcSerializer.WriteObject(fstream, JuegoCompleto);
        }

    }
    public static void saveState(GameObject checkPoint)
    {
        CurrentGame = new Game(new PlayerStats(Player.transform.position), checkPoint);

        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Game));
        using (FileStream fstream = new FileStream(RutaXML, FileMode.Create))
        {
            dcSerializer.WriteObject(fstream, CurrentGame);
        }
    }

    public static void LoadGame()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(CompleteGame));
        try
        {
            using (FileStream fstream = new FileStream(RutaXMLCompleto, FileMode.Open))
            {

                JuegoCompleto = (CompleteGame)dcSerializer.ReadObject(fstream);
                Estados.CargarItems(JuegoCompleto.ItemsJugador);
                Estados.cargarJefes(JuegoCompleto.Bosses);
                Estados.cargarJugadorCompleto(JuegoCompleto.Jugador, JuegoCompleto.VidaPlayer);

            }

        }
        catch (FileNotFoundException)
        {

            print("Error al Cargar");

        }
    }
    public static void LoadState()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Game));
        try
        {
            using (FileStream fstream = new FileStream(RutaXML, FileMode.Open))
            {

                CurrentGame = (Game)dcSerializer.ReadObject(fstream);
                Estados.cargarEnemigos();
                Estados.cargarCheckpoints(CurrentGame.CheckPoint);
                Estados.cargarJugador(CurrentGame.Player);
            }

        }
        catch (FileNotFoundException)
        {

            print("Error al Cargar");

        }

    }


}
