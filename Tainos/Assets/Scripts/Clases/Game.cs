using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace Assets.Scripts.Clases
{
    [DataContract]
    public class Game
    {
        [DataMember]
        public List<EnemyStats> Enemigos { get; set; }

        [DataMember]
        public PlayerStats Player { get; set; }

        [DataMember]
        public List<Vector2> CheckPoint { get; set; }

        private GameObject checkPointActual;

        public Game(PlayerStats Player,GameObject checkPointActual)
        {
            this.Player = Player;
            this.checkPointActual = checkPointActual;
            CheckPoint = new List<Vector2>();
            Enemigos = new List<EnemyStats>();
            EnemigosActivos();


        }

        private void EnemigosActivos()
        {
            foreach (GameObject enemyMachete in GameObject.FindGameObjectsWithTag("EnemigoMachete"))
            {
                Enemigos.Add(new EnemyStats(enemyMachete.tag, enemyMachete.transform.position));
            }
            foreach (GameObject enemyRango in GameObject.FindGameObjectsWithTag("EnemigoRango"))
            {
                Enemigos.Add(new EnemyStats(enemyRango.tag, enemyRango.transform.position));
            }
            foreach (GameObject enemyCuchillo in GameObject.FindGameObjectsWithTag("EnemigoNormalCuchillo"))
            {
                Enemigos.Add(new EnemyStats(enemyCuchillo.tag, enemyCuchillo.transform.position));
            }
            foreach (GameObject enemyPesado in GameObject.FindGameObjectsWithTag("Pesado"))
            {
                Enemigos.Add(new EnemyStats(enemyPesado.tag, enemyPesado.transform.position));
                
            }

            foreach (GameObject checkPoint in GameObject.FindGameObjectsWithTag("CheckPoint"))
            {
                if (!checkPoint.Equals(checkPointActual))
                {
                    CheckPoint.Add(checkPoint.transform.position);
                }
            }

        }

    }


}

