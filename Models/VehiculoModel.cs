namespace FraxControl.Models
{
    public class VehiculoModel
    {
        public int Id { get; set; }
        public string Marca { get; set; }=null!;
        public string Modelo { get; set;}=null!;
        public string Owner { get; set; }=null!;

        public string Direccion { get; set; }=null!;

        public string Placas { get; set; }=null!;
    }
}