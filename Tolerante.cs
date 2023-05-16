public class Tolerante : Individuo
{
    public int vinganca = 0;
     public override Individuo Duplicar()
    {
        return new Tolerante();
    }
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
