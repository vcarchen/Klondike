using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klondike
{
  public class GestorIO
  {

    public String inString()
    {
      String entrada = null;
      try
      {
        entrada = Console.ReadLine();
      }
      catch (Exception e)
      {
        this.salir();
      }
      return entrada;
    }

    public int inInt()
    {
      int entrada = 0;
      try
      {
        entrada = int.Parse(this.inString());
      }
      catch (Exception e)
      {
        this.salir();
      }
      return entrada;
    }

    public float inFloat()
    {
      float entrada = 0;
      try
      {
        entrada = float.Parse(this.inString());
      }
      catch (Exception e)
      {
        this.salir();
      }
      return entrada;
    }

    public double inDouble()
    {
      double entrada = 0.0;
      try
      {
        entrada = Double.Parse(this.inString());
      }
      catch (Exception e)
      {
        this.salir();
      }
      return entrada;
    }

    public long inLong()
    {
      long entrada = 0;
      try
      {
        entrada = long.Parse(this.inString());
      }
      catch (Exception e)
      {
        this.salir();
      }
      return entrada;
    }

    public byte inByte()
    {
      byte entrada = 0;
      try
      {
        entrada = Byte.Parse(this.inString());
      }
      catch (Exception e)
      {
        this.salir();
      }
      return entrada;
    }

    
    public char inChar()
    {
      char caracter = ' ';
      String entrada = this.inString();
      if (entrada.Length > 1)
      {
        this.salir();
      }
      else
        caracter = char.Parse( entrada.PadLeft(1));
      return caracter;
    }
        
    public void mostrar(String salida)
    {
      Console.Write(salida);
    }

    public void mostrar(int salida)
    {
      Console.Write(salida);
    }

    public void mostrar(float salida)
    {
      Console.Write(salida);
    }

    public void mostrar(double salida)
    {
      Console.Write(salida);
    }

    public void mostrar(long salida)
    {
      Console.Write(salida);
    }

    public void mostrar(byte salida)
    {
      Console.Write(salida);
    }

    
    public void mostrar(char salida)
    {
      Console.Write(salida);
    }

    public void mostrar(Boolean salida)
    {
      Console.Write(salida);
    }

    private void salir()
    {
      Console.WriteLine("ERROR de entrada/salida");
      Environment.Exit(0);
    }


  }
}
