using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klondike
{
  public class Klondike
  {
    private Baraja baraja;
    private Descarte descarte;
    private Palo[] palos;
    private Columna[] columnas;
    private static int NUM_COLUMNAS = 7;
    public Klondike()
    {
      baraja = new Baraja();
      descarte = new Descarte();
      palos = new Palo[Baraja.NUM_PALOS];
      for (int i=0; i < palos.Length; i++)
      {
        palos[i] = new Palo();
      }
      columnas = new Columna[NUM_COLUMNAS];
      for (int i = 0; i < columnas.Length; i++)
      {
        columnas[i] = new Columna(i+1, baraja);
      }
    }

    public void jugar()
    {
      Menu menu = new Menu();
      int opcion;
      do
      {
        this.mostrar();
        menu.mostrar();
        opcion = menu.getOpcion();
        switch (opcion)
        {
          case 1:
            baraja.moverA(descarte);
            break;
          case 2:
            descarte.moverA(this.recogerPalo("A"));
            break;
          case 3:
            descarte.moverA(this.recogerColumna("A"));
            break;
          case 4:
            this.recogerPalo("De").moverA(recogerColumna("A"));
            break;
          case 5:
            this.recogerColumna("De").moverA(this.recogerPalo("A"));
            break;
          case 6:
            this.recogerColumna("De").moverA(this.recogerColumna("A"));
            break;
          case 7:
            this.recogerColumna("De").voltear();
            break;
          case 8:
            descarte.voltear(baraja);
            break;
          case 9:
            break;
        }
      } while (opcion != 9);
    }

    private Palo recogerPalo(string prefijo)
    {
      GestorIO gestorio = new GestorIO();
      int palo;
      Boolean error;
      do
      {
        gestorio.mostrar(string.Format("¿{0} qué palo?[1-{1}]", prefijo,Baraja.NUM_PALOS));
        palo = gestorio.inInt();
        error = !new Intervalo(1, Baraja.NUM_PALOS).incluye(palo);
        if (error)
        {
          gestorio.mostrar(string.Format("Error!!! Debe ser un número entre 1 y {0}", Baraja.NUM_PALOS));
        }
      } while (error);
      return palos[palo - 1];
    }

    private Columna recogerColumna(string prefijo)
    {
      GestorIO gestorio = new GestorIO();
      int columna;
      Boolean error;
      do
      {
        gestorio.mostrar(string.Format("¿{0} qué columna?[1-{1}]", prefijo, NUM_COLUMNAS));
        columna = gestorio.inInt();
        error = !new Intervalo(1, NUM_COLUMNAS).incluye(columna);
        if (error)
        {
          gestorio.mostrar(string.Format("Error!!! Debe ser un número entre 1 y {0}", NUM_COLUMNAS));
        }
      } while (error);
      return columnas[columna - 1];
    }
      

    private void mostrar()
    {
      baraja.mostrar();
      descarte.mostrar();
      foreach (Palo palo in palos)
      {
        palo.mostrar();
      }
      foreach(Columna columna in columnas)
      {
        columna.mostrar();
      }
    }
  }
}
