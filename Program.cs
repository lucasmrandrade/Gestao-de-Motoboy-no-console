using GestãoDeMotoboy.Modelos;
// criar funcao 

Console.OutputEncoding = System.Text.Encoding.UTF8; // formatar o exibir mensagem sistema

void ExibirMensagemSistema()
{
    Console.WriteLine(@"
░
░██████╗░███████╗░██████╗████████╗░█████╗░░█████╗░  ██████╗░███████╗
██╔════╝░██╔════╝██╔════╝╚══██╔══╝██╔══██╗██╔══██╗  ██╔══██╗██╔════╝
██║░░██╗░█████╗░░╚█████╗░░░░██║░░░███████║██║░░██║  ██║░░██║█████╗░░
██║░░╚██╗██╔══╝░░░╚═══██╗░░░██║░░░██╔══██║██║░░██║  ██║░░██║██╔══╝░░
╚██████╔╝███████╗██████╔╝░░░██║░░░██║░░██║╚█████╔╝  ██████╔╝███████╗
░╚═════╝░╚══════╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░  ╚═════╝░╚══════╝

███╗░░░███╗░█████╗░████████╗░█████╗░██████╗░░█████╗░██╗░░░██╗░██████╗
████╗░████║██╔══██╗╚══██╔══╝██╔══██╗██╔══██╗██╔══██╗╚██╗░██╔╝██╔════╝
██╔████╔██║██║░░██║░░░██║░░░██║░░██║██████╦╝██║░░██║░╚████╔╝░╚█████╗░
██║╚██╔╝██║██║░░██║░░░██║░░░██║░░██║██╔══██╗██║░░██║░░╚██╔╝░░░╚═══██╗
██║░╚═╝░██║╚█████╔╝░░░██║░░░╚█████╔╝██████╦╝╚█████╔╝░░░██║░░░██████╔╝
╚═╝░░░░░╚═╝░╚════╝░░░░╚═╝░░░░╚════╝░╚═════╝░░╚════╝░░░░╚═╝░░░╚═════╝░ ");
}


//Console.WriteLine();

//List<string> listaDosMotoboys  = new List<string>()!;

Dictionary<string, Motoboy> motoboysRegistrados = new()!; // vai buscar as informacoes da classe Motoboy

void ExibirOpcoesDoMenu()
{
    ExibirMensagemSistema();
    Console.WriteLine("\nDigite 1 para registrar motoboy: ");
    Console.WriteLine("Digite 2 mostrar os motoboys cadastrados: ");
    Console.WriteLine("Digite 3 para alterar os status dos motoboys: ");
    Console.WriteLine("Digite 4 para ver relatorio de motoboys: ");
    Console.WriteLine("Digite 5 para sair: ");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolha = Console.ReadLine()!;

    int.TryParse(opcaoEscolha, out int opcaoEscolhaNumerica); // pra converter string pra int 

    switch (opcaoEscolhaNumerica)
    {
        case 1: RegistrarMotoboys(); break;
        case 2: MostrarMotoboysCadastrados(); break;
        case 3: AlterarStatusMotoboy(); break;
        case 4: RelatorioDeMotoboyPorStatus(); break;
        case 5: FinalizaSistema(); break;
        default: 
            Console.WriteLine("Opcao invalida!");
            Thread.Sleep(1000);
            Console.Clear();
            ExibirOpcoesDoMenu();
            break;
    }
}


void RegistrarMotoboys()
{
    bool continuarCadastrando = true;

    while (continuarCadastrando)
    {
        Console.Clear();
        ExibirTituloOpcoes("Registros dos motoboys");

        Console.Write("\nDigite o nome do motoboy: ");
        string nomeDoMotoboy = Console.ReadLine()!.Trim().ToUpper();    

        Console.Write("Digite o número de telefone do motoboy: ");
        string telefone = Console.ReadLine()!.Trim();

        // Validação para não aceitar texto em branco
        if (!string.IsNullOrWhiteSpace(nomeDoMotoboy))
        {
            // Checa se a chave já existe no dicionário para evitar crash
            if (!motoboysRegistrados.ContainsKey(nomeDoMotoboy))
            {

                // a criação da classe motoboy, onde estao sendo guardadas na memoria pra trazer as informações 
                Motoboy novoMotoboy = new Motoboy(nomeDoMotoboy, telefone);
                

                motoboysRegistrados.Add(nomeDoMotoboy, novoMotoboy);
                Console.WriteLine($"\nO motoboy {nomeDoMotoboy} foi registrado com sucesso!");
            }
            else
            {
                Console.WriteLine($"\nO motoboy '{nomeDoMotoboy}' já está registrado!");
            }
        }
        else
        {
            Console.WriteLine("\nNome inválido. Nenhum motoboy foi registrado.");
        }

        Console.Write("\nDeseja cadastrar outro motoboy? (S/N): ");
        string resposta = Console.ReadLine()!.Trim().ToUpper();

        if (resposta != "S")
        {
            continuarCadastrando = false;
        }
    }

    Thread.Sleep(1000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}


void MostrarMotoboysCadastrados()
{
    Console.Clear();
    ExibirTituloOpcoes("Relatório Geral de Motoboys");

    if (motoboysRegistrados.Count == 0)
    {
        Console.WriteLine("Nenhum motoboy cadastrado no momento.");
    }
    else
    {

        foreach (KeyValuePair<string, Motoboy> item in motoboysRegistrados)
        {
            Motoboy m = item.Value;
            m.ExibirCadastroDoMotoboy();
        }
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void AlterarStatusMotoboy()
{
    Console.Clear();
    ExibirTituloOpcoes("Alterar Status do Motoboy");

    Console.Write("Digite o nome do motoboy: ");
    string nomeDoMotoboy = Console.ReadLine()!.Trim().ToUpper();

    if (motoboysRegistrados.ContainsKey(nomeDoMotoboy))
    {
        Motoboy m = motoboysRegistrados[nomeDoMotoboy];

        Console.WriteLine($"\nStatus atual de {m.nomeDoMotoboy}: {m.status}");
        Console.WriteLine("\nDigite 1 para: Disponível na Base");
        Console.WriteLine("Digite 2 para: Em Rota de Entrega");
        Console.WriteLine("Digite 3 para: Retornando para a Base");

        Console.Write("\nEscolha o novo status: ");
        string opcaoStatus = Console.ReadLine()!;

        string novoStatus = "";

        switch (opcaoStatus)
        {
            case "1": novoStatus = "Disponível na Base"; break;
            case "2": novoStatus = "Em Rota de Entrega"; break;
            case "3": novoStatus = "Retornando para a Base"; break;
        }

        // o switch escolhe o texto do novo status (fica vazio se a opção for inválida)
        // se escolheu algum, o método AlterarStatus da classe Motoboy faz a troca
        if (novoStatus != "")
        {
            m.AlterarStatus(novoStatus);
            Console.WriteLine($"\nStatus de {m.nomeDoMotoboy} atualizado para: {m.status}");
        }
        else
        {
            Console.WriteLine("\nOpção inválida! Status não alterado.");
        }
    }
    else
    {
        Console.WriteLine("\nMotoboy não encontrado!");
        Console.Write("Deseja cadastrar este motoboy agora? (S/N): ");
        string resposta = Console.ReadLine()!.Trim().ToUpper();

        if (resposta == "S")
        {
            RegistrarMotoboys();
            return;
        }
    }

    Thread.Sleep(1500);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void RelatorioDeMotoboyPorStatus()
{
    bool continuarConsultando = true;

    while (continuarConsultando)
    {
        Console.Clear();
        ExibirTituloOpcoes("Relatório de Motoboys");

        // se não tem ninguém cadastrado, não adianta filtrar: volta ao menu principal
        if (motoboysRegistrados.Count == 0)
        {
            Console.WriteLine("Nenhum motoboy cadastrado no momento.");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
            ExibirOpcoesDoMenu();
            return;
        }

        Console.WriteLine("Escolha a opção de filtro: ");
        Console.WriteLine("1 - Ver apenas: Disponível na base");
        Console.WriteLine("2 - Ver apenas: Em rota de entrega");
        Console.WriteLine("3 - Ver apenas: Retornando pra base");
        Console.WriteLine("4 - Ver todos os motoboys");
        Console.WriteLine("5 - Voltar ao menu principal");

        Console.Write("\nDigite a opção desejada: ");
        string opcaoFiltro = Console.ReadLine()!.Trim();

        string statusAlvo = "";

        switch (opcaoFiltro)
        {
            case "1": statusAlvo = "Disponível na Base"; break;
            case "2": statusAlvo = "Em Rota de Entrega"; break;
            case "3": statusAlvo = "Retornando para a Base"; break;
            case "4": statusAlvo = "Todos"; break;
            case "5":
                Console.Clear();
                ExibirOpcoesDoMenu();
                return; // só aqui volta ao menu principal
            default:
                Console.WriteLine("\nOpção inválida!");
                Thread.Sleep(1000);
                continue; // volta pro começo do while, no menu de filtros
        }

        Console.Clear();
        ExibirTituloOpcoes($"Relatório: {statusAlvo}");

        int contador = 0;

        foreach (KeyValuePair<string, Motoboy> item in motoboysRegistrados)
        {
            Motoboy m = item.Value;

            if (statusAlvo == "Todos" || m.status == statusAlvo)
            {
                Console.WriteLine($"Motoboy: {m.nomeDoMotoboy} | Status: {m.status} ");
                contador++;
            }
        }

        if (contador == 0)
        {
            Console.WriteLine($"Nenhum motoboy encontrado com o status '{statusAlvo}'.");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar aos filtros...");
        Console.ReadKey();
        // o while recomeça e mostra o menu de filtros de novo
    }
}


void ExibirTituloOpcoes(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string caractereTitulo = string.Empty.PadLeft(quantidadeDeLetras, '*'); // quantos caracteres tera a esquerda
    Console.WriteLine(caractereTitulo);
    Console.WriteLine(titulo);
    Console.WriteLine(caractereTitulo + "\n");
}

void FinalizaSistema()
{
    Console.Clear();
    Console.WriteLine("Encerrado a execução!");
    Thread.Sleep(1000);
}

ExibirOpcoesDoMenu();


