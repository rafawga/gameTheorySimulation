public class Tolerante : Individuo
{
    public int vinganca = 0;
    public override Individuo Duplicar()
    {
        return new Tolerante();
    }
    public override bool Escolha()
    {
        if (vinganca == 3)
        {
            vinganca = 0;
            trapaceado = 0;
        }
        if (trapaceado >= 3)
        {
            vinganca += 1;
            return true;
            
        }
        else
        {
            return false;
        }
    }
}
