namespace FraxControl.Entities
{
    public class VisitaEntity
    {
        public string Name { get; set; }=null!;
        public string Apellido { get; set;}=null!;
        public int Id { get; set; }

        public string Marca { get; set; }=null!;
        public string Modelo { get; set; }=null!;
        public string Placas { get; set; }=null!;

        public DateTime FechaVisita { get; set; }
        


    }
}