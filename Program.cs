using System.Security.Cryptography;

List<Individuo> StartSimulation()
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

    return listaIndividuos;
}

void play(ref List<Individuo> listaIndividuos)
{

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

        if (listaIndividuos[i].Escolha() == "trapacear" && listaIndividuos[j].Escolha() == "trapacear")
        {
            listaIndividuos[i].moeda -= 1;
            listaIndividuos[j].moeda -= 1;
        }

        else if (listaIndividuos[i].Escolha() == "cooperar" && listaIndividuos[j].Escolha() == "cooperar")
        {
            listaIndividuos[i].moeda += 1;
            listaIndividuos[j].moeda += 1;
        }

        else if (listaIndividuos[i].Escolha() == "trapacear" && listaIndividuos[j].Escolha() == "cooperar")
        {
            listaIndividuos[i].moeda += 4;
            listaIndividuos[j].moeda -= 1;
            listaIndividuos[j].trapaceado += 1;
        }

        else if (listaIndividuos[i].Escolha() == "cooperar" && listaIndividuos[j].Escolha() == "trapacear")
        {
            listaIndividuos[i].moeda -= 1;
            listaIndividuos[j].moeda += 4;
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

        for (int k = 0; k < listaIndividuos.Count; k++)
        {
            System.Console.WriteLine($"{listaIndividuos[k]}: {listaIndividuos[k].moeda}$");
        }
        System.Console.WriteLine();
    }

}

bool game = true;
List<Individuo> listaIndividuos = StartSimulation();


while (game)
{

    for (int i = 0; i < listaIndividuos.Count; i++)
    {
        if (listaIndividuos.Count < 2)
            game = false;
    }

    play(ref listaIndividuos);

}

System.Console.WriteLine($"{listaIndividuos[0]}: {listaIndividuos[0].moeda} venceu o battle royale!");