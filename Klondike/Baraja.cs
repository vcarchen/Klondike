using System;

namespace Klondike
{
  internal class Baraja:Mazo 
  {
    public static int NUM_PALOS = 4;
    public static int NUM_NUMEROS = 13;
    public static int NUM_CARTASBARAJA_A_DESCARTE = 3;

    public Baraja():base(NUM_PALOS*NUM_NUMEROS,"Baraja")
    {
      for (int i = 0; i < NUM_PALOS; i++)
      {
        for (int j = 0; j < NUM_NUMEROS; j++)
        {
          this.poner(new Carta(i, j));
        }
      }
       this.barajar();
    }

    private void barajar()
    {
      Random aleatorio = new Random();
      for (int i = 0; i < 1000; i++)
      {
        int origen = aleatorio.Next(NUM_PALOS * NUM_NUMEROS);
        int destino = aleatorio.Next(NUM_PALOS * NUM_NUMEROS);
        Carta carta = cartas[origen];
        cartas[origen] = cartas[destino];
        cartas[destino] = carta;
      }
    }
       
    public override void mostrarContenido()
    {
      this.cima().mostrar();
    }

    public void moverA(Descarte descarte)
    {
      if (this.vacia())
      {
        new GestorIO().mostrar("Error!!! No hay cartas en la baraja");
      }
      else
      {
        int contador = NUM_CARTASBARAJA_A_DESCARTE;
        while (contador > 0 && !this.vacia())
        {
          Carta carta = this.sacar();
          carta.voltear();
          descarte.poner(carta);
          contador--;
        }
      }
    }
        
  }
} 
  