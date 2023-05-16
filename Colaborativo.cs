class Colaborativo : Individuo
{
    
    public override Individuo Duplicar()
    {
        return new Colaborativo();
    }

    public override string Escolha()
    {
        return "cooperar";
    }
}