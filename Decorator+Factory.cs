namespace esercizio_group3
{
    
#region  Bevande base



class Mojito : IBevanda
{
    public string Descrizione() { return "Mojito"; }
    public double Costo() { return 8.00; }
}

class Spritz : IBevanda
{
    public string Descrizione() { return "Spritz"; }
    public double Costo() { return 7.00; }
}

class Negroni : IBevanda
{
    public string Descrizione() { return "Negroni"; }
    public double Costo() { return 9.00; }
}

class Martini : IBevanda
{
    public string Descrizione() { return "Martini"; }
    public double Costo() { return 10.00; }
}

class CocaCola : IBevanda
{
    public string Descrizione() { return "Coca Cola"; }
    public double Costo() { return 3.00; }
}

#endregion


#region Decorator

abstract class DecorazioneBevanda : IBevanda
{
    protected IBevanda bevanda;
    
    public DecorazioneBevanda(IBevanda bevanda)
    {
        this.bevanda = bevanda;
    }
    
    public abstract string Descrizione();
    public abstract double Costo();
}

class ZestLime : DecorazioneBevanda
{
    public ZestLime(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione() { return bevanda.Descrizione() + " + Zest di Lime"; }
    public override double Costo() { return bevanda.Costo() + 0.50; }
}

class ZestLimone : DecorazioneBevanda
{
    public ZestLimone(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione() { return bevanda.Descrizione() + " + Zest di Limone"; }
    public override double Costo() { return bevanda.Costo() + 0.50; }
}

class ZestArancia : DecorazioneBevanda
{
    public ZestArancia(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione() { return bevanda.Descrizione() + " + Zest d'Arancia"; }
    public override double Costo() { return bevanda.Costo() + 0.50; }
}

class Fragola : DecorazioneBevanda
{
    public Fragola(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione() { return bevanda.Descrizione() + " + Fragola"; }
    public override double Costo() { return bevanda.Costo() + 1.00; }
}

class Ananas : DecorazioneBevanda
{
    public Ananas(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione() { return bevanda.Descrizione() + " + Ananas"; }
    public override double Costo() { return bevanda.Costo() + 1.00; }
}

class Cocco : DecorazioneBevanda
{
    public Cocco(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione() { return bevanda.Descrizione() + " + Cocco"; }
    public override double Costo() { return bevanda.Costo() + 1.50; }
}

class LimoneEssiccato : DecorazioneBevanda
{
    public LimoneEssiccato(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione() { return bevanda.Descrizione() + " + Limone Essiccato"; }
    public override double Costo() { return bevanda.Costo() + 0.80; }
}

class AranciaEssiccata : DecorazioneBevanda
{
    public AranciaEssiccata(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione() { return bevanda.Descrizione() + " + Arancia Essiccata"; }
    public override double Costo() { return bevanda.Costo() + 0.80; }
}

#endregion

#region Creazione cocktail (factory method)

static class BevandaFactory
{
    public static IBevanda Crea(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "mojito": return new Mojito();
            case "spritz": return new Spritz();
            case "negroni": return new Negroni();
            case "martini": return new Martini();
            case "cocacola": return new CocaCola();
            default: return null;
        }
    }
}

#endregion


















}