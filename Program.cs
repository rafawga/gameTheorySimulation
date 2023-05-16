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

void Misturar(ref List<Individuo> list)
{
    RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
    int n = list.Count;
    while (n > 1)
    {
        byte[] box = new byte[1];
        do provider.GetBytes(box);
        while (!(box[0] < n * (Byte.MaxValue / n)));
        int k = (box[0] % n);
        n--;
        Individuo value = list[k];
        list[k] = list[n];
        list[n] = value;
    }
}

void play(ref List<Individuo> listaIndividuos)
{
    if (listaIndividuos.Count > 1)
    {
        for (int i = 0; i < listaIndividuos.Count; i += 2)
        {
            int j = i + 1;
            bool removedI = false;
            bool removedJ = false;

            if (listaIndividuos.Count % 2 == 1 && i == listaIndividuos.Count - 1)
            {// caso a lista seja par e seja o ultimo item      j = 0;  
                j = 0;
            }

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
                listaIndividuos[i].moeda += 3;
                listaIndividuos[j].moeda -= 1;
            }

            else if (listaIndividuos[i].Escolha() == "cooperar" && listaIndividuos[j].Escolha() == "trapacear")
            {
                listaIndividuos[i].moeda -= 1;
                listaIndividuos[j].moeda += 3;
            }

            listaIndividuos[i].decisaoAnterior = listaIndividuos[j].Escolha();
            listaIndividuos[j].decisaoAnterior = listaIndividuos[i].Escolha();

            if (listaIndividuos[i].moeda < 1)
            {
                removedI = true;
            }

            if (listaIndividuos[j].moeda < 1)
            {
                removedJ = true;
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

            else if (removedI == true)
            {
                listaIndividuos.RemoveAt(i);
            }

            else if (removedJ == true)
            {
                listaIndividuos.RemoveAt(j);
            }

            if (listaIndividuos[i].moeda > 19)
            {
                listaIndividuos[i].moeda = listaIndividuos[i].moeda / 2;
            }

        }
    }

    for (int k = 0; k < listaIndividuos.Count; k++)
    {
        System.Console.WriteLine($"{listaIndividuos[k]}: {listaIndividuos[k].moeda} index[{k}]");
    }

    System.Console.WriteLine();

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

    Misturar(ref listaIndividuos);
    play(ref listaIndividuos);
}

