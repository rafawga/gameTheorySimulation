class Trapaceiro : Individuo
{
     public override Individuo Duplicar()
    {
        return new Trapaceiro();
    }
    public override string Escolha()
    {
        return "trapacear";
    }
}