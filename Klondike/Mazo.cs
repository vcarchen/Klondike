using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klondike
{
  public abstract class Mazo
  {

    protected Carta[] cartas;
    protected int ultima;
    protected string titulo;
    //private Carta[] cartas;
    //private int ultima;

    //public int Ultima
    //{
    //  get { return this.ultima; }
    //  set { this.ultima = value; }
    //}

    //public Carta[] Cartas
    //{
    //  get { return this.cartas; }
    //  set { this.cartas = value; }
    //} 

    protected Mazo(int cantidad,string titulo)
    {
      ultima = 0;
      cartas = new Carta[cantidad];
      this.titulo = titulo;
    }

    public bool vacia()
    {
      return ultima == 0;
    }
    public bool completa()
    {
      return ultima == Baraja.NUM_PALOS * Baraja.NUM_NUMEROS;
    }
    public Carta cima()
    {
      return cartas[ultima - 1];
    }
    public Carta sacar()
    {
      ultima--;
      return cartas[ultima];
    }
      
    public void poner(Carta carta)
    {
      cartas[ultima] = carta;
      ultima++;
    }
    public void mostrar()
    {
      GestorIO gestorio = new GestorIO();
      gestorio.mostrar(string.Format("{0}{1}:", "\n",this.titulo));
      if (this.vacia())
      {
        gestorio.mostrar("<VACIA>");
      }
      else
      {
        this.mostrarContenido ();
      }
    }
    public abstract void mostrarContenido();
  }
}
