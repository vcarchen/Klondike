using System;

namespace Klondike
{
  internal class Palo:Mazo 
  {
    public Palo():base(Baraja.NUM_NUMEROS,"Palo")
    {
      
    }
     
    public override void mostrarContenido()
    {
      this.cima().mostrar();
    }
    public void moverA(Columna columna)
    {
      if (this.vacia())
      {
        new GestorIO().mostrar("Error!!! No hay cartas en palo");
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
        
    public bool apilable(Carta carta)
    {
      return this.vacia() && carta.esAs() ||
               !this.vacia() && carta.siguiente(this.cima()) && carta.igualPalo(this.cima());
    }    
  }
}