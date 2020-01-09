using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Clases{
    [DataContract]
    public class EnemyStats
    {
       
        [DataMember]
        public string TipoEnemigo { get; set; }

        [DataMember]
        public Vector2 Posicion { get; set; }

        public EnemyStats(string TipoEnemigo, Vector2 Posicion){
            this.TipoEnemigo = TipoEnemigo;
            this.Posicion = Posicion;

        }


    }

}

