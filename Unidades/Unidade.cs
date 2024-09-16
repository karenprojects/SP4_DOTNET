namespace CrudSprint2.Unidades;

public class Unidade
{
    public string Id_unidade { get; init; }
    public string End_unidade { get; private set; }
    public string Tipo_exame { get; private set; }
    public char Atende_convenio { get; private set; }
    public string Clinica_cnpj { get; private set; }
    
    public Unidade(string id_unidade, string end_unidade, string tipo_exame, char atende_convenio, string clinica_cnpj)
    {
        Id_unidade = id_unidade;
        End_unidade = end_unidade;
        Tipo_exame = tipo_exame;
        Atende_convenio = atende_convenio;
        Clinica_cnpj = clinica_cnpj;
    }
    
    public void AtualizarTipoExame(string tipo_exame)
    {
        Tipo_exame = tipo_exame;
    }
}