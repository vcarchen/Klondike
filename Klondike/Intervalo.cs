using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Klondike
{
  public class Intervalo
  {
    private double puntoMedio;

    private double Longitud;

    private double getInferior()
    {
      double resultado = this.Longitud / 2;
      return puntoMedio - this.Longitud / 2;
    }

    private void setInferior(double inferior)
    {
      this.Longitud  = this.getSuperior() - inferior;
      puntoMedio = inferior + this.Longitud / 2;
    }

    private double getSuperior()
    {
      return puntoMedio + this.Longitud / 2;
    }

    private void setSuperior(double superior)
    {
      this.Longitud = superior - this.getInferior();
      puntoMedio = superior - this.Longitud / 2;
    }

    public Intervalo(double inferior, double superior)
    {
      this.setInferior(inferior);
      this.setSuperior(superior);
    }

    public Intervalo(double superior): this(0, superior)
    {
      
    }

    public Intervalo(Intervalo intervalo): this(intervalo.getInferior(), intervalo.getSuperior())
    {
      
    }

    public Intervalo(): this(0, 0)
    {
      
    }

    public Intervalo clone()
    {
      return new Intervalo(this);
    }

    public double longitud()
    {
      return getSuperior() - getInferior();
    }

    public void desplazar(double desplazamiento)
    {
      setInferior(getInferior() + desplazamiento);
      setSuperior(getSuperior() + desplazamiento);
    }

    public Intervalo desplazado(double desplazamiento)
    {
      Intervalo intervalo = this.clone();
      intervalo.desplazar(desplazamiento);
      return intervalo;
    }

    public Boolean incluye(double valor)
    {
      return getInferior() <= valor && valor <= getSuperior();
    }

    public Boolean incluye(Intervalo intervalo)
    {
      Debug.Assert (intervalo!= null);
      return this.incluye(intervalo.getInferior()) &&
          this.incluye(intervalo.getSuperior());
    }

    public Boolean equals(Intervalo intervalo)
    {
      Debug.Assert (intervalo!= null);
      return getInferior() == intervalo.getInferior() &&
          getSuperior() == intervalo.getSuperior();
    }

    public Intervalo interseccion(Intervalo intervalo)
    {
      Debug.Assert (this.intersecta(intervalo));
      if (this.incluye(intervalo))
      {
        return intervalo.clone();
      }
      else if (intervalo.incluye(this))
      {
        return this.clone();
      }
      else if (this.incluye(intervalo.getInferior()))
      {
        return new Intervalo(intervalo.getInferior(), getSuperior());
      }
      else {
        return new Intervalo(getInferior(), intervalo.getSuperior());
      }
    }

    public Boolean intersecta(Intervalo intervalo)
    {
      Debug.Assert (intervalo!= null);
      return this.incluye(intervalo.getInferior()) ||
          this.incluye(intervalo.getSuperior()) ||
          intervalo.incluye(this);
    }

    public void oponer()
    {
      double inferiorInicial = getInferior();
      double superiorInicial = getSuperior();
      setInferior(-superiorInicial);
      setSuperior(-inferiorInicial);
    }

    public void doblar()
    {
      double longitudInicial = this.longitud();
      setInferior(getInferior() - longitudInicial / 2);
      setSuperior(getSuperior() + longitudInicial / 2);
    }

    public void recoger()
    {
      GestorIO gestorIO = new GestorIO();
      gestorIO.mostrar ("Inferior?");
      setInferior(gestorIO.inDouble());
      gestorIO.mostrar("Superior?");
      setSuperior(gestorIO.inDouble());
    }

    public void mostrar()
    {
      new GestorIO().mostrar("[" + getInferior() + "," + getSuperior() + "]");
    }

  }
}
