namespace CrudSprint2.Services;

public record AddUnidadeRequest(String Id_unidade, String End_unidade, String Tipo_exame, 
    char Atende_convenio, String Clinica_cnpj);