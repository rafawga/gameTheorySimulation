class Rabugento : Individuo
{
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