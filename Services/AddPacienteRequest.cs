namespace CrudSprint2.Services;

public record AddPacienteRequest(string Cpf, string Nome_completo, string Data_nasc, string End_paciente, 
    string Tel_paciente, string Email_paciente, string Senha);
    