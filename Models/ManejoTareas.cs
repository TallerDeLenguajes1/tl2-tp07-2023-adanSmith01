namespace tl2_tp07_2023_adanSmith01;

public class ManejoTareas
{
    private AccesoADatos accesoTareas;
    public List<Tarea> ListaTareas {get => accesoTareas.ObtenerLista();}

    public ManejoTareas (AccesoADatos accesoTareas){
        this.accesoTareas = accesoTareas;
    }

    public bool CrearTarea(Tarea nuevaTarea){
        bool tareaRealizada = false;
        if(nuevaTarea != null){
            var tareas = ListaTareas;
            nuevaTarea.Id = tareas.Count + 1;
            tareas.Add(nuevaTarea);
            if(accesoTareas.GuardarTareas(tareas)) tareaRealizada = true;
        }

        return tareaRealizada;
    }
    
    public Tarea ObtenerTareaPorId(int idTarea){
        var tareas = ListaTareas;
        var tareaABuscar = tareas.FirstOrDefault(tarea => tarea.Id == idTarea);
        return tareaABuscar;
    }

    public List<Tarea> ObtenerTareasCompletadas(){
        var tareas = ListaTareas;
        List<Tarea> tareasCompletadas = tareas.FindAll(tarea => tarea.Estado == EstadoTarea.Completada);
        return tareasCompletadas;
    }

    public bool ModificarTarea(Tarea tareaAModificar){
        bool modificacionRealizada = false;
        var tareas = ListaTareas;
        if(tareas.Count != 0){
            var tareaAReemplazar = tareas.FirstOrDefault(tarea => tarea.Id == tareaAModificar.Id);
            if(tareaAReemplazar != null){
                tareas.Remove(tareaAReemplazar);
                tareas.Insert(tareaAModificar.Id - 1, tareaAModificar);
                if(accesoTareas.GuardarTareas(tareas)) modificacionRealizada = true;
            }
        }

        return modificacionRealizada;
    }

    public bool EliminarTarea(int idTarea){
        bool eliminacionRealizada = false;
        var tareas = ListaTareas;
        var tareaAEliminar = tareas.FirstOrDefault(tarea => tarea.Id == idTarea);
        if(tareaAEliminar != null){
            tareas.Remove(tareaAEliminar);
            if(accesoTareas.GuardarTareas(tareas)) eliminacionRealizada = true;
        }

        return eliminacionRealizada;
    }
}