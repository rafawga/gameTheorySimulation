public class Tolerante : Individuo
{
    
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
