class Rabugento : Individuo
{
    public int trapaceado = 0;
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