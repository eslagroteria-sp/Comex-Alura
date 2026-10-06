// See https://aka.ms/new-console-template for more information
Console.WriteLine("Bem vindo ao Comex!");

Dictionary<string, Cliente> clientes = new Dictionary<string, Cliente>();
Dictionary<string, Produto> produtos = new Dictionary<string, Produto>();
Dictionary<Cliente, List<Produto>> carrinhos = new Dictionary<Cliente, List<Produto>>();
int opcao = 0;

while (opcao != -1)
{
    ExibirMenu();
    opcao = int.Parse(Console.ReadLine());
    switch (opcao)
    {
        case 1:
            Console.WriteLine("Cadastrar cliente selecionado.");
            CadastrarCliente();
            break;
        case 2:
            Console.WriteLine("Listar Clientes selecionado.");
            ListarClientes();
            break;
        case 3:
            Console.WriteLine("Cadastrar produto selecionado.");
            CadastrarProduto();
            break;
        case 4:
            Console.WriteLine("Listar produtos selecionado.");
            ListarProdutos();
            break;
        case 5:
            Console.WriteLine("Editar preço do produto selecionado.");
            EditarPrecoProduto();
            break;
        case 6:
            Console.WriteLine("Adicionar produto ao carrinho selecionado.");
            AdicionarProdutoaoCarrinho();
            break;
        case 7:
            Console.WriteLine("Visualizar carrinho selecionado.");
            VisualizarCarrinho();
            break;
        case 8:
            Console.WriteLine("Fechar compra selecionado.");
            FecharCompra();
            break;
        case -1:
            Console.WriteLine("COMEX FINALIZADO");
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
    Console.WriteLine("===================================\n");
}
    

void ExibirMenu()
{
    Console.WriteLine("Digite a opção desejada:");
    Console.WriteLine("1 - Cadastrar cliente");
    Console.WriteLine("2 - Listar Clientes");
    Console.WriteLine("3 - Cadastrar produto");
    Console.WriteLine("4 - Listar produtos");
    Console.WriteLine("5 - Editar preço do produto");
    Console.WriteLine("6 - Adicionar produto ao carrinho");
    Console.WriteLine("7 - Visualizar carrinho");
    Console.WriteLine("8 - Fechar compra");
    Console.WriteLine("-1 - Sair");
}

void CadastrarCliente()
{
    Console.WriteLine("Digite o cpf e o nome do cliente:");
    string cpf = Console.ReadLine();
    string nome = Console.ReadLine();
    clientes[cpf] = new Cliente { Cpf = cpf, Nome = nome };
    Console.WriteLine($"Cliente cadastrado: {nome} - {cpf}");
}

void ListarClientes()
{
    Console.WriteLine("Listando clientes...");
    foreach (var cliente in clientes.Values)
    {
        Console.WriteLine($"{cliente.Nome} - {cliente.Cpf}");
    }
}
void CadastrarProduto()
{
    Console.WriteLine("Digite o código, nome e preço do produto:");
    string codigo = Console.ReadLine();
    string nome = Console.ReadLine();
    decimal preco = decimal.Parse(Console.ReadLine());
    produtos[codigo] = new Produto { Codigo = codigo, Nome = nome, Preco = preco };
    Console.WriteLine($"Produto cadastrado: {nome} - {codigo} - {preco}");
}

void EditarPrecoProduto()
{
    Console.WriteLine("Digite o código do produto que deseja editar o preço:");
    string codigo = Console.ReadLine();
    if (produtos.ContainsKey(codigo))
    {
        Console.WriteLine("Digite o novo preço:");
        decimal novoPreco = decimal.Parse(Console.ReadLine());
        produtos[codigo].Preco = novoPreco;
        Console.WriteLine($"Preço do produto {produtos[codigo].Nome} atualizado para {novoPreco}");
    }
    else
    {
        Console.WriteLine("Produto não encontrado.");
    }
}

void ListarProdutos()
{
    Console.WriteLine("Listando produtos...");
    foreach (var produto in produtos.Values)
    {
        Console.WriteLine($"{produto.Nome} - {produto.Codigo} - {produto.Preco}");
    }
}

void AdicionarProdutoaoCarrinho()
{
    Console.WriteLine("Digite o cpf do cliente que deseja adicionar o produto:");
    string cpf = Console.ReadLine();
    if (!clientes.ContainsKey(cpf))
    {
        Console.WriteLine("Cliente não encontrado.");
        return;
    }
    Console.WriteLine("Digite o código do produto que deseja adicionar ao carrinho:");
    string codigo = Console.ReadLine();
    if (produtos.ContainsKey(codigo))
    {
        Cliente cliente = clientes[cpf];
        if (!carrinhos.ContainsKey(cliente))
        {
            carrinhos[cliente] = new List<Produto>();
        }
        carrinhos[cliente].Add(produtos[codigo]);
        Console.WriteLine($"Produto {produtos[codigo].Nome} adicionado ao carrinho.");
    }
    else
    {
        Console.WriteLine("Produto não encontrado.");
    }
}
void VisualizarCarrinho()
{
    Console.WriteLine("Digite o cpf do cliente que deseja visualizar o carrinho:");
    string cpf = Console.ReadLine();
    if (!clientes.ContainsKey(cpf))
    {
        Console.WriteLine("Cliente não encontrado.");
        return;
    }
    Cliente cliente = clientes[cpf];
    if (!carrinhos.ContainsKey(cliente) || carrinhos[cliente].Count == 0)
    {
        Console.WriteLine("Carrinho vazio.");
        return;
    }
    Console.WriteLine("Produtos no carrinho:");
    foreach (var produto in carrinhos[cliente])
    {
        Console.WriteLine($"{produto.Nome} - {produto.Codigo} - {produto.Preco}");
    }
}

void FecharCompra()
{
    Console.WriteLine("Digite o cpf do cliente que deseja fechar a compra:");
    string cpf = Console.ReadLine();
    if (!clientes.ContainsKey(cpf))
    {
        Console.WriteLine("Cliente não encontrado.");
        return;
    }
    Cliente cliente = clientes[cpf];
    if (!carrinhos.ContainsKey(cliente) || carrinhos[cliente].Count == 0)
    {
        Console.WriteLine("Carrinho vazio.");
        return;
    }
    decimal total = 0;
    Console.WriteLine("Produtos no carrinho:");
    foreach (var produto in carrinhos[cliente])
    {
        Console.WriteLine($"{produto.Nome} - {produto.Codigo} - {produto.Preco}");
        total += produto.Preco;
    }
    Console.WriteLine($"Total da compra: {total}");
    Console.WriteLine("===================================");
    Console.WriteLine("Digite os dados do cartão de crédito:");
    string cartao = Console.ReadLine();
    Console.WriteLine("Processando pagamento...");
    // Simula o processamento do pagamento com o cartão informado
    carrinhos[cliente].Clear();
    Console.WriteLine("Compra finalizada.");
    //teste de subir na main
}