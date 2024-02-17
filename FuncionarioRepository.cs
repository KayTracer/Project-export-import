using Projeto02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Projeto02.Repositories;
public class FuncionarioRepository
{
    //Método para exportar os dados de um funcionário para arquivo JSON
    public void Exportar(Funcionario funcionario)
    { 
        //Serializar os dados de um funcionário para o formato JSON
        var json = JsonConvert.SerializeObject(funcionario);

        using (var streamWriter = new StreamWriter("c:\\temp\\funcionario.json"))
        {
            //Gravando o conteúdo JSON dentro do arquivo
            streamWriter.WriteLine(json);
        }
    }
    //Método para importar os dados do funcionário de JSON para C#
    public Funcionario Importar()
    {
        //Abrindo um arquivo em modo leitura
        using(var streamReader = new StreamReader("c:\\temp\\funcionario.json"))
        {
            //ler todo o conteúdo do arquivo...
            var json = streamReader.ReadToEnd();

            //deserializar o conteudo JSON
            return JsonConvert.DeserializeObject<Funcionario>(json);
        }
    }
}
