namespace CrudSprint2.Pacientes;

public class Paciente
{
    public string Cpf { get; init; }
    public string Nome_completo { get; private set; }
    public string Data_nasc { get; private set; }
    public string End_paciente { get; private set; }
    public string Tel_paciente { get; private set; }
    public string Email_paciente { get; private set; }
    public string Senha { get; private set; }
    
    public Paciente(string cpf, string nome_completo, string data_nasc, string end_paciente, string tel_paciente, string email_paciente, string senha)
    {
        Cpf = cpf;
        Nome_completo = nome_completo;
        Data_nasc = data_nasc;
        End_paciente = end_paciente;
        Tel_paciente = tel_paciente;
        Email_paciente = email_paciente;
        Senha = senha;
    }
    
    public void AtualizarSenha(string senha)
    {
        Senha = senha;
    }
}