class Colaborativo : Individuo
{
    
    public override Individuo Duplicar()
    {
        return new Colaborativo();
    }


    public override bool Escolha()
    {
        return false;
    }
}