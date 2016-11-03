using System;

namespace Klondike
{
  public class Carta
  {
    private int palo;
    private int numero;
    private bool bocaarriba;

    private static String[] PALOS = { "Picas", "Treboles", "Diamantes", "Corazones" };
    private static Intervalo NEGROS = new Intervalo(0, 1);
    private static Intervalo ROJOS = new Intervalo(2, 3);
    private static String[] NUMEROS = { "As", "2", "3", "4", "5", "6", "7","8","9","10","J","Q","K"};

    public Carta(int palo, int numero)
    {
      this.palo = palo;
      this.numero = numero;
      bocaarriba = false;
    }

    internal void mostrar()
    {
      String numero = "???";
      String palo = "???";
      if (this.bocaArriba())
      {
        numero = NUMEROS[this.numero];
        palo = PALOS[this.palo];
      }
      new GestorIO().mostrar(string.Format("({0} de {1})" , numero, palo) );
    }

    internal void voltear()
    {
      bocaarriba=!bocaarriba;
    }

    internal bool esAs()
    {
      return numero==0;
    }

    internal bool siguiente(Carta carta)
    {
      return numero==carta.numero+1;
    }

    internal bool igualPalo(Carta carta)
    {
      return palo==carta.palo;
    }

    internal bool bocaArriba()
    {
      return bocaarriba;
    }

    internal bool esRey()
    {
      return numero==12;
    }

    internal bool distintoColor(Carta carta)
    {
      return this.rojo() != carta.negro() || this.negro() != carta.negro();
    }

    private bool negro()
    {
      return NEGROS.incluye(palo);
    }

    private bool rojo()
    {
      return ROJOS.incluye(palo); 
    }
  }
}