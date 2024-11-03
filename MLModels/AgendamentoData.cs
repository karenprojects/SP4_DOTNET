using Microsoft.ML.Data;

namespace CrudSprint2.MLModels;

public class AgendamentoData
{
    [LoadColumn(0)]
    public string N_protocolo { get; set; }

    [LoadColumn(1)]
    public string Data_hora_agendamento { get; set; }

    [LoadColumn(2)]
    public string Unidade_id_unidade { get; set; }

    [LoadColumn(3)]
    public string Paciente_cpf { get; set; }
    
    
}

public class AgendamentoPrediction
{
    [ColumnName("Score")]
    public float PredictedAgendamentos { get; set; }
}