class Matematico : Individuo
{
    public int ProbabilidadeTrapacear;
    public int ProbabilidadeCooperar = 70;
    public int prob;
     public override Individuo Duplicar()
    {
        return new Matematico();
    }
     public override bool Escolha()
    {
        Random number = new Random();
        prob = number.Next(0, 100);
        ProbabilidadeTrapacear = 100 - ProbabilidadeCooperar; 

        if (prob < ProbabilidadeCooperar){
            return false;
        }

        else{
            return true;
        }



        
    }
}