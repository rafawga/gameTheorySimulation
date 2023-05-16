class Rabugento : Individuo
{

     public override Individuo Duplicar()
    {
        return new Rabugento();
    }
    public override string Escolha()
    {
        if (trapaceado > 0)
        {
            return "trapacear";
        }
        else
        {
            return "cooperar";
        }
    }
}