using System;

namespace Klondike
{
  internal class Descarte:Mazo
  {
    public static int NUM_INICAL_COLUMNAS= 28;
        
    public Descarte():base(Baraja.NUM_PALOS * Baraja.NUM_NUMEROS - NUM_INICAL_COLUMNAS,"Descarte")
    {
    }

    public override void mostrarContenido()
    {
      int primeraVisible = ultima - Baraja.NUM_CARTASBARAJA_A_DESCARTE;
      if (primeraVisible < 0)
      {
        primeraVisible = 0;
      }
      for (int i = primeraVisible; i < ultima; i++)
      {
        cartas[i].mostrar();
      }
    }

    public void moverA(Palo palo)
    {
      if (this.vacia())
      {
        new GestorIO().mostrar("Error!!! No hay cartas en descarte");
      }
      else {
        Carta carta = this.sacar();
        if (palo.apilable(carta))
        {
          palo.poner(carta);
        }
        else {
          this.poner(carta);
          new GestorIO().mostrar("Error!!! No se puede realizar ese movimiento");
        }
      }
    }

    public void moverA(Columna columna)
    {
      if (this.vacia())
      {
        new GestorIO().mostrar("Error!!! No hay cartas en descarte");
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

    public void voltear(Baraja baraja)
    {
      if (this.vacia())
      {
        new GestorIO().mostrar("Error!!! No hay cartas en descarte");
      }
      else {
        while (!this.vacia())
        {
          Carta carta = this.sacar();
          carta.voltear();
          baraja.poner(carta);
        }
      }
    }

  }
}