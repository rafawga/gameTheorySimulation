class Trapaceiro : Individuo
{
     public override Individuo Duplicar()
    {
        return new Trapaceiro();
    }
    public override bool Escolha()
    {
        return true;
    }
}