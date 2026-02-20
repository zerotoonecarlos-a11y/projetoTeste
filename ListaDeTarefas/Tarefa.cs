namespace ListaDeTarefas;

public class Tarefa
{
    // Usamos 'init' no Id para que ele só possa ser definido na criação.
    // Isso garante a integridade dos dados (um ID não deve mudar).
    public int Id { get; init; }
    
    // A descrição não deve ser nula, pois validamos isso na entrada.
    public string Descricao { get; set; }
    
    public bool Concluida { get; set; }

    public Tarefa(int id, string descricao, bool concluida = false)
    {
        Id = id;
        Descricao = descricao;
        Concluida = concluida;
    }

    // Sobrescrever o ToString facilita a exibição da tarefa em qualquer lugar do código.
    public override string ToString()
    {
        string status = Concluida ? "[X]" : "[ ]";
        return $"{status} ID: {Id} | Descrição: {Descricao}";
    }
}

