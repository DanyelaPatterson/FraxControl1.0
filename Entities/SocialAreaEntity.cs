namespace FraxControl.Entities
{
    public class SocialAreaEntity
    {
        public SocialAreaEntity()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public string Apellido { get; set; }=null!;

        public DateTime  FechaReserva { get; set;}

        

    }
}