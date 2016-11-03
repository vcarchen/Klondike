﻿using System;

namespace Klondike
{
  public  class Menu
  {
    private static String[] TITULOS = new String[]{
        "\n1. Mover de baraja a descarte",
        "\n2. Mover de descarte a palo",
        "\n3. Mover de descarte a columna",
        "\n4. Mover de palo a columna",
        "\n5. Mover de columna a palo",
        "\n6. Mover de columna a columna",
        "\n7. Voltear carta en columna",
        "\n8. Voltear descarte en baraja",
        "\n9. Salir"
    };

    private static Intervalo OPCIONES = new Intervalo(1,9);

    internal void mostrar()
    {
      GestorIO gestorIO = new GestorIO();
      foreach (String titulo in TITULOS)
      {
        gestorIO.mostrar(titulo);
      }
    }

    internal int getOpcion()
    {
      GestorIO gestorIO = new GestorIO();
      int opcion;
      Boolean error;
      do
      {
        gestorIO.mostrar("\nOpción? [1-9]: ");
        opcion = gestorIO.inInt();
        error = !OPCIONES.incluye(opcion);
        if (error)
        {
          gestorIO.mostrar("Error!!! La opción debe ser entre 1 y 9");
        }
      } while (error);
      return opcion;
    }
  }
}