class Rabugento : Individuo
{

     public override Individuo Duplicar()
    {
        return new Rabugento();
    }
    public override bool Escolha()
    {
        if (trapaceado > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}