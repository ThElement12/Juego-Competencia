using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Text;


namespace Assets.Scripts.Clases{

    [DataContract]
    public class PlayerStats
    {
        [DataMember]
        public Vector2 posicionJugador { get; set; }

        public PlayerStats(Vector2 posicionJugador){
            this.posicionJugador = posicionJugador;
        }

    }

}

