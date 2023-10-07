namespace tl2_tp07_2023_adanSmith01;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

public enum EstadoTarea
{
    [EnumMember(Value = "Pendiente")]
    Pendiente,
    [EnumMember(Value = "EnProceso")]
    EnProceso,
    [EnumMember(Value = "Completada")]
    Completada
}

public class Tarea
{
    private int id;
    private string titulo;
    private string descripcion;
    private EstadoTarea estado;

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EstadoTarea Estado { get => estado; set => estado = value; }
}