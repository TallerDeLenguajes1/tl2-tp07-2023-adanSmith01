using System.Text.Json;

namespace tl2_tp07_2023_adanSmith01;

public class AccesoADatos
{
    public List<Tarea> ObtenerLista(){
        List<Tarea> lista = new List<Tarea>();
        string rutaArchivo = "tareas.json";
        FileInfo f = new FileInfo(rutaArchivo);

        if(f.Exists && f.Length > 0){
            string info = File.ReadAllText(rutaArchivo);
            lista = JsonSerializer.Deserialize<List<Tarea>>(info);
        }

        return lista;
    }

    public bool GuardarTareas(List<Tarea> listaTareas){
        string rutaArchivo = "tareas.json";
        if(listaTareas.Count == 0){
            return false;
        } else{
            string info = JsonSerializer.Serialize(listaTareas);
            File.WriteAllText(rutaArchivo, info);
            return true;
        }
    }
}