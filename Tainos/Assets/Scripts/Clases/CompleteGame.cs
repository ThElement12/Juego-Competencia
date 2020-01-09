using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

namespace Assets.Scripts.Clases
{
    [DataContract]
    public class CompleteGame
    {
        [DataMember]
        public PlayerStats Jugador { get; set; }
        [DataMember]
        public int VidaPlayer { get; set; }
        [DataMember]
        public List<Items> ItemsJugador { get; set; }
        
        [DataMember]
        public List<GameObject> Bosses { get; set; }

        public CompleteGame(PlayerStats Jugador, int VidaPlayer, List<Items> ItemsJugador,  List<GameObject> Bosses)
        {
            this.Jugador = Jugador;
            this.VidaPlayer = VidaPlayer;
            this.ItemsJugador = ItemsJugador;
           
            this.Bosses = Bosses;
        }


    }


}

