static public class Mundo
{

    static public List<Individuo> criarClass()
    {

        {
            Console.Write("Digite a quantidade de colaborativos: ");
            int ColaborativosQntd = int.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade de trapaceiros: ");
            int TrapaceiroQntd = int.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade de rabugentos: ");
            int RabugnetoQntd = int.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade de copiadores: ");
            int CopiadorQntd = int.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade de tolerantes: ");
            int Tolerante = int.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade de Matemáticos: ");
            int Matematico = int.Parse(Console.ReadLine());
            List<Individuo> listaIndividuos = new List<Individuo>();
            for (int i = 0; i < ColaborativosQntd; i++)
                listaIndividuos.Add(new Colaborativo());
            for (int i = 0; i < TrapaceiroQntd; i++)
                listaIndividuos.Add(new Trapaceiro());
            for (int i = 0; i < RabugnetoQntd; i++)
                listaIndividuos.Add(new Rabugento());
            for (int i = 0; i < CopiadorQntd; i++)
                listaIndividuos.Add(new Copiador());
            for (int i = 0; i < Tolerante; i++)
                listaIndividuos.Add(new Tolerante());
            for (int i = 0; i < Matematico; i++)
                listaIndividuos.Add(new Matematico());

            return listaIndividuos;
        }
    }

    static public void Simular(List<Individuo> listaIndividuos){
        

    for (int x = 0; x < listaIndividuos.Count / 2; x++)
    {
        if (listaIndividuos.Count < 2)
        {
            break;
        }

        int i = 0;
        int j = 0;
        while (i == j)

        {
            Random number = new Random();
            i = number.Next(0, listaIndividuos.Count);
            
            j = number.Next(0, listaIndividuos.Count);
        }

        bool removedI = false;
        bool removedJ = false;

        if (listaIndividuos[i].Escolha() && listaIndividuos[j].Escolha())
        {
            listaIndividuos[i].moeda -= 1;
            listaIndividuos[j].moeda -= 1;
        }

        else if (listaIndividuos[i].Escolha() == false && listaIndividuos[j].Escolha() == false)
        {
            listaIndividuos[i].moeda += 1;
            listaIndividuos[j].moeda += 1;
        }

        else if (listaIndividuos[i].Escolha() && listaIndividuos[j].Escolha() == false)
        {
            listaIndividuos[i].moeda += 3;
            listaIndividuos[j].moeda -= 1;
            listaIndividuos[j].trapaceado += 1;
        }

        else if (listaIndividuos[i].Escolha() == false && listaIndividuos[j].Escolha())
        {
            listaIndividuos[i].moeda -= 1;
            listaIndividuos[j].moeda += 3;
            listaIndividuos[j].trapaceado += 1;
        }

        listaIndividuos[i].decisaoAnterior = listaIndividuos[j].Escolha();
        listaIndividuos[j].decisaoAnterior = listaIndividuos[i].Escolha();
        listaIndividuos[i].moeda -= 1;
        listaIndividuos[j].moeda -= 1;

        if (listaIndividuos[i].moeda < 1)
        {
            removedI = true;
        }

        if (listaIndividuos[j].moeda < 1)
        {
            removedJ = true;
        }


        if (listaIndividuos[i].moeda > 19)
        {
            listaIndividuos[i].moeda = listaIndividuos[i].moeda / 2;
            Individuo duplicado = listaIndividuos[i].Duplicar();
            listaIndividuos.Add(duplicado);

        }

        if (listaIndividuos[j].moeda > 19)
        {
            Individuo duplicado = listaIndividuos[j].Duplicar();
            listaIndividuos.Add(duplicado);
            listaIndividuos[j].moeda = listaIndividuos[j].moeda / 2;
        }


        if (removedI == true && removedJ == true)
        {
            if (i > j)
            {
                listaIndividuos.RemoveAt(i);
                listaIndividuos.RemoveAt(j);
            }
            else
            {
                listaIndividuos.RemoveAt(j);
                listaIndividuos.RemoveAt(i);
            }
        }

        else if (removedI == true && removedJ == false)
        {
            listaIndividuos.RemoveAt(i);
        }

        else if (removedJ == true && removedI == false)
        {
            listaIndividuos.RemoveAt(j);
        }

        

        System.Console.WriteLine($"Individuos vivos: {listaIndividuos.Count}");
    }

        int random1 = 0;
        
        for (int i = 0; i < listaIndividuos.Count; i++)
        {
            Random number1 = new Random();
             random1 = number1.Next(0, 10);
             if (random1 == 1)
                listaIndividuos[i].moeda -= 1;
        }
        

    }
}