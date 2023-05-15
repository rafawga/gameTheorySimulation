public class Tolerante : Individuo
{
    public int trapaceado = 0;
    public override string Escolha()
    {
        if (trapaceado >= 3)
        {
            return "trapacear";
        }
        else
        {
            return "cooperar";
        }
    }
}
