using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Clases
{
    [DataContract]
    public class Items
    {
        [DataMember]
        public string Nombre { get; set; }///Nombre del item
        [DataMember]
        public int Cantidad { get; set; }///Cantidad de itemes (en caso de pocion, cantidad de pociones y en caso de arco, cantidad de flechas)
        
        [DataMember]
        public bool Desbloqueado { get; set; }///Si se desbloqueo o no el item

        public Items(string Nombre, int Cantidad, bool Desbloqueado)
        {
            this.Nombre = Nombre;
            this.Cantidad = Cantidad;
            this.Desbloqueado = Desbloqueado;

        }
    }
}
