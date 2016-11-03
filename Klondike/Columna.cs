using System;

namespace Klondike
{
  internal class Columna:Mazo 
  {
    public Columna(int posicion, Baraja baraja):base(posicion + Baraja.NUM_NUMEROS - 1,string.Format("Columna {0}",posicion))
    {
      for (int i = 0; i < posicion; i++)
      {
        Carta carta = baraja.sacar();
        if (i == posicion - 1)
        {
          carta.voltear();
        }
        this.poner(carta);
      }
    }
    public override void mostrarContenido()
    {
      for (int i = 0; i < ultima; i++)
      {
        cartas[i].mostrar();
      }
    }
    public void moverA(Palo palo)
    {
      if (this.vacia())
      {
        new GestorIO().mostrar("Error!!! No hay cartas en columna");
      }
      else
      {
        Carta carta = this.sacar();
        if (palo.apilable(carta))
        {
          palo.poner(carta);
        }
        else
        {
          this.poner(carta);
          new GestorIO().mostrar("Error!!! No se puede realizar ese movimiento");
        }
      }
    }
    public void moverA(Columna columna)
    {
      if (this.vacia())
      {
        new GestorIO().mostrar("Error!!! No hay cartas en columna");
      }
      else {
        Carta carta = this.sacar();
        if (columna.apilable(carta))
        {
          columna.poner(carta);
        }
        else {
          this.poner(carta);
          new GestorIO().mostrar("Error!!! No se puede realizar ese movimiento");
        }
      }
    }

    public void voltear()
    {
      if (this.vacia())
      {
        new GestorIO().mostrar("Error!!! No hay carta que voltear");
      }
      else if (this.cima().bocaArriba())
      {
        new GestorIO().mostrar("Error!!! No hay carta boca abajo en la cima");
      }
      else {
        this.cima().voltear();
      }
    }

    public bool apilable(Carta carta)
    {
      return this.vacia() && carta.esRey() ||
             !this.vacia() && this.cima().bocaArriba() &&
             this.cima().siguiente(carta) &&
             this.cima().distintoColor(carta);
    }    
  }

}