using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ListaDeTarefas;

// SUGESTÃO: Renomear esta classe para 'GerenciadorTarefas' seria mais semântico.
// 'ListaDeTarefa' parece o nome de uma lista simples, enquanto esta classe gerencia todo o fluxo do sistema.
public class App
{
    private readonly List<Tarefa> _tarefas = new();
    
    // Campo para manter o controle do próximo ID disponível.
    // Isso evita que o usuário precise digitar IDs manuais.
    private int _proximoId = 1;

    public void Executar()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("------ Gerenciador de Tarefas ------");
            Console.WriteLine("1 - Criar nova tarefa");
            Console.WriteLine("2 - Listar tarefas");
            Console.WriteLine("3 - Apagar tarefa");
            Console.WriteLine("4 - Editar tarefa");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("------------------------------------");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int opc))
            {
                switch (opc)
                {
                    case 1:
                        CriarTarefa();
                        break;
                    case 2:
                        ListarTarefas();
                        break;
                    case 3:
                        ApagarTarefa();
                        break;
                    case 4:
                        IniciarEdicao();
                        break;
                    case 0:
                        Console.WriteLine("Finalizando... Até logo!");
                        continuar = false; // Corrigido: Agora o loop realmente termina.
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    void CriarTarefa()
    {
        Console.Clear();
        Console.WriteLine("--- Criando Nova Tarefa ---");
        
        // Geramos o ID automaticamente. É mais seguro e profissional.
        string descricao = LerString("Descrição da tarefa: ");
        bool concluida = LerBool("Marcar como concluída? (s/n): ");

        Tarefa tarefa = new(_proximoId++, descricao, concluida);
        _tarefas.Add(tarefa);
        
        Console.WriteLine("\nSucesso: Tarefa criada com sucesso!");
        AguardarTecla();
    }

    void ListarTarefas()
    {
        Console.Clear();
        Console.WriteLine("--- Lista de Tarefas ---");

        if (!_tarefas.Any())
        {
            Console.WriteLine("Nenhuma tarefa cadastrada.");
        }
        else
        {
            foreach (var tarefa in _tarefas)
            {
                // Usamos o ToString() que definimos na classe Tarefa.
                // Isso mantém o código limpo e centraliza a formatação lá.
                Console.WriteLine(tarefa);
            }
        }

        Console.WriteLine("\n------------------------");
        AguardarTecla();
    }

    // Criamos um método intermediário para buscar a tarefa antes de editar.
    // Isso evita o erro de passar uma tarefa nula para o método Editar.
    void IniciarEdicao()
    {
        Console.Clear();
        int id = LerInteiro("Digite o ID da tarefa para editar: ");
        
        Tarefa? tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        
        if (tarefa == null)
        {
            Console.WriteLine($"Erro: Tarefa com ID {id} não encontrada.");
            AguardarTecla();
            return;
        }

        EditarTarefa(tarefa);
    }

    void EditarTarefa(Tarefa tarefa)
    {
        Console.WriteLine($"\nEditando Tarefa: {tarefa.Descricao}");
        
        string novaDescricao = LerString("Nova descrição: ");
        bool novaConcluida = LerBool("Concluída? (s/n): ");

        tarefa.Descricao = novaDescricao;
        tarefa.Concluida = novaConcluida;

        Console.WriteLine("\nMudanças realizadas com sucesso!");
        AguardarTecla();
    }

    void ApagarTarefa()
    {
        Console.Clear();
        int id = LerInteiro("Digite o ID da tarefa que deseja apagar: ");

        Tarefa? tarefa = _tarefas.FirstOrDefault(t => t.Id == id);

        if (tarefa != null)
        {
            _tarefas.Remove(tarefa);
            Console.WriteLine("\nSucesso: Tarefa apagada!");
        }
        else
        {
            Console.WriteLine($"\nErro: Não existe tarefa com o ID {id}.");
        }
        
        AguardarTecla();
    }

    // --- MÉTODOS DE SUPORTE (Refatorados para melhor UX) ---

    int LerInteiro(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int num)) return num;
            
            Console.WriteLine("Erro: Digite um número válido.");
        }
    }

    string LerString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? entrada = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(entrada)) return entrada.Trim();

            Console.WriteLine("Erro: A descrição não pode estar vazia.");
        }
    }

    bool LerBool(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? entrada = Console.ReadLine()?.ToLower().Trim();
            
            if (!string.IsNullOrEmpty(entrada))
            {
                if (entrada.StartsWith('s')) return true;
                if (entrada.StartsWith('n')) return false;
            }

            Console.WriteLine("Erro: Use 's' para sim ou 'n' para não.");
        }
    }

    // Método auxiliar para evitar repetição de código.
    void AguardarTecla()
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
