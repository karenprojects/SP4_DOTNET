using System.IO;
using Microsoft.ML;


namespace CrudSprint2.MLModels
{
    public class AgendamentoModelTrainer
    {
        private static string _modelPath = Path.Combine(Environment.CurrentDirectory, "MLModels", "AgendamentoModel.zip");

        public static void TreinarModelo()
        {
            var mlContext = new MLContext();

            
            var dataPath = Path.Combine(Environment.CurrentDirectory, "MLModels", "agendamentos.csv");
            IDataView dataView = mlContext.Data.LoadFromTextFile<AgendamentoData>(dataPath, hasHeader: true, separatorChar: ',');
            
            var pipeline = mlContext.Transforms.Concatenate("Features", "N_protocolo", "Data_hora_agendamento", "Unidade_id_unidade", "Paciente_cpf")
                .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "NumeroAgendamentos", maximumNumberOfIterations: 100));

            // Treinar o modelo
            var model = pipeline.Fit(dataView);
            
            mlContext.Model.Save(model, dataView.Schema, _modelPath);
        }
    }
    
    public static float PreverAgendamentos(string n_protocolo, string data_hora_agendamento, string unidade_id_unidade, string paciente_cpf)
    {
        var mlContext = new MLContext();


        ITransformer trainedModel = mlContext.Model.Load(_modelPath, out var modelInputSchema);

        var predictionEngine = mlContext.Model.CreatePredictionEngine<AgendamentoData, AgendamentoPrediction>(trainedModel);
        
        var inputData = new AgendamentoData { N_protocolo = n_protocolo, Data_hora_agendamento = data_hora_agendamento, Unidade_id_unidade = unidade_id_unidade, Paciente_cpf = paciente_cpf };

        // Fazer a previsão
        var prediction = predictionEngine.Predict(inputData);

        return prediction.PredictedAgendamentos;
    }
}